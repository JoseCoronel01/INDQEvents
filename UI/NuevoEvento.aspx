<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NuevoEvento.aspx.cs" Inherits="UI.NuevoEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>INDQ Events</h3>
                <h4>Agregar Evento</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Titulo"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label runat="server" Text="Imagen del evento"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control text-uppercase" MaxLength="80"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:FileUpload ID="file" runat="server" AllowMultiple="false" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Descripción"></asp:Label>
            </div>
            <div class="col-md-6">
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control text-uppercase" MaxLength="80" TextMode="MultiLine" Height="300"></asp:TextBox>
            </div>
            <div class="col-md-6">
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Fecha"></asp:Label>
            </div>
            <div class="col-md-6">
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:DropDownList ID="ddlFechas" runat="server" AutoPostBack="false"></asp:DropDownList>
            </div>
            <div class="col-md-6">
            </div>
        </div>
        <div class="row">
            <div class="col-md-9">
                <asp:TextBox ID="txtBuscarDir" runat="server" CssClass="form-control" placeholder="Buscar Dirección"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
            </div>
        </div>
    </div>

</asp:Content>
