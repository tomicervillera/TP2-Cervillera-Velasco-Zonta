<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/Site.master" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" Title="Comisiones - Sistema Académico"%>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="errorPanel" runat="server">
        <asp:Label ID="lblError" runat="server" SkinID="lblError" Visible="false" Text="Label"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
                <asp:BoundField HeaderText="Año Especialidad" DataField="AnioEspecialidad"/>
                <asp:BoundField HeaderText="ID Plan" DataField="IDPlan"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" ControlStyle-Font-Bold="true" ControlStyle-Font-Italic="true" ControlStyle-Font-Names="Calibri" ControlStyle-Font-Underline="True"/>
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
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripción:"></asp:Label>
        <asp:TextBox ID="descripcionTextBox"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="descripcionRequiredFieldValidator" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="La descripción no puede estar vacía."></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="añoEspecialidadLabel" runat="server" Text="Año Especialidad:"></asp:Label>
        <asp:TextBox ID="añoEspecialidadTextBox"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="añoEspecialidadRequiredFieldValidator" runat="server" ControlToValidate="añoEspecialidadTextBox" ErrorMessage="El año de especialidad no puede estar vacío."></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="planLabel" runat="server" Text="Plan:"></asp:Label>
        <asp:DropDownList ID="ddlPlan" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="planRequiredFieldValidator" runat="server" ControlToValidate="ddlPlan" ErrorMessage="El plan no puede estar vacío."></asp:RequiredFieldValidator>
        <br />
        <asp:ValidationSummary ID="erroresValidationSummary" runat="server"/>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" Visible="false" runat="server" Style="margin-top: 5px">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" Text="Aceptar" OnClick="aceptarLinkButton_Click"></asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" Text="Cancelar" OnClick="cancelarLinkButton_Click" CausesValidation="False"></asp:LinkButton>
    </asp:Panel>
</asp:Content>
