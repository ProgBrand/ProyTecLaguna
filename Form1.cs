using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using ListViewItem = System.Windows.Forms.ListViewItem;
using ProyectoArbolBinario;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Threading;
using Application = System.Windows.Forms.Application;

namespace ProyectoCompilador
{
    /// <summary>
    /// Clase principal que muestra un compilador.
    /// Contiene eventos y métodos que nos permiten realizar el analicis léxico(tabla de simbolos) y sintáctico(generación del árbol).
    /// </summary>
    /// <remarks>
    /// <para>Con esta clase se puede abrir y guardar un archivo, muestra la ayuda del programa, un menú para borrar datos, un menú que 
    /// nos permite abrir un archivo con un ejemplo de código en lenguaje Java y lenguaje llamado BlackCat, por medio de botones realiza
    /// el analizador léxico y sintáctico, contiene un campo de texto para mostrar las palabras reservadas y un ckeck List para seleccionar
    /// el lenguaje que queremos usar.</para>
    /// </remarks>
    /// <supuestos>Para que esta clase funcione es necesario seleccionar un lenguaje "Java o BlackCat" e ingresar código para analizarlo.
    /// </supuestos>
    /// <Autor>
    /// 18131243 Gómez Montes Zaida Sugey 
    /// 18131279 Romero Vázquez Jesús
    /// 18131225 Castañeda Limones Carlos Elian
    /// </Autor>
    /// <FechaCreacion>Jueves 16 de septiembre del 2021
    /// </FechaCreacion>
    public partial class Form1 : Form
    {
        //************************************************************************************************************
        // Variables Locales
        //************************************************************************************************************
        #region VARIABLES LOCALES 
        private Nodo raiz;
        private Arbol arbol;
        Grafico grafico;
        string cadena = "";
        ListViewItem lex = new ListViewItem();
        #endregion

        public Form1()
        {
            //creamos un hilo
            Thread t = new Thread(new ThreadStart(SplashStart));

            //arrancamos el hilo
            t.Start();

            //ponemos a dormir la forma principal
            Thread.Sleep(7900);
            InitializeComponent();
            t.Abort();
            arbol = new Arbol();
        }

        //************************************************************************************************************
        // Variables locales
        //************************************************************************************************************
        #region VARIABLES LOCALES 
        RegexLexer csLexer = new RegexLexer();
        bool load;
        List<string> palabrasReservadas;
        private string Title;
        #endregion

        //************************************************************************************************************
        // Eventos
        //************************************************************************************************************
        #region EVENTOS 

        /// <summary>
        /// EVENTO CLICK DEL BOTON JAVA PARA ABRIR UN ARCHIVO CON LAS PALABRAS RESERVADAS:
        /// </summary>
        private void btnJava_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.Title = "Compilador                                                                    Abrir Archivo                                                                       ";
                ofd.ShowDialog();
                // ofd.Filter = "Archivos ed#(*.ed)|*.ed";
                if (File.Exists(ofd.FileName))
                {
                    using (Stream stream = ofd.OpenFile())
                    {
                        //MessageBox.Sh
                        leerArchivo(ofd.FileName);
                        //nomarchivox = ofd.FileName;

                        //txt_direccion.Text = ofd.FileName;
                        //tabControl1.Visible = true;
                    }
                }
            } catch(Exception){

                //MessageBox.Show("El archivo no se abrio correctamente");

            }

        }

        /// <summary>
        /// EVENTO PARA QUE EL TEXTO QUE SE INGRESE EN EL PagCodigo se modifique automáticamente.
        /// </summary>
        private void PagCodigo_TextChanged(object sender, EventArgs e)
        {
            if (load)
                AnalizeCode();
        }


        /// <summary>
        /// EVENTO DEL BOTON DEL ANALIZADOR LEXICO PARA MOSTRAR LA TABLA DE SIMBOLOS.
        /// </summary>
        private void btnLexico_Click(object sender, EventArgs e)
        {
            if(PagCodigo.Text != "")
            {
                using (StreamReader sr = new StreamReader(@"..\..\RegexLexer.cs"))
                {
                    //tbxCode.Text = sr.ReadToEnd();

                    csLexer.AddTokenRule(@"\s+", "ESPACIO", true);
                    csLexer.AddTokenRule(@"\b[_a-zA-Z][\w]*\b", "IDENTIFICADOR");
                    csLexer.AddTokenRule("\".*?\"", "CADENA");
                    csLexer.AddTokenRule(@"'\\.'|'[^\\]'", "CARACTER");
                    csLexer.AddTokenRule("//[^\r\n]*", "COMENTARIO1");
                    csLexer.AddTokenRule("/[*].*?[*]/", "COMENTARIO2");
                    csLexer.AddTokenRule(@"\d*\.?\d+", "NUMERO");
                    csLexer.AddTokenRule(@"[\(\)\{\}\[\];,]", "DELIMITADOR");
                    csLexer.AddTokenRule(@"[\.=\+\-/*%]", "OPERADOR_ARITMÉTICO");
                    csLexer.AddTokenRule(@">|<|==|>=|<=|!", "OPERADOR_LÓGICO");

                    if ((string)listBoxLenguaje.Items[listBoxLenguaje.SelectedIndex] == "Java")
                    {

                        palabrasReservadas = new List<string>() { "abstract", "as", "async", "await",
                "checked", "const", "continue", "default", "delegate", "base", "break", "case",
                "do", "else", "enum", "event", "explicit", "extern", "false", "finally",
                "fixed", "for", "foreach", "goto", "if", "implicit", "in", "interface",
                "internal", "is", "lock", "new", "null", "operator","catch",
                "out", "override", "params", "private", "protected", "public", "readonly",
                "ref", "return", "sealed", "sizeof", "stackalloc", "static",
                "switch", "this", "throw", "true", "try", "typeof", "namespace",
                "unchecked", "unsafe", "virtual", "void", "while", "float", "int", "long", "object",
                "get", "set", "new", "partial", "yield", "add", "remove", "value", "alias", "ascending",
                "descending", "from", "group", "into", "orderby", "select", "where",
                "join", "equals", "using","bool", "byte", "char", "decimal", "double", "dynamic",
                "sbyte", "short", "string", "uint", "ulong", "ushort", "var", "class", "struct" };

                    }
                    else if ((string)listBoxLenguaje.Items[listBoxLenguaje.SelectedIndex] == "BlackCat")
                    {
                        palabrasReservadas = new List<string>() { "abstracto", "como", "asincrono", "esperar",
                "comprobar", "constante", "seguir", "defecto", "delegar", "base", "romper", "caso",
                "hacer", "contrario", "enumeracion", "evento", "explicito", "externo", "falso", "finalmente",
                "reparar", "por", "porcada", "ir", "si", "implicito", "en", "interfaz",
                "interno", "es", "cerar", "nuevo", "nulo", "operador","captura",
                "fuera", "anular", "parametro", "privado", "protegido", "publico", "lectura",
                "arbitraria", "regresa", "sellado", "tamaño", "ampilar", "estatico",
                "cambio", "esto", "lanzar", "verdadero", "tratar", "tipo de", "nombre",
                "desenfrenado", "inseguro", "virtual", "vacio", "mientras", "flotador", "entero", "prolongar", "objeto",
                "obtener", "asignar", "nuevo", "parcial", "producir", "añadir", "borrar", "valor", "alias", "asendente",
                "desende ","desde", "grupo", "dentro", "ordenar", "seleccionar", "donde",
                "entrar", "igual", "utilizar","booleano", "byte", "caracter", "decimal", "doble", "dinamico",
                "sbyte", "corto", "cadena", "uentero", "ulargo", "ucorto", "var", "clase", "estructura", "desde", "grupo", "dentro", "ordenar", "seleccionar", "donde",
                "entrar", "igual", "utilizar","booleano", "byte", "caracter", "decimal", "doble", "dinamico",
                "sbyte", "corto", "cadena", "uentero", "ulargo", "ucorto", "var", "clase", "estructura" };
                    }
                    else
                    {
                        MessageBox.Show("No seleccionaste ningun lenguaje para " +
                                        "mostrar las palabras reservadas ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    csLexer.Compile(RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.ExplicitCapture);

                    load = true;
                    AnalizeCode();
                    PagCodigo.Focus();
                }

                tcAnalizador.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No se encontro código para realizar el analizador léxico. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// EVENTO CLICK DEL BOTÓN SINTÁCTICO PARA MOSTRAR EL ÁRBOL SINTÁCTICO
        /// </summary>
        private void btnSintactico_Click(object sender, EventArgs e)
        {
            
            if(PagCodigo.Text != "")
            {
                llamada(PagCodigo.Text);

                tcAnalizador.SelectedIndex = 1;
            }
            else{
                MessageBox.Show("No se encontro código para realizar el analizador semántico. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// EVENTO CLICK DEL BOTON "DIRECTORIO" PARA ABRIR ESPECIFICAR LA RUTA DEL USUARIO Y PODER GENERAR EL ÁRBOL
        /// </summary>
        private void btnDirectorio_Click(object sender, EventArgs e)
        {
            string rutaDirectorio = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                rutaDirectorio = fbd.SelectedPath;
            }
            txtPath.Text = rutaDirectorio;
        }

        /// <summary>
        /// EVENTO PARA ABRIR UN ARCHIVO
        /// </summary>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirarchivo();
        }

        /// <summary>
        /// EVENTO CLICK PARA BORRAR LOS DATOS DE LA TABLA DE SIMBOLOS, PALABRAS RESERVADAS Y CODIGO.
        /// </summary>
        private void borrarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Seguro que quieres BORRAR TODO sin guardar?", "ALERTA", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {

                txtLenguaje.Text = "";
                listViewToken.Items.Clear();

                PagCodigo.Text = "";

            }
        }

        /// <summary>
        /// EVENTO CLICK PARA GUARDAR UN ARCHIVO QUE VA A CONTENER LOS DATOS DE LA TABLA DE SIMBOLOS, PALABRAS RESERVADAS Y EL CODIGO.
        /// </summary>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "documento de texto|*.txt";
            guardar.Title = "GUARDAR COMO";
            guardar.FileName = "Sin titulo";
            var resultado = guardar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object line in PagCodigo.Lines)
                {
                    escribir.WriteLine(line);
                }
                escribir.Close();
            }
        }

        /// <summary>
        /// EVENTO CLICK DE UN PICTURE BOX PARA SALIR DE LA APLICACIÓN.
        /// </summary>
        private void pictureBoxSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// EVENTO CLICK PARA HABLAR SOBRE EL COMPILADOR Y MOSTRAR LA INFORMACIÓN DEL EQUIPO.
        /// </summary>
        private void acercaDeCompEdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Compilador basado en lenguaje C# para \n " +
                            "leer proyectos de programacion escritos en el lenguaje \n" +
                            "Java y un lenguaje creado llamado -> 'blackCat'.\n" +
                            "Información de los colaboradores:\n" +
                            "Instituto Tecnológico de la Laguna\n" +
                            "Lenguajes y Automatás II\n" +
                            "Equipo #1 - Integrantes:\n" +
                            "-Zaida Sugey Gómez Montes -#18131243\n" +
                            "-Jesús Romero Vázquez -#18131279\n" +
                            "-Carlos Elian Castañeda Limones- -#18131225\n" +
                            "-Brandon Daniel Salazar López -#18131281\n" +
                            "-Marian Areli Alfaro Garza -#18131213\n" +
                            "-Johan Ismael López Flores -#18130568", "Acerca del compilador", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// EVENTO CLICK PARA EXPLICAR COMO FUNCIONA EL COMPILADOR MOSTRANDO UNA PEQUEÑA AYUDA.
        /// </summary>
        private void verLaAyudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ayuda para el funcionamiento del Compilador\n" +
                "Este compilador esta basado en el lenguaje C# para leer proyectos\n" +
                "de programación escritos en el lenguaje Java y un lenguaje llamado\n " +
                "BlackCat.\n" +
                "Este compilador cuenta con un menu de archivos que nos permite abrir y guardar los datos\n" +
                "de las palabras reservadas, el código que haya digitalizado el usuario y la información de\n" +
                "la tabla de simbolos.\n" +
                "Cuenta con otro menú de Ayuda, donde nos permite ver la información del compilador\n, " +
                "y los datos personales de los colaboradores. De igual forma cuenta con un apartado\n" +
                "para ver la ayuda el compilador y conocer su funcionamiento.\n" +
                "También tiene un boton para borrar los datos.\n" +
                "Además contiene un menú donde nos facilita un ejemplo de código del lenguaje Java \n" +
                "y BlackCat.\n" +
                "Este compilador tiene dos botones que realiza el análisis Léxico(muestra la tabla de simbolos)\n" +
                "y un analizador semántico(muestra un árbol semántico según la línea que seleccione el usuario\n" +
                "con el mouse).\n" +
                "Y por último, un botón para cerrar la aplicación. ", "Acerca del compilador", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// EVENTO CLICK PARA CAMBIAR LA SELECCION DEL INDICE DEL LIST BOX
        /// </summary>
        private void listBoxLenguaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxLenguaje.SelectedIndex;
            int count = listBoxLenguaje.Items.Count;
            for (int x = 0; x < count; x++)
            {
                if (index != x)
                {
                    listBoxLenguaje.SetItemChecked(x, false);
                    
                }
                
            }

            listBoxLenguaje.SelectedIndex = index ;

            if ((string)listBoxLenguaje.Items[listBoxLenguaje.SelectedIndex] == "Java")
            {
                
                txtLenguaje.Text =
                "abstract\r\n" + "as\r\n" + "async\r\n" + "await\r\n" +
                "checked\r\n" + "const\r\n" + "continue\r\n" + "default\r\n" + "delegate\r\n" + "base\r\n" + "break\r\n" + "case\r\n" +
                "do\r\n" + "else\r\n" + "enum\r\n" + "event\r\n" + "explicit\r\n" + "extern\r\n" + "false\r\n" + "finally\r\n" +
                "fixed\r\n" + "for\r\n" + "foreach\r\n" + "goto\r\n" + "if\r\n" + "implicit\r\n" + "in\r\n" + "interface\r\n" +
                "internal\r\n" + "is\r\n" + "lock\r\n" + "new\r\n" + "null\r\n" + "operator\r\n" + "catch\r\n" +
                "out\r\n" + "override\r\n" + "params\r\n" + "private\r\n" + "protected\r\n" + "public\r\n" + "readonly\r\n" +
                "ref\r\n" + "return\r\n" + "sealed\r\n" + "sizeof\r\n" + "stackalloc\r\n" + "static\r\n" +
                "switch\r\n" + "this\r\n" + "throw\r\n" + "true\r\n" + "try\r\n" + "typeof\r\n" + "namespace\r\n" +
                "unchecked\r\n" + "unsafe\r\n" + "virtual\r\n" + "void\r\n" + "while\r\n" + "float\r\n" + "int\r\n" + "long\r\n" + "object\r\n" +
                "get\r\n" + "set\r\n" + "new\r\n" + "partial\r\n" + "yield\r\n" + "add\r\n" + "remove\r\n" + "value\r\n" + "alias\r\n" + "ascending\r\n" +
                "descending\r\n" + "from\r\n" + "group\r\n" + "into\r\n" + "orderby\r\n" + "select\r\n" + "where\r\n" +
                "join\r\n" + "equals\r\n" + "using\r\n" + "bool\r\n" + "byte\r\n" + "char\r\n" + "decimal\r\n" + "double\r\n" + "dynamic\r\n" +
                "sbyte\r\n" + "short\r\n" + "String\r\n" + "uint\r\n" + "ulong\r\n" + "ushort\r\n" + "var\r\n" + "class\r\n" + "struct\r\n";
            }

            else if ((string)listBoxLenguaje.Items[listBoxLenguaje.SelectedIndex] == "BlackCat")
            {
                
                txtLenguaje.Text =
                "abstracto\r\n" + "como\r\n" + "asincrono\r\n" + "esperar\r\n" +
                "comprobar\r\n" + "constante\r\n" + "seguir\r\n" + "defecto\r\n" + "delegar\r\n" + "base\r\n" + "romper\r\n" + "caso\r\n" +
                "hacer\r\n" + "contrario\r\n" + "enumeracion\r\n" + "evento\r\n" + "explicito\r\n" + "externo\r\n" + "falso\r\n" + "finalmente\r\n" +
                "reparar\r\n" + "por\r\n" + "porcada\r\n" + "ir\r\n" + "si\r\n" + "implicito\r\n" + "en\r\n" + "interfaz\r\n" +
                "interno\r\n" + "es\r\n" + "cerar\r\n" + "nuevo\r\n" + "nulo\r\n" + "operador\r\n" + "captura\r\n" +
                "fuera\r\n" + "anular\r\n" + "parametro\r\n" + "privado\r\n" + "protegido\r\n" + "publico\r\n" + "lectura\r\n" +
                "arbitraria\r\n" + "regresa\r\n" + "sellado\r\n" + "tamaño\r\n" + "ampilar\r\n" + "estatico\r\n" +
                "cambio\r\n" + "esto\r\n" + "lanzar\r\n" + "verdadero\r\n" + "tratar\r\n" + "tipo de\r\n" + "nombre\r\n" +
                "desenfrenado\r\n" + "inseguro\r\n" + "virtual\r\n" + "vacio\r\n" + "mientras\r\n" + "flotador\r\n" + "entero\r\n" + "prolongar\r\n" + "objeto\r\n" +
                "obtener\r\n" + "asignar\r\n" + "nuevo\r\n" + "parcial\r\n" + "producir\r\n" + "añadir\r\n" + "borrar\r\n" + "valor\r\n" + "alias\r\n" + "asendente\r\n" +
                "desende \r\n" + "desde\r\n" + "grupo\r\n" + "dentro\r\n" + "ordenar\r\n" + "seleccionar\r\n" + "donde\r\n" +
                "entrar\r\n" + "igual\r\n" + "utilizar\r\n" + "booleano\r\n" + "byte\r\n" + "caracter\r\n" + "decimal\r\n" + "doble\r\n" + "dinamico\r\n" +
                "sbyte\r\n" + "corto\r\n" + "cadena\r\n" + "uentero\r\n" + "ulargo\r\n" + "ucorto\r\n" + "var\r\n" + "clase\r\n" + "estructura\r\n" + "desde\r\n" + "grupo\r\n" + "dentro\r\n" + "ordenar\r\n" + "seleccionar\r\n" + "donde\r\n" +
                "entrar\r\n" + "igual\r\n" + "utilizar\r\n" + "booleano\r\n" + "byte\r\n" + "caracter\r\n" + "decimal\r\n" + "doble\r\n" + "dinamico\r\n" +
                "sbyte\r\n" + "corto\r\n" + "cadena\r\n" + "uentero\r\n" + "ulargo\r\n" + "ucorto\r\n" + "var\r\n" + "clase\r\n" + "estructura";
            }


        }

        /// <summary>
        /// EVENTO CLICK PARA ABRIR UN ARCHIVO TXT CON UN EJEMPLO EN JAVA 
        /// </summary>
        private void javaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "ABRIR ARCHIVO";
                ofd.ShowDialog();
                if (File.Exists(ofd.FileName))
                {
                    using (Stream stream = ofd.OpenFile())
                    {
                        leerarchivo(ofd.FileName);
                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("El archivo no se abrio correctamente");


            }

        }

        /// <summary>
        /// EVENTO DEL MOUSE PARA CUANDO EL USUARIO SELECCIONE UNA LINEA DEL CODIGO Y SE GENERE EL ARBOL
        /// </summary>
        private void PagCodigo_MouseDown(object sender, MouseEventArgs e)
        {
            string codigo = "";
            int lineaCodigo = this.PagCodigo.GetLineFromCharIndex(this.PagCodigo.SelectionStart);
      
            if (lineaCodigo != 0)
            {
                codigo = PagCodigo.Lines.ElementAt(lineaCodigo);
                llamada(codigo);
            }

        }
        
        /// <summary>
        /// EVENTO DE CARGA DEL FORMULARIO PARA QUE SE AGREGUEN LOS ITEMS AL LIST BOX Y CAMBIE EL INDICE.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxLenguaje.Items.Add("Java");
            listBoxLenguaje.Items.Add("BlackCat");
            
           // this.listBoxLenguaje_SelectedIndexChanged(sender, e);

        }

        /// <summary>
        /// EVENTO CLICK PARA ABRIR UN ARCHIVO TXT CON UN EJEMPLO EN EL LENGUAJE BLACKCAT
        /// </summary>
        private void blackCatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "ABRIR ARCHIVO";
                ofd.ShowDialog();
                if (File.Exists(ofd.FileName))
                {
                    using (Stream stream = ofd.OpenFile())
                    {
                        leerarchivo(ofd.FileName);
                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("El archivo no se abrio correctamente");


            }
        }
        #endregion

        //************************************************************************************************************
        // METODOS
        //************************************************************************************************************
        #region METODOS
        
        /// <summary>
        /// MÉTODO PARA INICIAR EL FORMULARIO DONDE SE ENCUENTRA EL SPLASH
        /// </summary>
        public void SplashStart()
        {
            Application.Run(new Splash());
        }

        /// <summary>
        /// METODO PARA LEER UN ARCHIVO
        /// </summary>
        /// <param name="nomarchivo">el parametro corresponde al nombre del archivo</param>
        public void leerArchivo(string nomarchivo)
        {
            StreamReader reader = new StreamReader(nomarchivo, System.Text.Encoding.Default);
            string texto;
            texto = reader.ReadToEnd();
            reader.Close();
            txtLenguaje.Text = texto;
        }

        /// <summary>
        /// METODO PARA ANALIZAR EL CODIGO QUE SE INGRESA
        /// </summary>
        private void AnalizeCode()
        {

            listViewToken.Items.Clear();

            int n = 0, e = 0;

            foreach (var tk in csLexer.GetTokens(PagCodigo.Text))
            {

                if (tk.Name == "ERROR")
                {
                    e++;
                }
                if (tk.Name == "IDENTIFICADOR")
                {
                    if (palabrasReservadas.Contains(tk.Lexema))
                    {
                        tk.Name = "RESERVADO";
                    }
                }
                //ListViewItem listaNombre = new ListViewItem(tk.Name);
                ListViewItem listaLexema = new ListViewItem(tk.Name);

                listaLexema.SubItems.Add(tk.Lexema);
                listaLexema.SubItems.Add(tk.Linea.ToString());
                listaLexema.SubItems.Add(tk.Columna.ToString());
                listaLexema.SubItems.Add(tk.Index.ToString());
                listViewToken.Items.Add(listaLexema);
                //listViewToken.Items.Add(new ListViewItem(tk.Lexema,lexema));
                //listViewToken.Items.Add(listaLexema);

                n++;

            }

            label1.Text = string.Format("Analizador Lexico - {0} tokens {1} errores", n, e);


        }


        /// <summary>
        /// METODO PARA MOSTRAR EL ARBOL SINTÁCTICO
        /// </summary>
        private void ShowTree()
        {
            if (File.Exists(@txtPath.Text + "/Imagen.png"))
            {
                using (FileStream img = new FileStream(@txtPath.Text + "/Imagen.png", FileMode.Open, FileAccess.Read))
                {
                    pbArbol.Image = Bitmap.FromStream(img);


                }
            }
            else
            {
                MessageBox.Show("No se ha podido abrir el archivo.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            pbArbol.Refresh();
        }

        /// <summary>
        /// METODO PARA ABRIR UN ARCHIVO
        /// </summary>
        public void abrirarchivo()
        {

            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                //ofd.Title = "Compilador#                                                                     Abrir Archivo                                                                       ";
                ofd.Title = "ABRIR ARCHIVO";
                ofd.ShowDialog();
                // ofd.Filter = "Archivos ed#(*.ed)|*.ed";
                if (File.Exists(ofd.FileName))
                {
                    using (Stream stream = ofd.OpenFile())
                    {
                        //MessageBox.Show("archivo encontrado:  "+ofd.FileName);
                        leerarchivo(ofd.FileName);
                        //nomarchivox = ofd.FileName;


                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("El archivo no se abrio correctamente");


            }

        }

        /// <summary>
        /// METODO PARA LEER UN ARCHIVO 
        /// </summary>
        /// <param name="nomarchivo">parametro para el nombre del archivo</param>
        public void leerarchivo(string nomarchivo)
        {
            StreamReader reader = new StreamReader(nomarchivo, System.Text.Encoding.Default);
            //string read = reader.ReadLine();
            string texto;
            // while (read != null)
            //{
            texto = reader.ReadToEnd();
            // read = read + "\n";

            reader.Close();

            PagCodigo.Text = texto;
            
            // read =reader.ReadLine();

            //}


        }

        /// <summary>
        /// METODO PARA REALIZAR LA LLAMADA DEL ANALIZADOR LEXICO
        /// </summary>
        /// <param name="codigo">parametro para el codigo que se ingresa</param>
        public void llamada(string codigo)
        {
            int index = listBoxLenguaje.SelectedIndex;

            if (codigo != "")

                listBoxLenguaje.SelectedIndex = index;
            if (palabrasReservadas.Contains(codigo)&& (string)listBoxLenguaje.Items[listBoxLenguaje.SelectedIndex] == "Java") 
                {
                    cadena = Regex.Replace(codigo, "abstract | as |async |await |checked |const |continue |default |delegate |base |break |case |" +
                "do |else |enum |event |explicit |extern |false |finally |fixed |for |foreach |goto |if |implicit |in |interface |internal |is|lock|new|null|operator|catch|" +
                "out|override |params |private |protected |public |readonly |ref |return |sealed |izeof |stackalloc |static |switch |this |throw |true |try |typeof |namespace |" +
                "unchecked |unsafe |virtual |void |while |float |int |long |object |get |set |new |partial |yield |add |remove |value |alias |ascending |" +
                "descending |from |group |into |orderby |select |where |" +
                "join|equals |using |bool |byte |char |decimal |double |dynamic |" +
                "sbyte |short |string |uint |ulong |ushort |var |class |struct", "");
                    //txtLenguaje.Text = cadena;
                }
            else if (palabrasReservadas.Contains(codigo) && (string)listBoxLenguaje.Items[listBoxLenguaje.SelectedIndex] == "BlackCat") ;
            {
                cadena = Regex.Replace(codigo, "abstract | as |async |await |checked |const |continue |default |delegate |base |break |case |" +
            "do |else |enum |event |explicit |extern |false |finally |fixed |for |foreach |goto |if |implicit |in |interface |internal |is|lock|new|null|operator|catch|" +
            "out|override |params |private |protected |public |readonly |ref |return |sealed |izeof |stackalloc |static |switch |this |throw |true |try |typeof |namespace |" +
            "unchecked |unsafe |virtual |void |while |float |int |long |object |get |set |new |partial |yield |add |remove |value |alias |ascending |" +
            "descending |from |group |into |orderby |select |where |" +
            "join|equals |using |bool |byte |char |decimal |doble |dynamic |" +
            "sbyte |short |string |uint |ulong |ushort |var |class |struct", "");
                //txtLenguaje.Text = cadena;
            }

            arbol.insertarEnCola(cadena);
                raiz = arbol.crearArbol();
                arbol.Limpiar();
                //Se insertan en las etiquetas los recorrimientos (Infijo, Postfijo y Prefijo).
                //pre, in, post
                grafico = new Grafico(arbol.NodoDot);
                grafico.DrawTree();
                ShowTree();
            }
            
        }
        #endregion
    }

