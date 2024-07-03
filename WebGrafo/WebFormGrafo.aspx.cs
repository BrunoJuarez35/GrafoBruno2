using Grafo_Produc2;
using Newtonsoft.Json;
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
        int contaElement = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            { // la carga de la pag por primera vez
                graf1 = new Grafo();
                Session["graf1"] = graf1;
                //Cuenta ID de mi grafo
                Session["contaElement"] = 0;
            }
            else
            {//ya viene de un postback
                graf1 = (Grafo)Session["graf1"];
                contaElement = (int)Session["contaElement"];

            }
        }

        protected void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {


            string msg = "";

            if (txtNombres.Text == "" || txtApellidos.Text == "" || txtEdad.Text == "")
            {
                msg = "Completa los campos";
                TextMensaje.Text = msg;

            }
            else
            {
                Usuario nuevo = new Usuario(contaElement, txtNombres.Text, txtApellidos.Text, int.Parse(txtEdad.Text));
                    contaElement++;
                msg = graf1.AgregarVertice(nuevo);
                txtNombres.Text = "";
                txtApellidos.Text = "";
                txtEdad.Text = "";

            }


            Session["contaElement"] = contaElement;
            Session["graf1"] = graf1;


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

        protected void btnRecorridoProfundidad_Click(object sender, EventArgs e)
        { //ListBoxDFSResul

            var result = graf1.Recorrdio_Profundidad();
            ListBoxDFSResul.Items.Clear();

            foreach (var vertex in result)
            {
                ListBoxDFSResul.Items.Add(vertex.ToString());
            }
        }

        protected void BtnGuardarArista_Click(object sender, EventArgs e)
        {

            string msg = "";

            if (textOrigen.Text == "" || txtDestino.Text == "" || txtCosto.Text == "")
            {
                msg = "Completa los campos";
                TextMensaje.Text = msg;
            }
            else
            {
                msg = graf1.AgregarArista(int.Parse(textOrigen.Text), int.Parse(txtDestino.Text), int.Parse(txtCosto.Text));
                textOrigen.Text = "";
                txtDestino.Text = "";
                txtCosto.Text = "";
            }
            Session["graf1"] = graf1;
        }

        protected void btnVerGrafo_Click(object sender, EventArgs e)
        {
            // Serializamos Json con Vertices y Aristas
            var JsonSerializadoVert = JsonConvert.SerializeObject(graf1.ListaAdyac.Select(v => new {
                v.info.IdUsuario,
                v.info.Nombres,
                aristas = v.ListaEnlaces.mostrarDatosColeccion().Select(a => new {
                    IdUsuario = graf1.ListaAdyac[a.vertexNum].info.IdUsuario,
                    Nombres = graf1.ListaAdyac[a.vertexNum].info.Nombres,
                    costs = a.costs
                })
            }));

            // console vertice   
           // string prueba = $"console.log({verticesJson});";
            string cadena = $" mostrarGrafo({JsonSerializadoVert});";

            ClientScript.RegisterStartupScript(this.GetType(), "Metodo1", cadena, true);


        }

        protected void btnRecorridoAmplitud_Click(object sender, EventArgs e)
        {

            if (txtRecorridoAmp.Text == "" )
            {
                string msg = "";
                msg = "Completa los campos";
                TextMensaje.Text = msg;
            }
            else
            {
                List<int> resultadosBFS = graf1.Recorrido_AmplitudBFS(int.Parse(txtRecorridoAmp.Text));
                ListBoxBFSResul.Items.Clear();

                foreach (int resultado in resultadosBFS)
                {
                    ListBoxBFSResul.Items.Add(resultado.ToString());
                }

                txtRecorridoAmp.Text = "";
                
            }

           

        }

        protected void btnBuscarOrdenTopo_Click(object sender, EventArgs e)
        {
            List<int> ordenTopologiconormal = graf1.OrdenTopologica();

            listOrdenTopo.Items.Clear();
            foreach (int vertice in ordenTopologiconormal)
            {
                listOrdenTopo.Items.Add("Vértice: " + vertice);
            }


        }

        protected void btnBuscarOdenTopo2_Click(object sender, EventArgs e)
        {

            string msg = "";
            if (txtordenTInici.Text == "" || txtordenTFin.Text == "" )
            {
                msg = "Completa los campos";
                TextMensaje.Text = msg;
            }
            else
            {
                List<int> ordentopologicoinifin = graf1.ResultadoIniFin(int.Parse(txtordenTInici.Text), int.Parse(txtordenTFin.Text));

                ListOrdenTopo2.Items.Clear();
                if (ordentopologicoinifin.Count > 0)
                {
                    foreach (int vertice in ordentopologicoinifin)
                    {
                        ListOrdenTopo2.Items.Add("Vértice: " + vertice);
                    }
                }
                else
                {
                    ListOrdenTopo2.Items.Add("No existe un camino");
                }


                txtordenTInici.Text = "";
                txtordenTFin.Text = "";
            }



        }
    }
}