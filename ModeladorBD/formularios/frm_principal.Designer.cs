namespace BuscadorFuncionesTrigger.formularios
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.grbCadenaConec = new System.Windows.Forms.GroupBox();
            this.lbl_base_datos = new System.Windows.Forms.Label();
            this.btn_listar_esquemas = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.cmb_base_datos = new System.Windows.Forms.ComboBox();
            this.btn_mostrar = new System.Windows.Forms.Button();
            this.btnConexion = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lbl_nombre_fun_trig = new System.Windows.Forms.Label();
            this.txt_nom_func = new System.Windows.Forms.TextBox();
            this.btn_generar = new System.Windows.Forms.Button();
            this.rb_funcion = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb_trigger = new System.Windows.Forms.RadioButton();
            this.lbl_esquema = new System.Windows.Forms.Label();
            this.cmb_esquemas = new System.Windows.Forms.ComboBox();
            this.btn_desc = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.txt_estructura = new System.Windows.Forms.RichTextBox();
            this.btn_ejecutar = new System.Windows.Forms.Button();
            this.btn_copiar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_guardar_opt2 = new System.Windows.Forms.Button();
            this.cmb_funcion = new System.Windows.Forms.ComboBox();
            this.btn_buscar_en_lista = new System.Windows.Forms.Button();
            this.txt_estructura_opt2 = new System.Windows.Forms.RichTextBox();
            this.btn_ejecutar_opt2 = new System.Windows.Forms.Button();
            this.btn_copiar_opt2 = new System.Windows.Forms.Button();
            this.chk_busqueda = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grbCadenaConec.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCadenaConec
            // 
            this.grbCadenaConec.BackColor = System.Drawing.SystemColors.Info;
            this.grbCadenaConec.Controls.Add(this.lbl_base_datos);
            this.grbCadenaConec.Controls.Add(this.btn_listar_esquemas);
            this.grbCadenaConec.Controls.Add(this.btn_salir);
            this.grbCadenaConec.Controls.Add(this.cmb_base_datos);
            this.grbCadenaConec.Controls.Add(this.btn_mostrar);
            this.grbCadenaConec.Controls.Add(this.btnConexion);
            this.grbCadenaConec.Controls.Add(this.txtPass);
            this.grbCadenaConec.Controls.Add(this.lblPass);
            this.grbCadenaConec.Controls.Add(this.txtServidor);
            this.grbCadenaConec.Controls.Add(this.lblHost);
            this.grbCadenaConec.Controls.Add(this.txtPuerto);
            this.grbCadenaConec.Controls.Add(this.lblPuerto);
            this.grbCadenaConec.Controls.Add(this.txtUser);
            this.grbCadenaConec.Controls.Add(this.lblUser);
            this.grbCadenaConec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCadenaConec.Location = new System.Drawing.Point(1, 2);
            this.grbCadenaConec.Name = "grbCadenaConec";
            this.grbCadenaConec.Size = new System.Drawing.Size(572, 189);
            this.grbCadenaConec.TabIndex = 1;
            this.grbCadenaConec.TabStop = false;
            this.grbCadenaConec.Text = "Cadena Conexión";
            // 
            // lbl_base_datos
            // 
            this.lbl_base_datos.AutoSize = true;
            this.lbl_base_datos.BackColor = System.Drawing.SystemColors.Info;
            this.lbl_base_datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_base_datos.Location = new System.Drawing.Point(148, 132);
            this.lbl_base_datos.Name = "lbl_base_datos";
            this.lbl_base_datos.Size = new System.Drawing.Size(115, 20);
            this.lbl_base_datos.TabIndex = 10;
            this.lbl_base_datos.Text = "Base de Datos";
            this.lbl_base_datos.Visible = false;
            // 
            // btn_listar_esquemas
            // 
            this.btn_listar_esquemas.Location = new System.Drawing.Point(388, 155);
            this.btn_listar_esquemas.Name = "btn_listar_esquemas";
            this.btn_listar_esquemas.Size = new System.Drawing.Size(145, 29);
            this.btn_listar_esquemas.TabIndex = 12;
            this.btn_listar_esquemas.Text = "Listar Esquemas";
            this.btn_listar_esquemas.UseVisualStyleBackColor = true;
            this.btn_listar_esquemas.Visible = false;
            this.btn_listar_esquemas.Click += new System.EventHandler(this.btn_listar_esquemas_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.AutoSize = true;
            this.btn_salir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_salir.Location = new System.Drawing.Point(526, 12);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(44, 42);
            this.btn_salir.TabIndex = 13;
            this.btn_salir.Text = "X";
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // cmb_base_datos
            // 
            this.cmb_base_datos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_base_datos.FormattingEnabled = true;
            this.cmb_base_datos.Location = new System.Drawing.Point(28, 155);
            this.cmb_base_datos.Name = "cmb_base_datos";
            this.cmb_base_datos.Size = new System.Drawing.Size(354, 28);
            this.cmb_base_datos.TabIndex = 11;
            this.cmb_base_datos.Visible = false;
            // 
            // btn_mostrar
            // 
            this.btn_mostrar.Location = new System.Drawing.Point(537, 57);
            this.btn_mostrar.Name = "btn_mostrar";
            this.btn_mostrar.Size = new System.Drawing.Size(33, 29);
            this.btn_mostrar.TabIndex = 8;
            this.btn_mostrar.Text = "O";
            this.btn_mostrar.UseVisualStyleBackColor = true;
            this.btn_mostrar.Click += new System.EventHandler(this.btn_mostrar_Click);
            // 
            // btnConexion
            // 
            this.btnConexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnConexion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConexion.Location = new System.Drawing.Point(140, 92);
            this.btnConexion.Name = "btnConexion";
            this.btnConexion.Size = new System.Drawing.Size(320, 27);
            this.btnConexion.TabIndex = 9;
            this.btnConexion.Text = "Conectar";
            this.btnConexion.UseVisualStyleBackColor = false;
            this.btnConexion.Click += new System.EventHandler(this.btnConexion_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(383, 58);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(153, 26);
            this.txtPass.TabIndex = 7;
            this.txtPass.Text = "parqueabeja";
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(287, 61);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(92, 20);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Contraseña";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(97, 27);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(170, 26);
            this.txtServidor.TabIndex = 1;
            this.txtServidor.Text = "192.168.0.161";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(16, 30);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(67, 20);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Servidor";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(383, 27);
            this.txtPuerto.MaxLength = 6;
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(86, 26);
            this.txtPuerto.TabIndex = 3;
            this.txtPuerto.Text = "5432";
            this.txtPuerto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPuerto_KeyPress);
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Location = new System.Drawing.Point(287, 30);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(56, 20);
            this.lblPuerto.TabIndex = 2;
            this.lblPuerto.Text = "Puerto";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(97, 58);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(170, 26);
            this.txtUser.TabIndex = 5;
            this.txtUser.Text = "postgres";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(16, 61);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(64, 20);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Usuario";
            // 
            // lbl_nombre_fun_trig
            // 
            this.lbl_nombre_fun_trig.AutoSize = true;
            this.lbl_nombre_fun_trig.BackColor = System.Drawing.SystemColors.Info;
            this.lbl_nombre_fun_trig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombre_fun_trig.Location = new System.Drawing.Point(20, 268);
            this.lbl_nombre_fun_trig.Name = "lbl_nombre_fun_trig";
            this.lbl_nombre_fun_trig.Size = new System.Drawing.Size(214, 20);
            this.lbl_nombre_fun_trig.TabIndex = 5;
            this.lbl_nombre_fun_trig.Text = "Nombre de Función o Trigger";
            // 
            // txt_nom_func
            // 
            this.txt_nom_func.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nom_func.Location = new System.Drawing.Point(24, 291);
            this.txt_nom_func.Name = "txt_nom_func";
            this.txt_nom_func.Size = new System.Drawing.Size(334, 26);
            this.txt_nom_func.TabIndex = 6;
            this.txt_nom_func.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nom_func_KeyPress);
            // 
            // btn_generar
            // 
            this.btn_generar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_generar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generar.Location = new System.Drawing.Point(363, 287);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(81, 35);
            this.btn_generar.TabIndex = 7;
            this.btn_generar.Text = "Buscar";
            this.btn_generar.UseVisualStyleBackColor = false;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // rb_funcion
            // 
            this.rb_funcion.Checked = true;
            this.rb_funcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_funcion.Location = new System.Drawing.Point(6, 17);
            this.rb_funcion.Name = "rb_funcion";
            this.rb_funcion.Size = new System.Drawing.Size(84, 24);
            this.rb_funcion.TabIndex = 0;
            this.rb_funcion.TabStop = true;
            this.rb_funcion.Text = "Función ";
            this.rb_funcion.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_trigger);
            this.groupBox3.Controls.Add(this.rb_funcion);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(24, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 44);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipo";
            // 
            // rb_trigger
            // 
            this.rb_trigger.AutoSize = true;
            this.rb_trigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_trigger.Location = new System.Drawing.Point(92, 17);
            this.rb_trigger.Name = "rb_trigger";
            this.rb_trigger.Size = new System.Drawing.Size(76, 24);
            this.rb_trigger.TabIndex = 1;
            this.rb_trigger.Text = "Trigger";
            this.rb_trigger.UseVisualStyleBackColor = true;
            // 
            // lbl_esquema
            // 
            this.lbl_esquema.AutoSize = true;
            this.lbl_esquema.BackColor = System.Drawing.SystemColors.Info;
            this.lbl_esquema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_esquema.Location = new System.Drawing.Point(294, 219);
            this.lbl_esquema.Name = "lbl_esquema";
            this.lbl_esquema.Size = new System.Drawing.Size(77, 20);
            this.lbl_esquema.TabIndex = 3;
            this.lbl_esquema.Text = "Esquema";
            // 
            // cmb_esquemas
            // 
            this.cmb_esquemas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_esquemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_esquemas.FormattingEnabled = true;
            this.cmb_esquemas.Location = new System.Drawing.Point(375, 215);
            this.cmb_esquemas.Name = "cmb_esquemas";
            this.cmb_esquemas.Size = new System.Drawing.Size(183, 28);
            this.cmb_esquemas.TabIndex = 4;
            // 
            // btn_desc
            // 
            this.btn_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_desc.Location = new System.Drawing.Point(444, 287);
            this.btn_desc.Name = "btn_desc";
            this.btn_desc.Size = new System.Drawing.Size(119, 35);
            this.btn_desc.TabIndex = 8;
            this.btn_desc.Text = "Desconectar";
            this.btn_desc.UseVisualStyleBackColor = true;
            this.btn_desc.Click += new System.EventHandler(this.btn_desc_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(18, 328);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(541, 426);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_guardar);
            this.tabPage1.Controls.Add(this.txt_estructura);
            this.tabPage1.Controls.Add(this.btn_ejecutar);
            this.tabPage1.Controls.Add(this.btn_copiar);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(533, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Texto de Función";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar.Location = new System.Drawing.Point(325, 3);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(108, 27);
            this.btn_guardar.TabIndex = 3;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // txt_estructura
            // 
            this.txt_estructura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_estructura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_estructura.Location = new System.Drawing.Point(6, 32);
            this.txt_estructura.Name = "txt_estructura";
            this.txt_estructura.Size = new System.Drawing.Size(520, 358);
            this.txt_estructura.TabIndex = 0;
            this.txt_estructura.Text = "";
            // 
            // btn_ejecutar
            // 
            this.btn_ejecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ejecutar.Location = new System.Drawing.Point(211, 3);
            this.btn_ejecutar.Name = "btn_ejecutar";
            this.btn_ejecutar.Size = new System.Drawing.Size(108, 27);
            this.btn_ejecutar.TabIndex = 2;
            this.btn_ejecutar.Text = "Ejecutar";
            this.btn_ejecutar.UseVisualStyleBackColor = true;
            // 
            // btn_copiar
            // 
            this.btn_copiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_copiar.Location = new System.Drawing.Point(97, 3);
            this.btn_copiar.Name = "btn_copiar";
            this.btn_copiar.Size = new System.Drawing.Size(108, 27);
            this.btn_copiar.TabIndex = 1;
            this.btn_copiar.Text = "Copiar Texto";
            this.btn_copiar.UseVisualStyleBackColor = true;
            this.btn_copiar.Click += new System.EventHandler(this.btn_copiar_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_guardar_opt2);
            this.tabPage2.Controls.Add(this.cmb_funcion);
            this.tabPage2.Controls.Add(this.btn_buscar_en_lista);
            this.tabPage2.Controls.Add(this.txt_estructura_opt2);
            this.tabPage2.Controls.Add(this.btn_ejecutar_opt2);
            this.tabPage2.Controls.Add(this.btn_copiar_opt2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(533, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lista de Funciones y texto";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_guardar_opt2
            // 
            this.btn_guardar_opt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar_opt2.Location = new System.Drawing.Point(349, 84);
            this.btn_guardar_opt2.Name = "btn_guardar_opt2";
            this.btn_guardar_opt2.Size = new System.Drawing.Size(108, 27);
            this.btn_guardar_opt2.TabIndex = 5;
            this.btn_guardar_opt2.Text = "Guardar";
            this.btn_guardar_opt2.UseVisualStyleBackColor = true;
            this.btn_guardar_opt2.Visible = false;
            this.btn_guardar_opt2.Click += new System.EventHandler(this.btn_guardar_opt2_Click);
            // 
            // cmb_funcion
            // 
            this.cmb_funcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_funcion.FormattingEnabled = true;
            this.cmb_funcion.Location = new System.Drawing.Point(40, 11);
            this.cmb_funcion.Name = "cmb_funcion";
            this.cmb_funcion.Size = new System.Drawing.Size(475, 28);
            this.cmb_funcion.TabIndex = 0;
            // 
            // btn_buscar_en_lista
            // 
            this.btn_buscar_en_lista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_buscar_en_lista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar_en_lista.Location = new System.Drawing.Point(198, 44);
            this.btn_buscar_en_lista.Name = "btn_buscar_en_lista";
            this.btn_buscar_en_lista.Size = new System.Drawing.Size(151, 35);
            this.btn_buscar_en_lista.TabIndex = 1;
            this.btn_buscar_en_lista.Text = "Cargar Texto";
            this.btn_buscar_en_lista.UseVisualStyleBackColor = false;
            this.btn_buscar_en_lista.Click += new System.EventHandler(this.btn_buscar_en_lista_Click);
            // 
            // txt_estructura_opt2
            // 
            this.txt_estructura_opt2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_estructura_opt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_estructura_opt2.Location = new System.Drawing.Point(6, 114);
            this.txt_estructura_opt2.Name = "txt_estructura_opt2";
            this.txt_estructura_opt2.Size = new System.Drawing.Size(520, 270);
            this.txt_estructura_opt2.TabIndex = 2;
            this.txt_estructura_opt2.Text = "";
            // 
            // btn_ejecutar_opt2
            // 
            this.btn_ejecutar_opt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ejecutar_opt2.Location = new System.Drawing.Point(233, 84);
            this.btn_ejecutar_opt2.Name = "btn_ejecutar_opt2";
            this.btn_ejecutar_opt2.Size = new System.Drawing.Size(108, 27);
            this.btn_ejecutar_opt2.TabIndex = 4;
            this.btn_ejecutar_opt2.Text = "Ejecutar";
            this.btn_ejecutar_opt2.UseVisualStyleBackColor = true;
            // 
            // btn_copiar_opt2
            // 
            this.btn_copiar_opt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_copiar_opt2.Location = new System.Drawing.Point(119, 84);
            this.btn_copiar_opt2.Name = "btn_copiar_opt2";
            this.btn_copiar_opt2.Size = new System.Drawing.Size(108, 27);
            this.btn_copiar_opt2.TabIndex = 3;
            this.btn_copiar_opt2.Text = "Copiar Texto";
            this.btn_copiar_opt2.UseVisualStyleBackColor = true;
            this.btn_copiar_opt2.Click += new System.EventHandler(this.btn_copiar_opt2_Click);
            // 
            // chk_busqueda
            // 
            this.chk_busqueda.AutoSize = true;
            this.chk_busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_busqueda.Location = new System.Drawing.Point(24, 239);
            this.chk_busqueda.Name = "chk_busqueda";
            this.chk_busqueda.Size = new System.Drawing.Size(250, 24);
            this.chk_busqueda.TabIndex = 0;
            this.chk_busqueda.Text = "Buscar Funciones Por Palabras";
            this.chk_busqueda.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "Text files (*.sql)|*.sql|All files (*.*)|*.*";
            this.saveFileDialog1.Filter = "Text files (*.sql)|*.sql|All files (*.*)|*.*";
            // 
            // frm_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(574, 766);
            this.ControlBox = false;
            this.Controls.Add(this.chk_busqueda);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_desc);
            this.Controls.Add(this.lbl_nombre_fun_trig);
            this.Controls.Add(this.txt_nom_func);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbl_esquema);
            this.Controls.Add(this.cmb_esquemas);
            this.Controls.Add(this.grbCadenaConec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscador -- Panel Control";
            this.grbCadenaConec.ResumeLayout(false);
            this.grbCadenaConec.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grbCadenaConec;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btnConexion;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btn_mostrar;
        private System.Windows.Forms.Label lbl_base_datos;
        private System.Windows.Forms.Button btn_listar_esquemas;
        private System.Windows.Forms.ComboBox cmb_base_datos;
        private System.Windows.Forms.Label lbl_nombre_fun_trig;
        private System.Windows.Forms.TextBox txt_nom_func;
        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.RadioButton rb_funcion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rb_trigger;
        private System.Windows.Forms.Label lbl_esquema;
        private System.Windows.Forms.ComboBox cmb_esquemas;
        private System.Windows.Forms.Button btn_desc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox txt_estructura;
        private System.Windows.Forms.Button btn_ejecutar;
        private System.Windows.Forms.Button btn_copiar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chk_busqueda;
        private System.Windows.Forms.RichTextBox txt_estructura_opt2;
        private System.Windows.Forms.Button btn_ejecutar_opt2;
        private System.Windows.Forms.Button btn_copiar_opt2;
        private System.Windows.Forms.Button btn_buscar_en_lista;
        private System.Windows.Forms.ComboBox cmb_funcion;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_guardar_opt2;
    }
}