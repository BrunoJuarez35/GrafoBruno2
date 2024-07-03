using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_Produc2
{
    public class Vertice
    {
        public Usuario info = null;
        public ListaArista ListaEnlaces = new ListaArista();

        public Vertice(Usuario datos)
        {
            info = datos;
        }
        public string AgregarArista(int numV2, int costo2)
        {
            return ListaEnlaces.InsertaObjeto1(numV2, costo2);
        }

        public string[] MuestraAristas()
        {
            return ListaEnlaces.MostrarDatosColeccion();
        }
        public string infoUsuario()
        {
            return $" Id: {info.IdUsuario} Nombre:{info.Nombres} " +
                $"Apellidos: {info.Apellidos}" +
                $" Edad: {info.Edad}";
        }
    }
}
