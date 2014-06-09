<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MF0493_3.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="zona1" runat="server">
    <h1>Listado de empresas</h1>
        
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hovered" GridLines="None" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing">
        <Columns>
            <asp:BoundField DataField="nif" HeaderText="N.I.F.">
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="nombre" HeaderText="Nombre comercial" />
            <asp:BoundField DataField="ff" DataFormatString="{0:d}" HeaderText="Fundacion">
            <ItemStyle Width="85px" />
            </asp:BoundField>
            <asp:BoundField DataField="telefono" HeaderText="Tlf">
            <ItemStyle Width="85px" />
            </asp:BoundField>
            <asp:BoundField DataField="usr" HeaderText="Comercial">
                <ItemStyle Width="70px" />
             </asp:BoundField>
            <asp:CommandField ButtonType="Button" DeleteText="Eliminar" ShowDeleteButton="True">
                <ControlStyle CssClass="btn btn-danger" />
            <ItemStyle Width="60px" />
            </asp:CommandField>
            <asp:CommandField EditText="Editar" InsertVisible="False" ShowCancelButton="False" ShowEditButton="True">
            <ControlStyle CssClass="btn btn-primary" />
            <ItemStyle Width="60px" />
            </asp:CommandField>
        </Columns>
        <HeaderStyle BackColor="#000066" Font-Bold="True" ForeColor="White" />
    </asp:GridView>

</asp:Content>