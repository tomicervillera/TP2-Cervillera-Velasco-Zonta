<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/Site.master" CodeBehind="DocentesCursos.aspx.cs" Inherits="UI.Web.DocentesCursos" Title="Docentes-Cursos - Sistema Académico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="errorPanel" runat="server">
        <asp:Label ID="lblError" runat="server" SkinID="lblError" Visible="false" Text="Label"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="ID Curso" DataField="IDCurso" />
                <asp:BoundField HeaderText="ID Docente" DataField="IDDocente"/>
                <asp:BoundField HeaderText="Cargo" DataField="Cargo"/>
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
        <asp:Label ID="cursoLabel" runat="server" Text="Curso:"></asp:Label>
        <asp:DropDownList ID="ddlCurso" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="legajoDocenteLabel" runat="server" Text="Legajo Docente:"></asp:Label>
        <asp:DropDownList ID="ddlDocente" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="cargoLabel" runat="server" Text="Cargo:"></asp:Label>
        <asp:DropDownList ID="ddlCargo" runat="server">
        </asp:DropDownList>
        <asp:ValidationSummary ID="erroresValidationSummary" runat="server"/>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" Visible="false" runat="server" Style="margin-top: 5px">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" Text="Aceptar" OnClick="aceptarLinkButton_Click"></asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" Text="Cancelar" OnClick="cancelarLinkButton_Click" CausesValidation="False"></asp:LinkButton>
    </asp:Panel>
</asp:Content>
