using Grafo_Produc2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebGrafo
{
    public partial class WebFormGrafo : System.Web.UI.Page
    {
        Grafo graf1 = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            { // la carga de la pag por primera vez
                graf1 = new Grafo();
                Session["graf1"] = graf1;
            }
            else
            {//ya viene de un postback
                graf1 = (Grafo)Session["graf1"];
            }
        }

        protected void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            //Contador que cuente los vertices agregados, condicional que pare al limite de vertices
            //Agregar Aristas de acuerdo al vertice creado

            //id, nombre,totalhabitantes, superficie
            Usuario nuevo = null;

            nuevo = new Usuario(10, "A", "Anaa", 30000);
            graf1.AgregarVertice(nuevo);

            nuevo = new Usuario(1, "B", "Bruno", 30000);
            graf1.AgregarVertice(nuevo);

            nuevo = new Usuario(2, "C", "Jose", 30000);
            graf1.AgregarVertice(nuevo);

            nuevo = new Usuario(3, "D", "Dylan", 30000);
            graf1.AgregarVertice(nuevo);

            nuevo = new Usuario(4, "E", "Estribor", 30000);
            graf1.AgregarVertice(nuevo);

            nuevo = new Usuario(5, "F", "Flores", 30000);
            graf1.AgregarVertice(nuevo);

            nuevo = new Usuario(6, "G", "Galindo", 30000);
            graf1.AgregarVertice(nuevo);


            Session["graf1"] = graf1;

            graf1.AgregarArista(0, 2, 7); //a -> c
            graf1.AgregarArista(1, 2, 8); //b -> c

            graf1.AgregarArista(2, 3, 9); //c -> D
            graf1.AgregarArista(2, 4, 7); // c -> E

            graf1.AgregarArista(3, 0, 5); //D -> A
            graf1.AgregarArista(3, 4, 15); // D -> E

            graf1.AgregarArista(4, 1, 5);//e -> b
            graf1.AgregarArista(4, 5, 8);//e -> f
            graf1.AgregarArista(4, 6, 9);//e -> G

            graf1.AgregarArista(5, 3, 6);//f -> d

            graf1.AgregarArista(6, 5, 11);//g -> f


        }


        protected void ButtonVert_Click(object sender, EventArgs e)
        {
            string[] vertx = null;
            vertx = graf1.MostrarVertices();
            DropDownListVertices.Items.Clear();
            foreach (string s in vertx)
            {
                DropDownListVertices.Items.Add(s);

            }
        }

        protected void ButtonAristas_Click(object sender, EventArgs e)
        {
            //butoon mostras aristas de vertuce seleccionado
            int posiVertxt = -5;
            string[] aristas = null;

            List<string> aristas2 = null;
            string msg = "";

            if (DropDownListVertices.SelectedIndex != -1)
            {
                posiVertxt = DropDownListVertices.SelectedIndex;
                aristas = graf1.MostrarAristasVertice( posiVertxt, ref msg);

                TextMensaje.Text = msg;

                //DropDownList2.Items.Clear();
                //foreach (string w in aristas)
                //{
                //    DropDownList2.Items.Add(w);
                //}

                aristas2 = graf1.MostrarAristasVerticeV2(posiVertxt, ref msg);
                TextMensaje.Text = msg;
                DropDownListAristas.Items.Clear();

                foreach (string w in aristas2)
                {
                    DropDownListAristas.Items.Add(w);
                }
            }
            else
            {
                TextMensaje.Text = "Debe elegir un vertice de la lista";
            }

        }
    }
}