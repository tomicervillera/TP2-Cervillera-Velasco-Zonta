<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/Site.master" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" Title="Cursos - Sistema Académico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="errorPanel" runat="server">
        <asp:Label ID="lblError" runat="server" SkinID="lblError" Visible="false" Text="Label"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="ID Comisión" DataField="IDComision" />
                <asp:BoundField HeaderText="ID Materia" DataField="IDMateria"/>
                <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
                <asp:BoundField HeaderText="Cupo" DataField="Cupo"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" ControlStyle-Font-Bold="true" ControlStyle-Font-Italic="true" ControlStyle-Font-Names="Calibri" ControlStyle-Font-Underline="True">
                <ControlStyle Font-Bold="True" Font-Italic="True" Font-Names="Calibri" Font-Underline="True" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server" Style="margin-top: 5px">
                <asp:LinkButton ID="nuevoLinkButton" runat="server" Text="Nuevo" OnClick="nuevoLinkButton_Click" CausesValidation="False"></asp:LinkButton>
                <asp:LinkButton ID="editarLinkButton" runat="server" Text="Editar" OnClick="editarLinkButton_Click" CausesValidation="False"></asp:LinkButton>
                <asp:LinkButton ID="eliminarLinkButton" runat="server" Text="Eliminar" OnClick="eliminarLinkButton_Click" CausesValidation="False"></asp:LinkButton>
            </asp:Panel>
    <br />
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="comisionLabel" runat="server" Text="Comisión:"></asp:Label>
        <asp:DropDownList ID="ddlComision" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="materiaLabel" runat="server" Text="Materia:"></asp:Label>
        <asp:DropDownList ID="ddlMateria" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="añoCalendarioLabel" runat="server" Text="Año Calendario:"></asp:Label>
        <asp:TextBox ID="añoCalendarioTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="añoCalendarioRequiredFieldValidator" runat="server" ControlToValidate="añoCalendarioTextBox" ErrorMessage="El año calendario no puede estar vacío."></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="añoCalendarioRangeValidator" runat="server" ControlToValidate="añoCalendarioTextBox" ErrorMessage="El año calendario debe ser un número válido." Type="Integer" MinimumValue="1800" MaximumValue="3000"></asp:RangeValidator>
        <br />
        <asp:Label ID="cupoLabel" runat="server" Text="Cupo:"></asp:Label>
        <asp:TextBox ID="cupoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="cupoRequiredFieldValidator" runat="server" ControlToValidate="cupoTextBox" ErrorMessage="El cupo no puede estar vacío."></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="cupoRangeValidator" runat="server" ControlToValidate="cupoTextBox" ErrorMessage="El cupo debe ser un número válido." Type="Integer" MinimumValue="0" MaximumValue="1000"></asp:RangeValidator>
        <asp:ValidationSummary ID="erroresValidationSummary" runat="server"/>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" Visible="false" runat="server" Style="margin-top: 5px">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" Text="Aceptar" OnClick="aceptarLinkButton_Click"></asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" Text="Cancelar" OnClick="cancelarLinkButton_Click" CausesValidation="False"></asp:LinkButton>
    </asp:Panel>
</asp:Content>
