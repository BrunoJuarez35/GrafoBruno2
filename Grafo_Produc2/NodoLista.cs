using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_Produc2
{
    public class NodoLista
    {
        //
        public int vertexNum = -5;
        //costo para llegar al vertice
        public int costs { get;  set; }
        //Enlace lista ligada
        public NodoLista next = null;
    }
}
