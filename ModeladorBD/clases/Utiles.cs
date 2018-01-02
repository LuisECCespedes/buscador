using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ModeladorBD
{
    class Utiles
    {   //CARGA DE DATOS A LA LISTA
        public static void cargarLista(ListBox listBox, ArrayList arrayList)
        {//LIMPIEZA DE LOS COMBOS
            listBox.Items.Clear();
            if (arrayList.Count > 0) { 
                //CARGA DE DATOS
                foreach (String Nombre in arrayList)
                {//CARGA DE DATOS
                    listBox.Items.Add(Nombre);
                }//lista.TopIndex = 1;
                listBox.SetSelected(0, true);
            }
        }
        public static void cargarCombo(ComboBox comboLista, ArrayList arrayList)
        {//LIMPIEZA DE LOS COMBOS
            comboLista.Items.Clear();
            if (arrayList.Count > 0)
            {//CARGA DE DATOS
                foreach (String Nombre in arrayList)
                {//AGREGADO
                    comboLista.Items.Add(Nombre);
                }//primer Registro
                comboLista.SelectedIndex = 0;
            }
        }
        //cargar lisview
        public static void cargarlistview(ListView Listaview, ArrayList arrayList)
        {//LIMPIEZA DE LOS COMBOS
            Listaview.Clear();
            if (arrayList.Count > 0)
            {//CARGA DE DATOS
//                foreach (String Nombre in arrayList)
  //              {//AGREGADO
                    ListViewItem lista = new ListViewItem();
                    lista.SubItems.Add("DATO");
                    Listaview.Items.Add(lista);
    //            }//primer Registro 
                /*
                    ListViewItem lista = new ListViewItem(txt_nom_func.Text);
                    lst_view.Items.Add(lista);
                    lista.SubItems.Add("1");
                    lista.SubItems.Add("void");
                */
                Listaview.Focus();
    //          LV.ListItems.Item(2).Selected = True 
    //          Listaview.fi
    //          Listaview.SelectedIndex = 0;
            }
        }
        //VALIDAR SOLO NUMERO
        public static void olyNumero(KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
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
         String dumpCommand = "\"" + pgDumpPath + "\"" + " -Fc" + " -h " + host + " -p " + port + " -d " + database + " -U " 
                + user + (besq ? " -n "+ cNombreSchema + "":"") + "";
         //            if (besq) { String dumpCommand = "\"" + pgDumpPath + "\"" + " -Fc" + " -h " + host + " -p " + port + " -d " + database + " -U " + user +"";}else{}
         //COMANDO BACKUP DE ESQUEMA
         //      String dumpCommand = "\"" + pgDumpPath + "\"" + " -Fc" + " -h " + host + " -p " + port + " -d " + database + " -U " + user + " -n general " +"";
         //COMANDO BACKUP DE TABLA  
         //      String dumpCommand = "\"" + pgDumpPath + "\"" + " -Fc" + " -h " + host + " -p " + port + " -d " + database + " -U " + user + " -t general.pension " + "";
         //   String dumpCommand = "\"" + pgDumpPath + "\"" + " -Fc" + " -h " + host + " -p " + port + " -d " + database + " -U " 
         //       + user + (besq ? " -s "+ cNombreSchema + "":"") + "";
            String passFileContent = "" + host + ":" + port + ":" + database + ":" + user + ":" + password + "";
            //CREACION DEL ARCHIVO BAT , EL CUAL EJECUTARA LA CADENA DE COMANDO
            String batFilePath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".bat");
            //CREACION DEL ARCHIVO CONFIG
            String passFilePath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".conf");
            try
            {
                String batchContent = "";
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

                ProcessStartInfo oInfo = new ProcessStartInfo(batFilePath);
                oInfo.UseShellExecute = false;
                oInfo.CreateNoWindow = true;

                using (Process proc = System.Diagnostics.Process.Start(oInfo))
                {
                    proc.WaitForExit();
                    proc.Close();
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
                Process outProcess = new Process();
                outProcess.StartInfo.FileName = pgDumpPath;
                outProcess.StartInfo.Arguments = " -i -h " + host + " -p " + port + " -U " + user + " -w -d " 
                    + database + " -c -v " + '\u0022' + outFile + '\u0022';
                outProcess.StartInfo.UseShellExecute = false;
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
                outProcess = null;
            }
            catch (Exception ex)
            {//MENSAJE
                MessageBox.Show(ex.Message);
            }
        }
        //MOSTRAMOS EL ERROR Y ATRAPAMOS LA CONSULTA
        public static void _cliptext(String cSql)
        {
            Clipboard.SetText(cSql);
        }
    }
}
