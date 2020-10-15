<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/Site.master" CodeBehind="AlumnosInscripciones.aspx.cs" Inherits="UI.Web.AlumnosInscripciones" Title="Inscripciones - Sistema Académico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="errorPanel" runat="server">
        <asp:Label ID="lblError" runat="server" SkinID="lblError" Visible="false" Text="Label"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="ID Alumno" DataField="IDAlumno" />
                <asp:BoundField HeaderText="ID Curso" DataField="IDCurso"/>
                <asp:BoundField HeaderText="Condición" DataField="Condicion" />
                <asp:BoundField HeaderText="Nota" DataField="Nota"/>
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
        <asp:Label ID="legajoAlumnoLabel" runat="server" Text="Legajo Alumno:"></asp:Label>
        <asp:DropDownList ID="ddlAlumno" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblCurso" runat="server" Text="Curso:"></asp:Label>
        <asp:DropDownList ID="ddlCurso" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="condicionLabel" runat="server" Text="Condición:"></asp:Label>
        <asp:TextBox ID="condicionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="condicionRequiredFieldValidator" runat="server" ControlToValidate="condicionTextBox" ErrorMessage="La condición no puede estar vacía."></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblNota" runat="server" Text="Nota:"></asp:Label>
        <asp:TextBox ID="notaTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="notaRequiredFieldValidator" runat="server" ControlToValidate="notaTextBox" ErrorMessage="La nota no puede estar vacía."></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="notaRangeValidator" runat="server" ControlToValidate="notaTextBox" ErrorMessage="La nota debe ser un número válido." Type="Integer" MinimumValue="0" MaximumValue="10"></asp:RangeValidator>
        <asp:ValidationSummary ID="erroresValidationSummary" runat="server"/>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" Visible="false" runat="server" Style="margin-top: 5px">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" Text="Aceptar" OnClick="aceptarLinkButton_Click"></asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" Text="Cancelar" OnClick="cancelarLinkButton_Click" CausesValidation="False"></asp:LinkButton>
    </asp:Panel>
</asp:Content>
