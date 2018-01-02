using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using System.Data;
using System.Collections;
namespace ModeladorBD
{
    class ClsDatos
    {
        private static NpgsqlConnection conex = new NpgsqlConnection();
        //CONEXION
        public static Boolean Conectar(String cuser, String cpass, String cHost, String cport, String cDataBase)
        {
            Boolean bestado = true;
            //Armamos la Cadena de Conexion
            conex.ConnectionString = "User ID=" + cuser + "; Password=" + cpass +
                                ";  Host=" + cHost + "; Port=" + cport + ";  Database=" + cDataBase + "; commandtimeout=900";
            try
            {//Confirmacion
                conex.Open();
            }catch (Exception e)
            {//Error 
                MessageBox.Show(e.Message);
                bestado = false;}
            return bestado;
        }//DESCONECCIÓN
        public static void Desconectar()
        {
            try
            {//Estado
                if (conex.State == System.Data.ConnectionState.Open)
                {
                    conex.Close();
                }
            }catch (Exception e)
            {//Error 
                MessageBox.Show(e.Message);
            }
        }
        //METODO REALIZARA LA CONSULTA TRALLENDO DATOS
        public static ArrayList listaDatos(String cSql)
        {
            DataSet dt = new DataSet();
            ArrayList Lista = new ArrayList();
            try
            {
                //Consulta
                NpgsqlCommand coman = new NpgsqlCommand(cSql, conex);
                NpgsqlDataReader dr = coman.ExecuteReader();
                while (dr.Read())
                {
                    Lista.Add(dr.GetString(0));
                }
            }
            catch (Exception e)
            {
                atraparError(e, cSql);
            }
            finally
            {
                //desconeccion
                Desconectar();
            }
            return Lista;
        }
        //RETORNAR CADENA DE DATOS 
        public static String cadenaDatos(String cSql)
        {
            String Dato = "";
            try
            {
                //Consulta
                NpgsqlCommand coman = new NpgsqlCommand(cSql, conex);
                Dato = coman.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                //Error
                atraparError(e, cSql);
            }
            finally
            {
                //desconeccion
                Desconectar();
            }
            return Dato;
        }
        //EJECUTAR EL DATO
        public static Boolean run_script(String cSql)
        {
            Boolean bestado=true;
            try
            {
                //Consulta
                NpgsqlCommand coman = new NpgsqlCommand(cSql, conex);
                coman.ExecuteScalar();
            }
            catch (Exception e)
            {
                //Error
                atraparError(e, cSql);
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
        private static void atraparError(Exception e, String cSql)
        {
            Clipboard.SetText(cSql);
            MessageBox.Show(e.Message);
        }
    }
}
