set search_path to public;
--eliminar funciones
DROP FUNCTION IF EXISTS bd_buscar_estructura_funciones_triggers(varchar , boolean , varchar);
DROP FUNCTION IF EXISTS bd_buscar_funciones_por_palabra(cschema varchar,btrigger boolean,cproname varchar);
--BUSCAR UNA FUNCION EN ESPECIFICA , SEGUN EL NOMBRE
CREATE OR REPLACE FUNCTION bd_buscar_estructura_funciones_triggers(cschema character varying,btrigger boolean, cproname character varying DEFAULT NULL::character varying)
  RETURNS text AS
$BODY$
/*	Autor : Luis Cruz		Fecha : 2016-10-25
	Objetivo : Retornar la estructuras de las funciones EXECPTUANDO A LOS TRIGGERS 
	Forma de Uso : 
	select public.bd_buscar_estructura_funciones_triggers('base',false,'iif')
*/
declare 
cquery text:='';	r record;
begin 
	---NOS RETORNARA LA ESTRUCTURA DE ELIMINACION DE LAS FUNCIONES 
	if btrigger then
		cquery :='set search_path to '|| cschema ||';';
	--		ARMO LA SENTENCIA DE CREACION DE TRIGGERS
		for r in select trim(routine_name)as routine_name,pg_get_functiondef((specific_schema||'.'||routine_name)::regproc) from information_schema.routines 
			where specific_schema = cschema and data_type = 'trigger' 
				order by specific_schema
		loop
		--YA QUE NO SE PUDO ENCONTRAR EL REGISTRO CON EL WHERE , ENTONCES CON LA SEGUNDA CONDICIONAL SOLO SELECCIONARE UNA CONDICIONAL
			if cproname isnull then
				cquery := cquery||chr(13);
				cquery := cquery||r.pg_get_functiondef||';';
			else
				--YA QUE LOS NOMBRE DE LOS DATOS NO COINCIDEN 'MEZCLO UNA FUNCION A MI CONVENIENCIA'
				if length(btrim(r.routine_name,cproname))=0 then
					cquery := cquery||chr(13);
					cquery := cquery||r.pg_get_functiondef||';';
					exit;
				end if;
			end if;
		end loop;
	else
			--CREACION DE ESTRUCTURA DE FUNCIONES 
		for r in SELECT pg_get_functiondef(f.oid) FROM pg_catalog.pg_proc f
			INNER JOIN pg_catalog.pg_namespace n ON (f.pronamespace = n.oid)
			WHERE n.nspname = cschema and proname = coalesce(cproname,proname)
			order by pg_get_functiondef(f.oid)
		loop
			--CONDICIONAMOS PARA QUE SOLO SE ACEPTEN FUNCIONES 
			if position('RETURNS trigger' in r.pg_get_functiondef ) = 0 then
				cquery := cquery||chr(13);
				cquery := cquery||r.pg_get_functiondef||';';
			end if;
		end loop;		
	end if;
	return cquery;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 1000;

--BUSCAR FUNCIONES EN ESPECIFICA , DE ACUERDO A UNA PALABRA
CREATE OR REPLACE FUNCTION bd_buscar_funciones_por_palabra(cschema character varying,btrigger boolean, cproname character varying DEFAULT NULL::character varying)
  RETURNS setof record AS
$BODY$
/*	Autor : Luis Cruz		Fecha : 2017-04-25
	Objetivo : Retornar la estructuras de las funciones EXECPTUANDO A LOS TRIGGERS 
	Forma de Uso : 
	
	select * from public.bd_buscar_funciones_por_palabra('sisplani',true,'')
		as (nombre_de_la_funcion text)

	select * from public.bd_buscar_funciones_por_palabra('base',False) as (nombre_de_la_funcion text)
		
*/
declare 
cquery text:='';	r record;
begin 
	--TEMPORAL PARA EL RETORNO DE LOS DATOS 
	create temp table temp_retorno_query (nombre text)on commit drop;
	
	---NOS RETORNARA LA ESTRUCTURA DE ELIMINACION DE LAS FUNCIONES 
	if btrigger then
		cquery :='set search_path to '|| cschema ||';';
		
	--		ARMO LA SENTENCIA DE CREACION DE TRIGGERS
		for r in select trim(routine_name)as routine_name from information_schema.routines 
			where specific_schema = cschema and data_type = 'trigger' 
				order by specific_schema
		loop	--YA QUE NO SE PUDO ENCONTRAR EL REGISTRO CON EL WHERE , ENTONCES CON LA SEGUNDA CONDICIONAL SOLO SELECCIONARE UNA CONDICIONAL
			if cproname isnull then
				insert into temp_retorno_query values(r.routine_name);
			else
				--YA QUE LOS NOMBRE DE LOS DATOS NO COINCIDEN 'MEZCLO UNA FUNCION A MI CONVENIENCIA'
				if r.routine_name ilike '%'||cproname||'%' then 
					insert into temp_retorno_query values(r.routine_name);
				end if;
			end if;
		end loop;
	else
		---BUSQUEDA DE DATOS PARA FUNCIONES 
		for r in SELECT trim(proname)as routine_name , pg_get_functiondef(f.oid) as estruc FROM pg_catalog.pg_proc f
				INNER JOIN pg_catalog.pg_namespace n ON (f.pronamespace = n.oid)
				WHERE n.nspname = cschema 
		loop
			--CONDICIONAMOS PARA QUE SOLO SE ACEPTEN FUNCIONES 
			if position('RETURNS trigger' in r.estruc) = 0 then
				--si no se ha pedido parametro
					if cproname isnull then 
						insert into temp_retorno_query values(r.routine_name);
					else
						if r.routine_name ilike '%'||cproname||'%' then 
							insert into temp_retorno_query values(r.routine_name);
						end if;
					end if;
			end if;
		end loop;		
	end if;
	return query select * from temp_retorno_query order by nombre;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 9999
  rows 9999;
   