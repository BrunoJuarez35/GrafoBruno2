using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_Produc2
{
    public class Grafo
    {
        private List<Vertice> ListaAdyac = new List<Vertice>();

        public string AgregarVertice(Usuario objInfo)
        {
            ListaAdyac.Add(new Vertice(objInfo));
            return "Nuevo vertice creado";
        }

        public string AgregarArista(int verOrig, int vertDest, float costo3)
        {
            string msg = "";
            //verificar que vertDest y verOrig esten en el rango de los objetos del list
            if (verOrig >= 0 && verOrig <= (ListaAdyac.Count - 1))
            {
                if (vertDest >= 0 && vertDest <= (ListaAdyac.Count - 1))
                {
                    ListaAdyac[verOrig].AgregarArista(vertDest, costo3);
                    msg = "Arista Agregada";
                }
                else
                {
                    msg = "la posicion del vestice destino no exite en " +
                        "la lista de aduacencia";
                }

            }
            else
            {
                msg = "la posicion del vestice origen no exite en " +
                                        "la lista de aduacencia";
            }
            return msg;
        }

        public string[] MostrarAristasVertice(int posiVert, ref string msg)
        {
            string[] salida = null;
            if (posiVert >= 0 && posiVert <= (ListaAdyac.Count - 1))
            {
                salida = ListaAdyac[posiVert].MuestraAristas();
            }
            else
            {
                msg = "la posicion del vestice no exite en " +
                                         "la lista de adyacencia";
            }
            return salida;
        }

        //mostrar tambien el nombre de vertice destino
        public List<string> MostrarAristasVerticeV2(int posiVert, ref string msg)
        {
            NodoLista temp = null; //ref para recorrer los nodo de lista de aristas

            List<string> salida = new List<string>();
            if (posiVert >= 0 && posiVert <= (ListaAdyac.Count - 1))
            {
                temp = ListaAdyac[posiVert].ListaEnlaces.inicioLista;
                while (temp != null)
                {
                    salida.Add($"vertice destino =" +
                        $"{ListaAdyac[temp.vertexNum].info.Nombres}" +
                        $" posicion enlace a:[ {temp.vertexNum}]" +
                        $"costo: {temp.costs}");
                    temp = temp.next;
                }
                msg = "correcto";
            }
            else
            {
                msg = "la posicion del vestice no exite en " +
                                         "la lista de aduacencia";
            }
            return salida;
        }

        public string[] MostrarVertices()
        {
            string[] cads = new string[ListaAdyac.Count];
            int h = 0;
            for (h = 0; h <= ListaAdyac.Count - 1; h++)
            {
                cads[h] = ListaAdyac[h].infoUsuario();
            }
            return cads;
        }
    }

}
