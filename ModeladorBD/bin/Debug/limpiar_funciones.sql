set search_path to public;
DROP FUNCTION IF EXISTS bd_buscar_estructura_funciones_triggers(varchar , boolean , varchar);
DROP FUNCTION IF EXISTS bd_buscar_funciones_por_palabra(cschema varchar,btrigger boolean,cproname varchar);