<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FechaNacimientoUserControl.ascx.cs" Inherits="UI.Web.UserControls.FechaNacimientoUserControl" %>

<asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
<asp:DropDownList ID="DDLDiaFechaNac" runat="server">
    <asp:ListItem Value="01">1</asp:ListItem>
    <asp:ListItem Value="02">2</asp:ListItem>
    <asp:ListItem Value="03">3</asp:ListItem>
    <asp:ListItem Value="04">4</asp:ListItem>
    <asp:ListItem Value="05">5</asp:ListItem>
    <asp:ListItem Value="06">6</asp:ListItem>
    <asp:ListItem Value="07">7</asp:ListItem>
    <asp:ListItem Value="08">8</asp:ListItem>
    <asp:ListItem Value="09">9</asp:ListItem>
    <asp:ListItem Value="10"></asp:ListItem>
    <asp:ListItem Value="11"></asp:ListItem>
    <asp:ListItem Value="12"></asp:ListItem>
    <asp:ListItem Value="13"></asp:ListItem>
    <asp:ListItem Value="14"></asp:ListItem>
    <asp:ListItem Value="15"></asp:ListItem>
    <asp:ListItem Value="16"></asp:ListItem>
    <asp:ListItem Value="17"></asp:ListItem>
    <asp:ListItem Value="18"></asp:ListItem>
    <asp:ListItem Value="19"></asp:ListItem>
    <asp:ListItem Value="20"></asp:ListItem>
    <asp:ListItem Value="21"></asp:ListItem>
    <asp:ListItem Value="22"></asp:ListItem>
    <asp:ListItem Value="23"></asp:ListItem>
    <asp:ListItem Value="24"></asp:ListItem>
    <asp:ListItem Value="25"></asp:ListItem>
    <asp:ListItem Value="26"></asp:ListItem>
    <asp:ListItem Value="27"></asp:ListItem>
    <asp:ListItem Value="28"></asp:ListItem>
    <asp:ListItem Value="29"></asp:ListItem>
    <asp:ListItem Value="30"></asp:ListItem>
    <asp:ListItem Value="31"></asp:ListItem>
</asp:DropDownList>
<asp:DropDownList ID="DDLMesFechaNac" runat="server">
    <asp:ListItem Value="01">Enero</asp:ListItem>
    <asp:ListItem Value="02">Febrero</asp:ListItem>
    <asp:ListItem Value="03">Marzo</asp:ListItem>
    <asp:ListItem Value="04">Abril</asp:ListItem>
    <asp:ListItem Value="05">Mayo</asp:ListItem>
    <asp:ListItem Value="06">Junio</asp:ListItem>
    <asp:ListItem Value="07">Julio</asp:ListItem>
    <asp:ListItem Value="08">Agosto</asp:ListItem>
    <asp:ListItem Value="09">Septiembre</asp:ListItem>
    <asp:ListItem Value="10">Octubre</asp:ListItem>
    <asp:ListItem Value="11">Noviembre</asp:ListItem>
    <asp:ListItem Value="12">Diciembre</asp:ListItem>
</asp:DropDownList>
<asp:TextBox ID="AñoNacimientoTextBox" runat="server" Width="50px" MaxLength="4"></asp:TextBox>
<asp:RequiredFieldValidator ID="añoNacimientoRequiredFieldValidator" runat="server" ControlToValidate="añoNacimientoTextBox" ErrorMessage="La fecha de nacimiento no puede estar vacía."></asp:RequiredFieldValidator>
<asp:RangeValidator ID="añoNacimientoRangeValidator" runat="server" ControlToValidate="añoNacimientoTextBox" ErrorMessage="Año no válido." Type="Integer" MinimumValue="1920" MaximumValue="2020"></asp:RangeValidator>
<asp:CustomValidator ID="fechaNacimientoCustomValidator" runat="server" ControlToValidate="DDLDiaFechaNac" OnServerValidate="fechaNacimientoCustomValidator_ServerValidate" ErrorMessage="La fecha seleccionada no existe. "></asp:CustomValidator>