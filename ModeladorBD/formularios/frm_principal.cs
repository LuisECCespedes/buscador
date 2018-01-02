using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace ModeladorBD
{
    /// <summary>
    // CONTINUAR CON LA IMPLEMENTACION DE LA CREACION DE BACKUP POR ESQUEMA Y LA RESTAURACION DE BD Y ESQUEMA
    /// </summary>
    public partial class frm_principal : Form
    {
        public frm_mensaje frmmensaje = new frm_mensaje();
        public String cadenaConexion ="";
        
        public frm_principal()
        {
            InitializeComponent();
            Size = new System.Drawing.Size(590, 170);
        }
        //CONECTAR BD
        public Boolean conectarBd(String baseDatos)
        {
            Boolean v = false;
            //Alamcenamos en variables "LUEGO SE VALIDA SU VALOR VACIO"
            String cuser = this.txtUser.Text, cpass = this.txtPass.Text, cport = this.txtPuerto.Text,
                cdata = baseDatos, chost = this.txtServidor.Text;
            //Conexion
            if (ClsDatos.Conectar(cuser, cpass, chost, cport, cdata)) { 
                v = true;
            }
            return v ;
        }
        //CARGAR LOS ESQUEMAS DE LA BD
        public void consultarEsquemas()
        {
            //Array para los registros
            ArrayList xLista;
            //Cadena de Consulta 
            String cadena = "select nspname::varchar as nombre_del_los_esquema_listados from pg_namespace "
                    + "where substring(nspname from 1 for 3) != 'pg_'  and nspname not in ('information_schema','public') order by nspname ";
            //CARGAMOS LOS DATOS DE LOS ESQUEMA
            xLista = ClsDatos.listaDatos(cadena);
            Utiles.cargarCombo(this.cmb_esquemas, xLista);
        }
        //CARGAR LOS DATOS DE LA FUNCION
        public void consultarDatosFuncion(String squema)
        {
            //Array para los registros
            ArrayList xLista;
            //Cadena de Consulta 
            String cadena = "select * from public.bd_buscar_funciones_por_palabra('" + squema + "'," + (rb_trigger.Checked ? true : false) +
                        (txt_nom_func.Text.Length > 0 ? ",'" + txt_nom_func.Text + "'" : "") + ") as (nombre_de_la_funcion text)";
            //CARGAMOS LOS DATOS DE LOS ESQUEMA
            xLista = ClsDatos.listaDatos(cadena);

            Utiles.cargarCombo(this.cmb_funcion, xLista);
        }
        //MENSAJES DE PROCESO
        public void abrirCerrarFormulario(bool v)
        {       frmmensaje.Visible = v;        }
        //MENSAJE PARA EL FLOTANTE
        public void mensaje(String mensaje)
        {
            frmmensaje.Text = mensaje;
        }
        //REALIZAR CONEXION
        private void btnConexion_Click(object sender, EventArgs e)
        {//OBJETO TIPO FORMULARIO MENSAJE
            frmmensaje.Visible = false;
            frmmensaje.Show();
            frmmensaje.Text = "Cargando Esquemas. Espere...";
            //ABRIMOS
            abrirCerrarFormulario(true);
            //CONSULTAR BD
            if (conectarBd("postgres"))
            {//CARGAR LAS BASE DE DATOS EXISTENTES
                cargar_bd();
                this.lbl_base_datos.Visible = this.cmb_base_datos.Visible = this.btn_listar_esquemas.Visible = true;
                Size = new System.Drawing.Size(590, 230);
            }
            abrirCerrarFormulario(false);
        }
        //SOLO NUMEROS EN EL PUERTO
        private void txtPuerto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utiles.olyNumero(e);
        }
        //SALIR
        private void btn_salir_Click(object sender, EventArgs e)
        {   //DESCONECTAR
            ClsDatos.Desconectar();
            if (this.cmb_base_datos.Items.Count > 0)
            {   //CONECTAR
                conectarBd(this.cmb_base_datos.SelectedItem.ToString());
                //ELIMINAR LOS DATOS
                ClsDatos.run_script(Retornar_lectura_script("limpiar_funciones.sql"));
                //CERRAR CONEXION Y CERRAR FORMULARIO
                ClsDatos.Desconectar();
            }
            this.Close();
        }
        //GENERAR LA ESTRUCTURA
        private void btn_generar_Click(object sender, EventArgs e)
        {//SI NO EXISTE NINGUN ESQUEMA BLOQUEAR
            this.Size = new System.Drawing.Size(590, 374);
            if (this.cmb_esquemas.Items.Count < 1)
            {//MENSAJE
                MessageBox.Show("No Hay Esquemas"); return;
            }
            //MENSAJE
            frmmensaje.Text = "Realizando Analisis. Espere...";
            //METODO MUESTRA MENSAJE
            abrirCerrarFormulario(true);
            
            //ATRAPAMOS LOS VALORES DE LOS ESQUEMAS 
            String squemaModelo = cmb_esquemas.SelectedItem.ToString();
            //CONEXION A BASE DATOS 
            if (conectarBd(this.cmb_base_datos.SelectedItem.ToString()))
            {   //MOSTRAMOS EN FORMULARIO EL VALOR ENVIADO DE LA BASE DE DATOS 
                frmmensaje.Text = "Estructurando Esquema. Espere...";
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Insert(0, (chk_busqueda.Checked ? tabPage2 : tabPage1));
                if (chk_busqueda.Checked)
                {   //cargar los datos de listview
                    consultarDatosFuncion(squemaModelo);
                    //tamaño x defecto
                    this.Size = new System.Drawing.Size(590, 804);
                    //datos reinicio
                    btn_guardar_opt2.Visible = txt_estructura_opt2.Visible = btn_copiar_opt2.Visible = btn_ejecutar_opt2.Visible = false;
                    ClsDatos.Desconectar();
                }
                else
                {//ENVIAMOS EL VALOR RETORNADO AL OTRO FORMULARIO
                    String Cadena = ClsDatos.cadenaDatos(TipFuncion(squemaModelo,true));
                    txt_estructura.Text = Cadena;
                    if (Cadena.Length > 0) this.Size = new System.Drawing.Size(590, 804);
                }
                //CERRAMOS FORMULARIO DE MENSAJE
                abrirCerrarFormulario(false);
            }
            //CERRAMOS FORMULARIO DE MENSAJE 
            abrirCerrarFormulario(false);
        }
        //CREACION DE CADENA 
        public String TipFuncion(String squemaModelo,Boolean bfunc)
        {   //PRIMERA CONDICIONAL       
            if (bfunc)
            {
                return "select public.bd_buscar_estructura_funciones_triggers('" + squemaModelo + "'," + (rb_trigger.Checked ? true : false) +
                        (txt_nom_func.Text.Length > 0 ? ",'" + txt_nom_func.Text + "'" : "") + ")";
            }
            else
            {
                return "select public.bd_buscar_estructura_funciones_triggers('" + squemaModelo + "'," + (rb_trigger.Checked ? true : false) +
                        (",'" + cmb_funcion.SelectedItem.ToString() + "'" ) + ")";
            }
        }
        //VISUALIZACION DE PARAMETROS 
        private void btn_mostrar_Click(object sender, EventArgs e)
            //mostrar ocultar la Contraseña 
        {this.txtPass.UseSystemPasswordChar = (this.txtPass.UseSystemPasswordChar)?false:true;}
        private void cargar_bd()
        {//Array para los registros
            ArrayList xLista;
            //Cadena de Consulta 
            String cadena = "select datname from pg_database where datname not in ('template1','template0') order by datname asc";
            //CARGAMOS LOS DATOS DE LOS ESQUEMA
            xLista = ClsDatos.listaDatos(cadena);
            Utiles.cargarCombo(this.cmb_base_datos, xLista);
            //Utiles.cargarLista(this.lst_esquemas, xLista);
        }

        private void btn_listar_esquemas_Click(object sender, EventArgs e)
        {//DATOS DE LOS ESQUEMA DE LA BD
            if (conectarBd(this.cmb_base_datos.SelectedItem.ToString()))
            {   //TAMAÑO DE FORMULARIO
                consultarEsquemas();
                //RESTABLECER CHECK
                chk_busqueda.Checked = false;
                //DESCONECTAR
                ClsDatos.Desconectar();
                //CONECTAR
                conectarBd(this.cmb_base_datos.SelectedItem.ToString());
                //EJECUTAR EL ARCHIVO SQL
                ClsDatos.run_script(Retornar_lectura_script("modelador.sql"));
                this.Size = new System.Drawing.Size(590, 374);
                //BLOQUEO OPCIONES DE CONEXION 
                grbCadenaConec.Enabled = false;
                txt_nom_func.Text = "";
            }
            abrirCerrarFormulario(false);
        }
      
        private void button3_Click(object sender, EventArgs e)
        {//cerrar conexion y cerrar formulario
            ClsDatos.Desconectar();
            this.Close();
        }

        private void btn_desc_Click(object sender, EventArgs e)
        {   //DESCONECTAR
            ClsDatos.Desconectar();
            //CONECTAR
            conectarBd(this.cmb_base_datos.SelectedItem.ToString());
            //ELIMINAR LOS DATOS
            ClsDatos.run_script(Retornar_lectura_script("limpiar_funciones.sql"));
            //DESCONECTAR Y DAR TAMAÑO A EL FORMULARIO
            ClsDatos.Desconectar();
            grbCadenaConec.Enabled = true;
            Size = new System.Drawing.Size(590, 170);
        }

        private void btn_ejecutar_Click(object sender, EventArgs e)
        {
            if (conectarBd(this.cmb_base_datos.SelectedItem.ToString()))
            {//DATOS DE LOS ESQUEMA DE LA BD
                ClsDatos.run_script(txt_estructura.Text.Trim());
                //BLOQUEO OPCIONES DE CONEXION
                grbCadenaConec.Enabled = false;
            }
            abrirCerrarFormulario(false);
        }
        
        private String Ruta_Path(String nombreArchivo)
        {   //CARGAMOS LA RUTA POR DEFECTO , Y EL ARCHIVO   nombreArchivo
            return Application.StartupPath + "\\" + nombreArchivo;
        }
        private String Retornar_lectura_script(String nombreArchivo)
        {//leer el archivo
            return File.ReadAllText(Ruta_Path(nombreArchivo));
        }
        private void btn_buscar_en_lista_Click(object sender, EventArgs e)
        {   //MENSAJE
            frmmensaje.Text = "Realizando Analisis. Espere...";
            //METODO MUESTRA MENSAJE
            abrirCerrarFormulario(true);

            //ATRAPAMOS LOS VALORES DE LOS ESQUEMAS 
            String squemaModelo = cmb_esquemas.SelectedItem.ToString();
            //CONEXION A BASE DATOS 
            if (conectarBd(this.cmb_base_datos.SelectedItem.ToString()))
            {   //MOSTRAMOS EN FORMULARIO EL VALOR ENVIADO DE LA BASE DE DATOS 
                frmmensaje.Text = "Estructurando Esquema. Espere...";                
                String Cadena = ClsDatos.cadenaDatos(TipFuncion(squemaModelo, false));
                txt_estructura_opt2.Text = Cadena;
                if (Cadena.Length > 0) this.Size = new System.Drawing.Size(590, 804);
                //DATOS DE MUESTRA 
                if (Cadena.Length > 0) btn_guardar_opt2.Visible = txt_estructura_opt2.Visible = btn_copiar_opt2.Visible = btn_ejecutar_opt2.Visible = true;
                //CERRAMOS FORMULARIO DE MENSAJE
                abrirCerrarFormulario(false);
            }
        }
        private void guardar_tecto_en_archivo(String ctexto)
        {
            String path = "";
            //BUSCAMOS LA RUTA PARA GUARDAR EL ARCHIVO
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {   //ALMACENAMOS LA DIRECCION DEL ARCHIVO
                path = saveFileDialog1.FileName;
                //COMPROBAMOS EXISTENCIA Y REEMPLAZO
                if (!File.Exists(path))
                {   // ALMACENAMOS EL TEXTO COMO ARCHIVO
                    File.WriteAllText(path, ctexto);
                    MessageBox.Show("Archivos Almacenados en :" + path);
                }
            }
        }
        private void btn_copiar_Click_1(object sender, EventArgs e)
        {
            Utiles._cliptext(txt_estructura.Text);
        }

        private void btn_copiar_opt2_Click(object sender, EventArgs e)
        {
            Utiles._cliptext(txt_estructura_opt2.Text);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {   //enviamos el texto al metodo para crear un archivo
            if (txt_estructura.Text.Length > 0) guardar_tecto_en_archivo(txt_estructura.Text);
        }

        private void btn_guardar_opt2_Click(object sender, EventArgs e)
        {   //enviamos el texto al metodo para crear un archivo
            if (txt_estructura_opt2.Text.Length > 0) guardar_tecto_en_archivo(txt_estructura_opt2.Text);
        }

        private void txt_nom_func_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {//SI NO EXISTE NINGUN ESQUEMA BLOQUEAR
                this.Size = new System.Drawing.Size(590, 374);
                if (this.cmb_esquemas.Items.Count < 1)
                {//MENSAJE
                    MessageBox.Show("No Hay Esquemas"); return;
                }
                //MENSAJE
                frmmensaje.Text = "Realizando Analisis. Espere...";
                //METODO MUESTRA MENSAJE
                abrirCerrarFormulario(true);

                //ATRAPAMOS LOS VALORES DE LOS ESQUEMAS 
                String squemaModelo = cmb_esquemas.SelectedItem.ToString();
                //CONEXION A BASE DATOS 
                if (conectarBd(this.cmb_base_datos.SelectedItem.ToString()))
                {   //MOSTRAMOS EN FORMULARIO EL VALOR ENVIADO DE LA BASE DE DATOS 
                    frmmensaje.Text = "Estructurando Esquema. Espere...";
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Insert(0, (chk_busqueda.Checked ? tabPage2 : tabPage1));
                    if (chk_busqueda.Checked)
                    {   //cargar los datos de listview
                        consultarDatosFuncion(squemaModelo);
                        //tamaño x defecto
                        this.Size = new System.Drawing.Size(590, 804);
                        //datos reinicio
                        btn_guardar_opt2.Visible = txt_estructura_opt2.Visible = btn_copiar_opt2.Visible = btn_ejecutar_opt2.Visible = false;
                        ClsDatos.Desconectar();
                    }
                    else
                    {//ENVIAMOS EL VALOR RETORNADO AL OTRO FORMULARIO
                        String Cadena = ClsDatos.cadenaDatos(TipFuncion(squemaModelo, true));
                        txt_estructura.Text = Cadena;
                        if (Cadena.Length > 0) this.Size = new System.Drawing.Size(590, 804);
                    }
                    //CERRAMOS FORMULARIO DE MENSAJE
                    abrirCerrarFormulario(false);
                }
                //CERRAMOS FORMULARIO DE MENSAJE 
                abrirCerrarFormulario(false);

            }
        }
    }
}
