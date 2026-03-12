<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 20px;">
        <p>Código: <asp:TextBox ID="txtCode" runat="server"></asp:TextBox></p>
        <p>Nombre: <asp:TextBox ID="txtName" runat="server"></asp:TextBox></p>
        <p>Cantidad: <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></p>
        <p>Precio: <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></p>
        <p>Fecha: <asp:TextBox ID="txtDate" runat="server"></asp:TextBox></p>
        
        <p>Categoría: <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList></p>

        <div style="margin-top: 20px;">
            <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" />
            <asp:Button ID="btnReadFirst" runat="server" Text="Read First" OnClick="btnReadFirst_Click" />
            <asp:Button ID="btnReadPrev" runat="server" Text="Read Prev" OnClick="btnReadPrev_Click" />
            <asp:Button ID="btnReadNext" runat="server" Text="Read Next" OnClick="btnReadNext_Click" />
            <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>
        
        <br />
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Blue"></asp:Label>
    </div>
</asp:Content>
