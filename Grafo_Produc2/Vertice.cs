using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_Produc2
{
    public class Vertice
    {
        internal Usuario info = null;
        internal ListaArista ListaEnlaces = new ListaArista();

        public Vertice(Usuario datos)
        {
            info = datos;
        }
        public string AgregarArista(int numV2, float costo2)
        {
            return ListaEnlaces.InsertaObjeto1(numV2, costo2);
        }

        public string[] MuestraAristas()
        {
            return ListaEnlaces.MostrarDatosColeccion();
        }
        public string infoUsuario()
        {
            return $" Id de usuario {info.IdUsuario} habitrantres{info.Nombres} " +
                $"habitantes {info.Apellidos}" +
                $" superficie {info.Edad}";
        }
    }
}
