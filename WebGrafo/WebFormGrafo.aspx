<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormGrafo.aspx.cs" Inherits="WebGrafo.WebFormGrafo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title> 
    
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .contenedor {
            width: 80%;
            margin: 0 auto;
            box-sizing: border-box;
        }
    </style>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

               <script type="text/javascript" src="JavaScript/DibujaGrafo.js"></script>

</head>
<body>

    <div class="contenedor">
        
    <form id="form1" runat="server">
        <div>
            <h1>===Grafo===== </h1>
                        <asp:TextBox ID="TextMensaje" runat="server" CssClass="form-control" />


            <h2>Registrar informacion</h2>
       <div class="form-group">
        <label for="txtNombres">Nombres</label>
            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtApellidos">Apellidos</label>
            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtEdad">Edad</label>
            <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control" OnTextChanged="txtEdad_TextChanged" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"  />
        </div>
       <h2>Agregar Arista</h2>

        <div class="form-group">
        <label for="txtOrigen">Origen</label>
            <asp:TextBox ID="textOrigen" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtDestino">Destino</label>
            <asp:TextBox ID="txtDestino" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtCosto">Costo</label>
            <asp:TextBox ID="txtCosto" runat="server" CssClass="form-control"  />
        </div>
        <div class="form-group">
            <asp:Button ID="BtnGuardarArista" runat="server" Text="Agregar Arista" CssClass="btn btn-primary" OnClick="BtnGuardarArista_Click"  />
        </div>





            <div>
                <br />
                <h2>Mostrar vertices</h2>
                                      <br />
                  <asp:DropDownList ID="DropDownListVertices" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:Button ID="ButtonVert" runat="server" Text="Mostrar vertices" CssClass="btn btn-primary" OnClick="ButtonVert_Click"   />
                    <br />

            </div>

            <div>
                <br />
                <h2>Mostrar aristas del vertice seleccionado</h2>
                    <br />
                 <asp:DropDownList ID="DropDownListAristas" runat="server" CssClass="form-control"></asp:DropDownList>
                              <br />
                <asp:Button ID="ButtonAristas" runat="server" Text="Mostrar aristas del vertice seleccionado" CssClass="btn btn-primary" OnClick="ButtonAristas_Click" />

            </div>

            <div>
                <h2>Recorrido de profundidad (DFS)</h2>
                
                <br />
                <asp:ListBox ID="ListBoxDFSResul" runat="server" CssClass="form-control" ></asp:ListBox>
             <br />
                <asp:Button ID="btnRecorridoProfundidad" runat="server" Text="Recorrido de profundidad" CssClass="btn btn-info" OnClick="btnRecorridoProfundidad_Click"  />
            </div>

            <h2>Recorrido de amplitud (BFS)</h2>
                <label for="txtRecorridoAmp">Ingresa Arista</label>
            <asp:TextBox ID="txtRecorridoAmp" runat="server" CssClass="form-control"  />
            <asp:Button ID="btnRecorridoAmplitud" runat="server" Text="Recorrido de amplitud" CssClass="btn btn-info" OnClick="btnRecorridoAmplitud_Click"   />
    
            <br />
                <asp:ListBox ID="ListBoxBFSResul" runat="server" CssClass="form-control" ></asp:ListBox>
            <h2>Busqueda Topologica</h2>
               
            <asp:Button ID="btnBuscarOrdenTopo" runat="server" Text="Buscar orden topologico" CssClass="btn btn-info" OnClick="btnBuscarOrdenTopo_Click"  />
    
            <br />
                <asp:ListBox ID="listOrdenTopo" runat="server" CssClass="form-control" ></asp:ListBox>
             
            </div>

        
     <h2>Busqueda Topologica de inicio fin</h2>
                <label for="txtOrdentopo2">Ingresa Arista de inicio</label>
            <asp:TextBox ID="txtordenTInici" runat="server" CssClass="form-control"  />
     <label for="txtOrdentopo3">Ingresa Arista de Fin</label>
            <asp:TextBox ID="txtordenTFin" runat="server" CssClass="form-control"  />
            <asp:Button ID="btnBuscarOdenTopo2" runat="server" Text="Buscar Orden Topologico de inicio a fin" CssClass="btn btn-info" OnClick="btnBuscarOdenTopo2_Click"  />
    
            <br />
                <asp:ListBox ID="ListOrdenTopo2" runat="server" CssClass="form-control" ></asp:ListBox>
             


        

        
        <div class="form-group">
        </div>
                            <br />

                 <asp:Button ID="btnVerGrafo" CssClass="btn btn-info" runat="server"  Text="Ver Grafo" OnClick="btnVerGrafo_Click" />
                <canvas id="miCanvas" width="1200" height="800" style="border: 1px solid #000000;">Su navegador no soporta Canvas</canvas>


        </div>
    </form>


    </div>  
                                      
            <br />
                 <br />

                   


           <script type="text/javascript" src="JavaScript/DibujaGrafo.js"></script>

</body>
</html>
