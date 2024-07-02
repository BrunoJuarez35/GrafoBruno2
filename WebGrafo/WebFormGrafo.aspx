<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormGrafo.aspx.cs" Inherits="WebGrafo.WebFormGrafo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title> 
    
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>===Grafo===== </h1>
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
            <asp:TextBox ID="TextMensaje" runat="server" CssClass="form-control" />

            <div>
                <br />
                 <br />
                    <asp:Button ID="ButtonVert" runat="server" Text="Mostrar vertices" CssClass="btn btn-primary" OnClick="ButtonVert_Click"   />
                    <br />
                  <br />
                  <asp:DropDownList ID="DropDownListVertices" runat="server" CssClass="auto-style1" Height="19px" Width="435px"></asp:DropDownList>
            </div>

            <div>
                <br />
                 <br />
                    <asp:Button ID="ButtonAristas" runat="server" Text="Mostrar aristas del vertice seleccionado" CssClass="btn btn-primary" OnClick="ButtonAristas_Click" />
                    <br />
                  <br />
                  <asp:DropDownList ID="DropDownListAristas" runat="server" CssClass="auto-style1" Height="19px" Width="435px"></asp:DropDownList>
            </div>
        

        <div class="form-group">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-secondary" />
        </div>
        <div class="form-group">
            <asp:Button ID="btnRecorridoProfundidad" runat="server" Text="Recorrido de profundidad" CssClass="btn btn-info"  />
            <asp:Button ID="btnRecorridoAmplitud" runat="server" Text="Recorrido de amplitud" CssClass="btn btn-info ml-2"  />
        </div>



        </div>
    </form>

    <script src="~/Scripts/bootstrap.min.js"></script>

</body>
</html>
