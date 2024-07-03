using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grafo_Produc2;

namespace Grafo_Produc2
{
    public class ListaArista 
    {
        public NodoLista inicioLista = null;
        public int contElemnts = 0;

       

        public string InsertaObjeto1(int numV, int cost)
        {
            string mensaje = "";

            NodoLista nuevo = new NodoLista();

            nuevo.vertexNum = numV;
            nuevo.costs = cost;

            if (inicioLista == null)
            { // no había objetos en la colección
              // es el primero
                inicioLista = nuevo;
                contElemnts++;
                mensaje = "Primer elemento de la colección";
            }
            else
            { 
               // ya hay objetos en la colección, no se cuantos
              // hay que recorrer esos objetos y dejar una referencia en el ultimo
                NodoLista t = null;

                t = inicioLista;
                while (t.next != null)
                {
                    t = t.next;
                }
                //cuando llego aquí estoy seguro que t está en el último
                
                t.next = nuevo;
                contElemnts++;
                mensaje = "Ya no es el primer Elemento";
            }
            return mensaje;
        }

        public string[] MostrarDatosColeccion()
        {
            string[] cads = new string[contElemnts];

            NodoLista z = null;
            z = inicioLista;
            int w = 0; // para la localidad del arreglo
            while (z != null)
            {
                cads[w] = $"Posicion enlace a:[ {z.vertexNum}]" +
                    $"Costo: {z.costs}";
                z = z.next;
                w++;
            }

            return cads;
        }

        public List<NodoLista> mostrarDatosColeccion()
        {
            List<NodoLista> nodos = new List<NodoLista>();
            NodoLista w = inicioLista;
            while (w != null)
            {
                nodos.Add(w);
                w = w.next;
            }
            return nodos;
        }


    }
}
