using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Char;

namespace BuscadorFuncionesTrigger.clases
{
    class Utiles
    {   //CARGA DE DATOS A LA LISTA
        public static void CargarLista(ListBox listBox, ArrayList arrayList)
        {//LIMPIEZA DE LOS COMBOS
            listBox.Items.Clear();
            if (arrayList.Count > 0) { 
                //CARGA DE DATOS
                foreach (var nombre in arrayList)
                {//CARGA DE DATOS
                    listBox.Items.Add(nombre);
                }//lista.TopIndex = 1;
                listBox.SetSelected(0, true);
            }
        }
        public static void CargarCombo(ComboBox comboLista, ArrayList arrayList)
        {//LIMPIEZA DE LOS COMBOS
            comboLista.Items.Clear();
            if (arrayList.Count > 0)
            {//CARGA DE DATOS
                foreach (var nombre in arrayList)
                {//AGREGADO
                    comboLista.Items.Add(nombre);
                }//primer Registro
                comboLista.SelectedIndex = 0;
            }
        }
        //cargar lisview
        public static void Cargarlistview(ListView listaview, ArrayList arrayList)
        {//LIMPIEZA DE LOS COMBOS
            listaview.Clear();
            if (arrayList.Count > 0)
            {//CARGA DE DATOS
                var lista = new ListViewItem();
                lista.SubItems.Add("DATO");
                listaview.Items.Add(lista);
    
                listaview.Focus();
            }
        }
        //VALIDAR SOLO NUMERO
        public static void OlyNumero(KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }
        //SENTENCIA DE CREACION DE BACKUP BD COMPLETA -- iNFORMACION DE STACKOVERFLOW   http://stackoverflow.com/questions/23026949/how-to-backup-restore-postgresql-using-code
        public static void PostgreSqlDump(string pgDumpPath,string outFile,bool besq, string cNombreSchema, string host,string port,
                string database,string user,string password)

        {//CREACION DE CADENAS DE COMANDO , PARA EL POSTGRES 
            var dumpCommand = "\"" + pgDumpPath + "\"" + " -Fc" + " -h " + host + " -p " + port + " -d " + database + " -U " 
                + user + (besq ? " -n "+ cNombreSchema + "":"") + "";

            var passFileContent = "" + host + ":" + port + ":" + database + ":" + user + ":" + password + "";

            //CREACION DEL ARCHIVO BAT , EL CUAL EJECUTARA LA CADENA DE COMANDO
            var batFilePath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid() + ".bat");

            //CREACION DEL ARCHIVO CONFIG
            var passFilePath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid() + ".conf");
            var oInfo = new ProcessStartInfo(batFilePath);
            try
            {
                var batchContent = "";
                batchContent += "@" + "set PGPASSFILE=" + passFilePath + "\n";
                batchContent += "@" + dumpCommand + "  > " + "\"" + outFile + "\"" + "\n";

                File.WriteAllText(
                    batFilePath,
                    batchContent,
                    Encoding.ASCII);

                File.WriteAllText(
                    passFilePath,
                    passFileContent,
                    Encoding.ASCII);

                if (File.Exists(outFile))
                    File.Delete(outFile);

                oInfo.UseShellExecute = false;
                oInfo.CreateNoWindow = true;

                using (Process proc = Process.Start(oInfo))
                {
                    if (proc != null)
                    {
                        proc.WaitForExit();
                        proc.Close();
                    }
                }
            }
            finally

            {
                if (File.Exists(batFilePath))
                    File.Delete(batFilePath);

                if (File.Exists(passFilePath))
                    File.Delete(passFilePath);
            }
        }
        //SENTENCIA DE RESTAURACION -- iNFORMACION JAPONESA http://at-links.biz/blog/?p=1831
        public static void PostgreSqlRestoreBackup(string pgDumpPath, string outFile, string host, string port,
                string database, string user, string password)
        {
            try
            {
                Environment.SetEnvironmentVariable("PGPASSWORD", password);
                var outProcess = new Process
                {
                    StartInfo =
                    {
                        FileName = pgDumpPath,
                        Arguments = " -i -h " + host + " -p " + port + " -U " + user + " -w -d "
                                    + database + " -c -v " + '\u0022' + outFile + '\u0022',
                        UseShellExecute = false
                    }
                };
                outProcess.StartInfo.UseShellExecute = false;
                outProcess.StartInfo.CreateNoWindow = true;
                outProcess.Start();
                while (true)
                {
                    if (outProcess.HasExited) {
                        outProcess.WaitForExit();
                        break;
                    }
                }
                outProcess.Close();
                outProcess.Dispose();
            }
            catch (Exception ex)
            {//MENSAJE
                MessageBox.Show(ex.Message);
            }
        }
        //MOSTRAMOS EL ERROR Y ATRAPAMOS LA CONSULTA
        public static void _cliptext(string cSql)
        {
            Clipboard.SetText(cSql);
        }
    }
}
