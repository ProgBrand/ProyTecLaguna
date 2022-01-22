using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ProyectoCompilador;
using System.Text.RegularExpressions;

namespace ProyectoArbolBinario
{
    /// <summary>
    /// Clase principal que define el Arbol Sintáctico.
    /// Contiene todos los métodos para manejar las funciones de un árbol sintáctico.
    /// </summary>
    /// <remarks>
    /// <para>Con esta clase nos permite crear un arbol sintáctico en un solo recorrido. </para>
    /// </remarks>
    /// <supuestos>Para que esta clase funcione es necesario haber ingresado código en la lista de texto.
    /// </supuestos>
    /// <Autor>
    /// 18131243 Gómez Montes Zaida Sugey 
    /// 18131279 Romero Vázquez Jesús
    /// 18131225 Castañeda Limones Carlos Elian
    /// 18131281 Salazar López Brandon Daniel
    /// </Autor>
    /// <FechaCreacion>Domingo 19 de septiembre del 2021
    /// </FechaCreacion>
    public class Arbol
    {

        //************************************************************************************************************
        // Variables Locales
        //************************************************************************************************************
        #region VARIABLES LOCALES 
        //INSERCION EN COLA
        //@"\b[_a-zA-Z][\w]*\b"
        bool band = false;
        bool band2 = false;
        bool band3 = false;
        int a = 0;
        int b = 0;
        int c = 0;
        string cad = "";

        private string precedencia = "=+-*/^";  //Define cual operador aritmetico tiene menor a mayor prioridad
        private string[] delimitadores = { "=", "+", "-", "*", "/", "^" }; //Define el limite de separacion entre los operadores. 
        private string[] id ={ "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
        private string[] id2 = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private char[] cade = {'"'};
        private string[] num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private string[] operandosArray; //Arreglo para los operandos (variables)
        private string[] IdentificadorArray;
        private string[] NumeroArray;
        private string[] operadores; //Arreglo para los operadores aritmeticos 
        private Queue ColaExpresion; //Variable de tipo Cola para insertar la expresion 

        //CREACION DEL ARBOL
        private string token; //Almacena el token que se va reconociendo en la expresion
        private string operadorTemp; //Variable auxiliar o temporal para almacenar un operador
        private int i = 0; //Define el control de un ciclo
        private Stack pilaOperadores; //Variable de tipo Pila para almacenar los operadores cuando se esta creando el arbol
        private Stack pilaOperandos; //Variable de tipo Pila para almacenar los operandos cuando se esta creando el arbol
        private Stack pilaIdentificador;
        private Stack pilaNumero;
        private Stack pilaDot; //Variable de tipo Pila para almacenar los nodos del arbol
        private Nodo raiz = null; //Variable para controlar el nodo raiz

        RegexLexer ad = new RegexLexer();
        public Nodo NodoDot { get; set; } //Variable de tipo Nodo para almacenar el nodo hijo y permite el acceso libre de los metodos
        public Nodo NodoDot2 { get; set; }

        //PROPIEDADES PARA RECORRIDOS
        //Variables para almacenar la cadena de los diferentes recorridos y permite el acceso libre de los metodos
        public string cadenaPreOrden { get; set; } 
        public string cadenaInorden { get; set; } 
        public string cadenaPostorden { get; set; } 

        #endregion

        //************************************************************************************************************
        // Constructores
        //************************************************************************************************************
        #region CONSTRUCTORES

        //Constructor sin parametros:
        public Arbol()
        {
            //inicializa los objetos pila de los operadores, operandos y dot
            pilaOperadores = new Stack();  
            pilaOperandos = new Stack();
            pilaIdentificador = new Stack();
            pilaNumero = new Stack();
            pilaDot = new Stack();

            ColaExpresion = new Queue(); //inicializa el objeto cola de la expresion

        }
        #endregion

        //************************************************************************************************************
        // Métodos
        //************************************************************************************************************
        #region METODOS
        #region INSERCION EN COLA
        /// <summary>
        /// Método para insertar en la cola una expresion algebraica que el usuario ingresa.
        /// </summary>
        /// <param name="expresion">Es la expresion algebraica que se ingresa por el usuario.</param>
        public void insertarEnCola(string expresion)
        {
            //Variable que almacena cada operando y va eliminando los espacios vacios: 
            IdentificadorArray = expresion.Split(id, StringSplitOptions.RemoveEmptyEntries);
            

            operandosArray = expresion.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries);
           
            //Variable que almacena cada operador y va eliminando los espacios vacios:
            operadores = expresion.Split(operandosArray, StringSplitOptions.RemoveEmptyEntries);
            NumeroArray = expresion.Split(IdentificadorArray, StringSplitOptions.RemoveEmptyEntries);

            //ciclo para agregar un objeto al final de la cola:
            for (int i = 0; ColaExpresion.Count < operandosArray.Length + (operadores.Length - 1); i++)
            {
                ColaExpresion.Enqueue(operandosArray[i]);
                ColaExpresion.Enqueue(operadores[i]);
                
            }
            /*for (int i = 0; ColaExpresion.Count <   IdentificadorArray.Length + (NumeroArray.Length - 1); i++)
            {
                ColaExpresion.Enqueue(IdentificadorArray[i]);
                ColaExpresion.Enqueue(NumeroArray[i]);
            }*/
            ColaExpresion.Enqueue(operandosArray[operandosArray.Length - 1]);
            //ColaExpresion.Enqueue(IdentificadorArray[IdentificadorArray.Length - 1]);
        }
        #endregion

        #region ARBOL
        /// <summary>
        /// El método permite crear el árbol binario.
        /// </summary>
        /// <returns>Retorna el valor que es asignado como la raiz del árbol.</returns>
        public Nodo crearArbol()
        {
            
            while (ColaExpresion.Count != 0)
            {
      
                token =(string)ColaExpresion.Dequeue();
         
               
                if (precedencia.IndexOf(token) < 0)
                {
                    for(int i = 0; i<=26; i++) {   //ciclo para recorrer los identificadores
                        if (b != 26) { 
                        if (token.Contains(id[b]) | token.Contains(id2[b]))
                        {
                            band = true;
                            
                        }
                            b++;
                        }
                        }
                        for (int j = 0; j <= 20; j++) //ciclo para recorrer los numeros
                        {
                            if (a != 10) {
                            if (token.Contains(num[a]))
                                { 
                                    band2 = true;  
                                }
                            a++;
                        }
                    }
                    for (int k = 0; k <= 20; k++) //ciclo para recorrer las cadenas
                        {
                            if (c != 10)
                            {
                                if (token.Contains(cade[c]))
                                {
                                    band3 = true;
                                }
                                a++;
                            }
                        }
                    
                    
                    //Condiciones para establecer si es un Id, Numero o Cadena:
                    if (band  == true)
                    {
                        cad = token;
                        token = "Id";
                        
                    }
                    
                    if(band2 == true)
                    {
                        cad = token;
                        token = "Numero";
                            
                    }
                    if (band3 == true)
                    {
                        token = "Cadena";

                    }

                    a = 0;
                    b = 0;
                    band = false;
                    band2 = false;
                    band3 = false;

                    pilaOperandos.Push(new Nodo(token)); 
                    pilaDot.Push(new Nodo($"nodo{++i}[label = \"{token}\"]")); //Inserta el numero del nodo y el token a la pila

                }
                
                else
                {   
                    if (pilaOperadores.Count != 0) 
                    {
                        operadorTemp = (string)pilaOperadores.Peek(); 
                        
                        while (pilaOperadores.Count != 0 && precedencia.IndexOf(operadorTemp) >= precedencia.IndexOf(token))
                        {
                            GuardaSubArbol();
                            if (pilaOperadores.Count != 0)
                            {
                                operadorTemp = (string)pilaOperadores.Peek();

                            }
                        }
                    }
                    pilaOperadores.Push(token);

                }
                
            }
            
            raiz = (Nodo)pilaOperandos.Peek();
            NodoDot = (Nodo)pilaDot.Peek();


            while (pilaOperadores.Count != 0)
            {
                GuardaSubArbol();
                
                raiz = (Nodo)pilaOperandos.Peek();
                NodoDot = (Nodo)pilaDot.Peek(); 
              
            }
            return raiz;
    
        }
        /// <summary>
        /// El método permite guardar el sub árbol que se va generando.
        /// </summary>
        private void GuardaSubArbol()
        {
            Nodo derecho = (Nodo)pilaOperandos.Pop();
            Nodo izquierdo = (Nodo)pilaOperandos.Pop();
            pilaOperandos.Push(new Nodo(derecho, izquierdo, pilaOperadores.Peek()));

            Nodo derechoG = (Nodo)pilaDot.Pop();
            Nodo izquierdoG = (Nodo)pilaDot.Pop();
            pilaDot.Push(new Nodo(derechoG, izquierdoG, $"nodo{++i}[label=\"{pilaOperadores.Pop()}\"]"));

        }
        #endregion

        #region RECORRIDOS

        //PREORDEN
        /// <summary>
        /// El método se utiliza para insertar en el recorrido preorden un nodo del árbol. 
        /// </summary>
        /// <param name="tree">Corresponde al nodo del árbol.</param>
        /// <returns>Retorna la cadena en el recorrido PreOrden.</returns>
        public string InsertaPre(Nodo tree)
        {
            if (tree != null)
            {
                cadenaPreOrden += tree.Datos;
                InsertaPre(tree.NodoIzquierdo);
                InsertaPre(tree.NodoDerecho);
            }
            return cadenaPreOrden;
        }

        //INORDEN
        /// <summary>
        /// El método se utiliza para insertar en el recorrido InOrden un nodo del árbol. 
        /// </summary>
        /// <param name="tree">Corresponde al nodo del árbol.</param>
        /// <returns>Retorna la cadena en el recorrido InOrden.</returns>
        public string InsertaIn(Nodo tree)
        {
            if (tree != null)
            {
                InsertaIn(tree.NodoIzquierdo);
                cadenaInorden += tree.Datos + " ";
                InsertaIn(tree.NodoDerecho);
            }
            return cadenaInorden;
        }

        //PREORDEN
        /// <summary>
        /// El método se utiliza para insertar en el recorrido PostOrden un nodo del árbol. 
        /// </summary>
        /// <param name="tree">Corresponde al nodo del árbol.</param>
        /// <returns>Retorna la cadena en el recorrido PostOrden.</returns>
        public string InsertaPost(Nodo tree)
        {
            if (tree != null)
            {
                InsertaPost(tree.NodoIzquierdo);
                InsertaPost(tree.NodoDerecho);
                cadenaPostorden += tree.Datos + " ";
            }
            return cadenaPostorden;
        }
        #endregion
        
        /// <summary>
        /// El método nos permite limpiar los campos de texto donde se almacena el resultado de los distintos recorridos. 
        /// </summary>
        public void Limpiar()
        {
            cadenaPreOrden = "";
            cadenaInorden = "";
            cadenaPostorden = "";
        }
        #endregion

    }
}
