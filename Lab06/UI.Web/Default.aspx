<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/Site1.master" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" Title="Home - Sistema Académico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="errorPanel" runat="server">
        <asp:Label ID="lblError" runat="server" SkinID="lblError" Visible="false" Text="Label"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="bienvenidaPanel" runat="server">
        <asp:Label ID="lblBienvenido" runat="server" Text="¡Bienvenido al Sistema!" EnableTheming="False" Font-Names="Segoe UI" Font-Bold="True"></asp:Label>
    </asp:Panel>
</asp:Content>
