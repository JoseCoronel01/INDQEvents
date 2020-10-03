<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="UI.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3>INDQ Events</h3>
                <h4>Registro</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Nombre (s)"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label runat="server" Text="Apellido (s)"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control text-uppercase" MaxLength="50"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control text-uppercase" MaxLength="50"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Correo"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label runat="server" Text="Género"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:RadioButton ID="rbMale" runat="server" Checked="true" AutoPostBack="false" GroupName="gen" CssClass="form-control" Text="Masculino" />
                <asp:RadioButton ID="rbFem" runat="server" AutoPostBack="false" GroupName="gen" CssClass="form-control" Text="Femenino" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Contraseña"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:Label runat="server" Text="ConfirmarContraseña"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" MaxLength="8"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtConfirmar" runat="server" CssClass="form-control" TextMode="Password" MaxLength="8"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <a href="InicioSesion.aspx">¿ya eres miembro? inicia sesión</a>
            </div>
        </div>
    </div>

</asp:Content>
