using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_Produc2
{
    public class Grafo
    {
        public List<Vertice> ListaAdyac = new List<Vertice>();
        public bool[] visited;

       


        public string AgregarVertice(Usuario objInfo)
        {
            ListaAdyac.Add(new Vertice(objInfo));
            return "Nuevo vertice creado";
        }

        public string AgregarArista(int verOrig, int vertDest, int costo3)
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
                    salida.Add($"Vertice destino =" +
                        $"{ListaAdyac[temp.vertexNum].info.Nombres}" +
                        $" Posicion enlace a:[ {temp.vertexNum}]" +
                        $"Costo: {temp.costs}");
                    temp = temp.next;
                }
                msg = "Correcto";
            }
            else
            {
                msg = "La posicion del vestice no exite en " +
                                         "la lista de adyacencia";
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

        public void DFS(int u, List<int> result)
        {
            visited[u] = true;
            result.Add(u);

            var vertice = ListaAdyac[u];
            var arista = vertice.ListaEnlaces.inicioLista;

            while (arista != null)
            {
                if (!visited[arista.vertexNum])
                {
                    DFS(arista.vertexNum, result);
                }
                arista = arista.next;
            }
        }

        public List<int> Recorrdio_Profundidad()
        {
            visited = new bool[ListaAdyac.Count];
            var result = new List<int>();

            for (int i = 0; i < ListaAdyac.Count; i++)
            {
                if (!visited[i])
                {
                    DFS(i, result);
                }
            }

            return result;
        }

        public List<int> Recorrido_AmplitudBFS(int inicioRecorrido)
        {
           

            Queue<int> queueint = new Queue<int>();
            List<int> resul = new List<int>();
            bool[] visited = new bool[ListaAdyac.Count];

            queueint.Enqueue(inicioRecorrido);
            visited[inicioRecorrido] = true;

            while (queueint.Count > 0)
            {
                int z = queueint.Dequeue();
                resul.Add(z);
                //************************
                foreach (var arista in ListaAdyac[z].ListaEnlaces.mostrarDatosColeccion())
                {
                    if (!visited[arista.vertexNum])
                    {
                        queueint.Enqueue(arista.vertexNum);
                        visited[arista.vertexNum] = true;
                    }
                }
            }

            return resul;
        }


        // Método recorre camino 2 vertices inicio a fin
        public List<int> ResultadoIniFin(int inicio, int fin)
        {

            bool[] visited = new bool[ListaAdyac.Count];
            int[] prede = new int[ListaAdyac.Count];
            Queue<int> queueint = new Queue<int>();

            List<int> resultado = new List<int>();

            queueint.Enqueue(inicio);
            visited[inicio] = true;
            prede[inicio] = -1;

            while (queueint.Count > 0)
            {
                int v = queueint.Dequeue();

                if (v == fin)
                {
                    int head = fin;
                    while (head != -1)
                    {
                        resultado.Insert(0, head);
                        head = prede[head];
                    }
                    return resultado;
                }

                List<NodoLista> result2 = ListaAdyac[v].ListaEnlaces.mostrarDatosColeccion();
                foreach (var arista in result2)
                {
                    if (!visited[arista.vertexNum])
                    {
                        queueint.Enqueue(arista.vertexNum);
                        visited[arista.vertexNum] = true;
                        prede[arista.vertexNum] = v;
                    }
                }
            }

            return resultado;
        }

        // Método para realizar la ordenación topológica
        public List<int> OrdenTopologica()
        {
            Stack<int> stackInt = new Stack<int>();
            bool[] visited = new bool[ListaAdyac.Count];

            for (int z = 0; z < ListaAdyac.Count; z++)
            {
                if (!visited[z])
                {
                    OrdenTopologicaInterna(z, visited, stackInt);
                }
            }

            List<int> ordenTopologico = new List<int>();
            while (stackInt.Count > 0)
            {
                ordenTopologico.Add(stackInt.Pop());
            }

            return ordenTopologico;
        }

        private void OrdenTopologicaInterna(int z, bool[] visited, Stack<int> stackInt)
        {
            visited[z] = true;

            List<NodoLista> nodosAdyacentes = ListaAdyac[z].ListaEnlaces.mostrarDatosColeccion();

            foreach (var arista in nodosAdyacentes)
            {
                if (!visited[arista.vertexNum])
                {
                    OrdenTopologicaInterna(arista.vertexNum, visited, stackInt);
                }
            }

            stackInt.Push(z);
        }







    }

}
