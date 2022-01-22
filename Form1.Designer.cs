
namespace ProyectoCompilador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcAnalizador = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listViewToken = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pbArbol = new System.Windows.Forms.PictureBox();
            this.btnLexico = new System.Windows.Forms.Button();
            this.btnSintactico = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLenguaje = new System.Windows.Forms.TextBox();
            this.btnDirectorio = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeCompEdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verLaAyudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemploDeCódigoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.javaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.blackCatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.paToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxSalir = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PagCodigo = new System.Windows.Forms.RichTextBox();
            this.tcCodigo = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxLenguaje = new System.Windows.Forms.CheckedListBox();
            this.tcAnalizador.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArbol)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSalir)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tcCodigo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcAnalizador
            // 
            this.tcAnalizador.Controls.Add(this.tabPage3);
            this.tcAnalizador.Controls.Add(this.tabPage4);
            this.tcAnalizador.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAnalizador.Location = new System.Drawing.Point(462, 78);
            this.tcAnalizador.Name = "tcAnalizador";
            this.tcAnalizador.SelectedIndex = 0;
            this.tcAnalizador.Size = new System.Drawing.Size(576, 445);
            this.tcAnalizador.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listViewToken);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(568, 416);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Tabla de Simbolos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listViewToken
            // 
            this.listViewToken.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewToken.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewToken.HideSelection = false;
            this.listViewToken.Location = new System.Drawing.Point(7, 17);
            this.listViewToken.Name = "listViewToken";
            this.listViewToken.Size = new System.Drawing.Size(553, 383);
            this.listViewToken.TabIndex = 0;
            this.listViewToken.UseCompatibleStateImageBehavior = false;
            this.listViewToken.View = System.Windows.Forms.View.Details;
            this.listViewToken.SelectedIndexChanged += new System.EventHandler(this.PagCodigo_TextChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Token";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Lexema";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Linea";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Columna";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Indice";
            this.columnHeader5.Width = 120;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pbArbol);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(568, 416);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Árbol Sintactico";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pbArbol
            // 
            this.pbArbol.Location = new System.Drawing.Point(27, 18);
            this.pbArbol.Name = "pbArbol";
            this.pbArbol.Size = new System.Drawing.Size(522, 375);
            this.pbArbol.TabIndex = 0;
            this.pbArbol.TabStop = false;
            // 
            // btnLexico
            // 
            this.btnLexico.BackColor = System.Drawing.Color.Transparent;
            this.btnLexico.BackgroundImage = global::ProyectoCompilador.Properties.Resources.lexico2;
            this.btnLexico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLexico.Location = new System.Drawing.Point(363, 42);
            this.btnLexico.Name = "btnLexico";
            this.btnLexico.Size = new System.Drawing.Size(93, 85);
            this.btnLexico.TabIndex = 4;
            this.btnLexico.UseVisualStyleBackColor = false;
            this.btnLexico.Click += new System.EventHandler(this.btnLexico_Click);
            // 
            // btnSintactico
            // 
            this.btnSintactico.BackColor = System.Drawing.Color.White;
            this.btnSintactico.BackgroundImage = global::ProyectoCompilador.Properties.Resources.sintactico3;
            this.btnSintactico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSintactico.Location = new System.Drawing.Point(363, 194);
            this.btnSintactico.Name = "btnSintactico";
            this.btnSintactico.Size = new System.Drawing.Size(93, 87);
            this.btnSintactico.TabIndex = 5;
            this.btnSintactico.UseVisualStyleBackColor = false;
            this.btnSintactico.Click += new System.EventHandler(this.btnSintactico_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLenguaje);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 239);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Palabras reservadas";
            // 
            // txtLenguaje
            // 
            this.txtLenguaje.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLenguaje.Location = new System.Drawing.Point(0, 26);
            this.txtLenguaje.Multiline = true;
            this.txtLenguaje.Name = "txtLenguaje";
            this.txtLenguaje.Size = new System.Drawing.Size(356, 213);
            this.txtLenguaje.TabIndex = 7;
            // 
            // btnDirectorio
            // 
            this.btnDirectorio.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectorio.Location = new System.Drawing.Point(462, 42);
            this.btnDirectorio.Name = "btnDirectorio";
            this.btnDirectorio.Size = new System.Drawing.Size(84, 30);
            this.btnDirectorio.TabIndex = 7;
            this.btnDirectorio.Text = "Directorio";
            this.btnDirectorio.UseVisualStyleBackColor = true;
            this.btnDirectorio.Click += new System.EventHandler(this.btnDirectorio_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(552, 42);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(236, 30);
            this.txtPath.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.borrarDatosToolStripMenuItem,
            this.ejemploDeCódigoToolStripMenuItem1,
            this.paToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6);
            this.menuStrip1.Size = new System.Drawing.Size(1054, 35);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.archivoToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.archivoToolStripMenuItem.Image = global::ProyectoCompilador.Properties.Resources.folder;
            this.archivoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(84, 23);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.abrirToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.abrirToolStripMenuItem.Image = global::ProyectoCompilador.Properties.Resources.open_alt;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guardarToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guardarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.guardarToolStripMenuItem.Image = global::ProyectoCompilador.Properties.Resources.floppydisc;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeCompEdToolStripMenuItem,
            this.verLaAyudaToolStripMenuItem});
            this.ayudaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ayudaToolStripMenuItem.ForeColor = System.Drawing.Color.LightGray;
            this.ayudaToolStripMenuItem.Image = global::ProyectoCompilador.Properties.Resources.help;
            this.ayudaToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(76, 23);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeCompEdToolStripMenuItem
            // 
            this.acercaDeCompEdToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.acercaDeCompEdToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.acercaDeCompEdToolStripMenuItem.Image = global::ProyectoCompilador.Properties.Resources.iconoCom;
            this.acercaDeCompEdToolStripMenuItem.Name = "acercaDeCompEdToolStripMenuItem";
            this.acercaDeCompEdToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.acercaDeCompEdToolStripMenuItem.Text = "Acerca del Compilador";
            this.acercaDeCompEdToolStripMenuItem.Click += new System.EventHandler(this.acercaDeCompEdToolStripMenuItem_Click);
            // 
            // verLaAyudaToolStripMenuItem
            // 
            this.verLaAyudaToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlText;
            this.verLaAyudaToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.verLaAyudaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.verLaAyudaToolStripMenuItem.Image = global::ProyectoCompilador.Properties.Resources.help;
            this.verLaAyudaToolStripMenuItem.Name = "verLaAyudaToolStripMenuItem";
            this.verLaAyudaToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.verLaAyudaToolStripMenuItem.Text = "Ver la ayuda";
            this.verLaAyudaToolStripMenuItem.Click += new System.EventHandler(this.verLaAyudaToolStripMenuItem_Click);
            // 
            // borrarDatosToolStripMenuItem
            // 
            this.borrarDatosToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.borrarDatosToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrarDatosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.borrarDatosToolStripMenuItem.Image = global::ProyectoCompilador.Properties.Resources.eraseIcon;
            this.borrarDatosToolStripMenuItem.Name = "borrarDatosToolStripMenuItem";
            this.borrarDatosToolStripMenuItem.Size = new System.Drawing.Size(112, 23);
            this.borrarDatosToolStripMenuItem.Text = "Borrar Datos";
            this.borrarDatosToolStripMenuItem.Click += new System.EventHandler(this.borrarDatosToolStripMenuItem_Click);
            // 
            // ejemploDeCódigoToolStripMenuItem1
            // 
            this.ejemploDeCódigoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.javaToolStripMenuItem1,
            this.blackCatToolStripMenuItem1});
            this.ejemploDeCódigoToolStripMenuItem1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ejemploDeCódigoToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Window;
            this.ejemploDeCódigoToolStripMenuItem1.Image = global::ProyectoCompilador.Properties.Resources.iconoEjemplo;
            this.ejemploDeCódigoToolStripMenuItem1.Name = "ejemploDeCódigoToolStripMenuItem1";
            this.ejemploDeCódigoToolStripMenuItem1.Size = new System.Drawing.Size(147, 23);
            this.ejemploDeCódigoToolStripMenuItem1.Text = "Ejemplo de código";
            // 
            // javaToolStripMenuItem1
            // 
            this.javaToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.javaToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Window;
            this.javaToolStripMenuItem1.Image = global::ProyectoCompilador.Properties.Resources.java;
            this.javaToolStripMenuItem1.Name = "javaToolStripMenuItem1";
            this.javaToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.javaToolStripMenuItem1.Text = "Java";
            this.javaToolStripMenuItem1.Click += new System.EventHandler(this.javaToolStripMenuItem1_Click);
            // 
            // blackCatToolStripMenuItem1
            // 
            this.blackCatToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.blackCatToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Window;
            this.blackCatToolStripMenuItem1.Image = global::ProyectoCompilador.Properties.Resources.iconoBlackCat;
            this.blackCatToolStripMenuItem1.Name = "blackCatToolStripMenuItem1";
            this.blackCatToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.blackCatToolStripMenuItem1.Text = "BlackCat";
            this.blackCatToolStripMenuItem1.Click += new System.EventHandler(this.blackCatToolStripMenuItem1_Click);
            // 
            // paToolStripMenuItem
            // 
            this.paToolStripMenuItem.Name = "paToolStripMenuItem";
            this.paToolStripMenuItem.Size = new System.Drawing.Size(32, 23);
            this.paToolStripMenuItem.Text = "Pa";
            // 
            // pictureBoxSalir
            // 
            this.pictureBoxSalir.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxSalir.Image = global::ProyectoCompilador.Properties.Resources.ic_power;
            this.pictureBoxSalir.Location = new System.Drawing.Point(1015, 4);
            this.pictureBoxSalir.Name = "pictureBoxSalir";
            this.pictureBoxSalir.Size = new System.Drawing.Size(27, 24);
            this.pictureBoxSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSalir.TabIndex = 10;
            this.pictureBoxSalir.TabStop = false;
            this.pictureBoxSalir.Click += new System.EventHandler(this.pictureBoxSalir_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PagCodigo);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(419, 207);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Código";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PagCodigo
            // 
            this.PagCodigo.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PagCodigo.Location = new System.Drawing.Point(0, 0);
            this.PagCodigo.Name = "PagCodigo";
            this.PagCodigo.Size = new System.Drawing.Size(433, 210);
            this.PagCodigo.TabIndex = 0;
            this.PagCodigo.Text = "";
            this.PagCodigo.TextChanged += new System.EventHandler(this.PagCodigo_TextChanged);
            this.PagCodigo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PagCodigo_MouseDown);
            // 
            // tcCodigo
            // 
            this.tcCodigo.Controls.Add(this.tabPage1);
            this.tcCodigo.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcCodigo.Location = new System.Drawing.Point(8, 287);
            this.tcCodigo.Name = "tcCodigo";
            this.tcCodigo.SelectedIndex = 0;
            this.tcCodigo.Size = new System.Drawing.Size(427, 236);
            this.tcCodigo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 545);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 11;
            // 
            // listBoxLenguaje
            // 
            this.listBoxLenguaje.CheckOnClick = true;
            this.listBoxLenguaje.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLenguaje.FormattingEnabled = true;
            this.listBoxLenguaje.Location = new System.Drawing.Point(914, 42);
            this.listBoxLenguaje.Name = "listBoxLenguaje";
            this.listBoxLenguaje.Size = new System.Drawing.Size(120, 38);
            this.listBoxLenguaje.TabIndex = 13;
            this.listBoxLenguaje.SelectedIndexChanged += new System.EventHandler(this.listBoxLenguaje_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoCompilador.Properties.Resources.fondoPrincipal;
            this.ClientSize = new System.Drawing.Size(1054, 570);
            this.ControlBox = false;
            this.Controls.Add(this.listBoxLenguaje);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxSalir);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnDirectorio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSintactico);
            this.Controls.Add(this.btnLexico);
            this.Controls.Add(this.tcAnalizador);
            this.Controls.Add(this.tcCodigo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Compilador";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcAnalizador.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbArbol)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSalir)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tcCodigo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tcAnalizador;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pbArbol;
        private System.Windows.Forms.Button btnLexico;
        private System.Windows.Forms.Button btnSintactico;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLenguaje;
        private System.Windows.Forms.Button btnDirectorio;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.ListView listViewToken;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeCompEdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verLaAyudaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxSalir;
        private System.Windows.Forms.ToolStripMenuItem borrarDatosToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox PagCodigo;
        private System.Windows.Forms.TabControl tcCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem paToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejemploDeCódigoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem javaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem blackCatToolStripMenuItem1;
        private System.Windows.Forms.CheckedListBox listBoxLenguaje;
    }
}

