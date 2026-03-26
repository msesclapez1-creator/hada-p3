<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Products management</h2>
    <div style="margin-top: 20px;">
        <p>Code: <asp:TextBox ID="txtCode" runat="server"></asp:TextBox></p>
        <p>Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox></p>
        <p>Amount: <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></p>
        <p>Category: <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList></p>
        <p>Price: <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></p>
        <p>Creation Date: <asp:TextBox ID="txtDate" runat="server"></asp:TextBox></p>
        
        

        <div style="margin-top: 20px;">
            <asp:Button ID="btnRead" runat="server" Text="Read" OnClick="btnRead_Click" />
            <asp:Button ID="btnReadFirst" runat="server" Text="Read First" OnClick="btnReadFirst_Click" />
            <asp:Button ID="btnReadPrev" runat="server" Text="Read Prev" OnClick="btnReadPrev_Click" />
            <asp:Button ID="btnReadNext" runat="server" Text="Read Next" OnClick="btnReadNext_Click" />
            <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
        </div>
        
        <br />
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Blue"></asp:Label>
    </div>
</asp:Content>
