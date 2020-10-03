<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="UI.InicioSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Correo"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Contraseña"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
                <asp:TextBox ID="txtContra" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnAcceder" runat="server" Text="Acceder" OnClick="btnAcceder_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <a href="Registro.aspx">¿No tienes una cuenta? Registrate.</a>
            </div>
        </div>
    </div>

</asp:Content>
