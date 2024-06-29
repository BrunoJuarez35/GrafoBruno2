using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo_Produc2
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public  int Edad{ get; set; }

        public Usuario() { }

        public Usuario(int id2, string nombres, string apellidos,int edad)
        {
            IdUsuario = id2;
            Nombres = nombres;
            Apellidos = apellidos;
            Edad = edad;
        }


    }
}
