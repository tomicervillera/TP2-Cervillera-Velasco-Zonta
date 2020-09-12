<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/Site1.master" Inherits="UI.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" Runat="Server">
        <table style="width:100%;">
            <tr>
                <td style="width: 280px">
            <asp:Label ID="lblBienvenido" runat="server" Text="Por favor, ingrese sus credenciales." EnableTheming="False" Font-Names="Segoe UI" Font-Bold="True"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="width: 280px">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td style="width: 280px">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 280px">
            <asp:Label ID="lblClave" runat="server" Text="Contraseña"></asp:Label>
                </td>
                <td>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 280px">&nbsp;</td>
                <td>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                </td>
            </tr>
            <tr>
                <td style="width: 280px">
            <asp:LinkButton ID="lnkRecordarClave" runat="server" Text="Olvidé mi contraseña" OnClick="lnkRecordarClave_Click"></asp:LinkButton>

                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
</asp:Content>

