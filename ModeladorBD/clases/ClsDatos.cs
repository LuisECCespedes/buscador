using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace BuscadorFuncionesTrigger.clases
{
    class ClsDatos
    {
        private static readonly NpgsqlConnection Conex = new NpgsqlConnection();
        //CONEXION
        public static bool Conectar(string cuser, string cpass, string cHost, string cport, string cDataBase)
        {
            var bestado = true;
            //Armamos la Cadena de Conexion
            Conex.ConnectionString = "User ID=" + cuser + "; Password=" + cpass +
                                ";  Host=" + cHost + "; Port=" + cport + ";  Database=" + cDataBase + "; commandtimeout=900";
            try
            {//Confirmacion
                Conex.Open();
            }catch (Exception e)
            {//Error 
                MessageBox.Show(e.Message);
                bestado = false;}
            return bestado;
        }
        //DESCONECCIÓN
        public static void Desconectar()
        {
            try
            {//Estado
                if (Conex.State == ConnectionState.Open)
                {
                    Conex.Close();
                }
            }catch (Exception e)
            {//Error 
                MessageBox.Show(e.Message);
            }
        }
        //METODO REALIZARA LA CONSULTA TRALLENDO DATOS
        public static ArrayList ListaDatos(string cSql)
        {
            var lista = new ArrayList();
            var coman = new NpgsqlCommand(cSql, Conex);
            try
            {   //Consulta
                var dr = coman.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(dr.GetString(0));
                }
            }
            catch (Exception e)
            {
                AtraparError(e, cSql);
            }
            finally
            {
                //desconeccion
                Desconectar();
            }
            return lista;
        }
        //RETORNAR CADENA DE DATOS 
        public static string CadenaDatos(string cSql)
        {
            var dato = "";
            var coman = new NpgsqlCommand(cSql, Conex);
            try
            {
                //Consulta
                dato = coman.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                //Error
                AtraparError(e, cSql);
            }
            finally
            {
                //desconeccion
                Desconectar();
            }
            return dato;
        }
        //EJECUTAR EL DATO
        public static bool run_script(string cSql)
        {
            var bestado=true;
            var coman = new NpgsqlCommand(cSql, Conex);
            try
            {
                //Consulta
                coman.ExecuteScalar();
            }
            catch (Exception e)
            {
                //Error
                AtraparError(e, cSql);
                bestado = false;
            }
            finally
            {
                //desconeccion
                Desconectar();
            }
            return bestado;
        }
        //MOSTRAMOS EL ERROR Y ATRAPAMOS LA CONSULTA
        private static void AtraparError(Exception e, string cSql)
        {
            Clipboard.SetText(cSql);
            MessageBox.Show(e.Message);
        }
    }
}
