<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListadoEventos.aspx.cs" Inherits="UI.ListadoEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <a href="NuevoEvento.aspx">Agregar Evento</a>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvEventos" runat="server" AutoGenerateColumns="false" CssClass="table">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="id" />
                        <asp:BoundField HeaderText="Titulo" DataField="title" />
                        <asp:BoundField HeaderText="Descripción" DataField="description" />
                        <asp:BoundField HeaderText="Fecha del Evento" DataField="date" />
                        <asp:ImageField HeaderText="Imagen del Evento" DataImageUrlField="image" ItemStyle-CssClass="style">
                        </asp:ImageField>
                        <asp:BoundField HeaderText="Asistentes" DataField="attendances" />
                        <asp:BoundField HeaderText="Asisteré" DataField="willYouAttend" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
