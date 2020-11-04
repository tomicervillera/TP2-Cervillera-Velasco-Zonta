<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/Site.master" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" Title="Personas - Sistema Académico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="errorPanel" runat="server">
        <asp:Label ID="lblError" runat="server" SkinID="lblError" Visible="false" Text="Label"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID"/>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                <asp:BoundField HeaderText="Dirección" DataField="Direccion"/>
                <asp:BoundField HeaderText="E-mail" DataField="Email"/>
                <asp:BoundField HeaderText="Telefono" DataField="Telefono"/>
                <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" DataFormatString="{0:d}"/>
                <asp:BoundField HeaderText="Legajo" DataField="Legajo"/>
                <asp:BoundField HeaderText="ID Plan" DataField="IDplan"/>
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario"/>
                <asp:BoundField HeaderText="Tipo de Persona" DataField="TipoPersona"/>
                <asp:CheckBoxField DataField="Habilitado" HeaderText="Habilitado" ItemStyle-HorizontalAlign="Center"/>
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
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="nombreTextBox"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nombreRequiredFieldValidator" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El nombre no puede estar vacío."></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="apellidoRequiredFieldValidator" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El apellido no puede estar vacío."></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="emailLabel" runat="server" Text="E-mail:"></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El email no puede estar vacío." Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="emailRegularExpressionValidator" runat="server" ControlToValidate="emailTextBox" ErrorMessage="Email incorrecto." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="direccionLabel" runat="server" Text="Dirección:"></asp:Label>
        <asp:TextBox ID="direccionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="direccionRequiredFieldValidator" runat="server" ControlToValidate="direccionTextBox" ErrorMessage="La dirección no puede estar vacía."></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="telefonoLabel" runat="server" Text="Teléfono:"></asp:Label>
        <asp:TextBox ID="telefonoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="telefonoRequiredFieldValidator" runat="server" ControlToValidate="telefonoTextBox" ErrorMessage="El teléfono no puede estar vacío."></asp:RequiredFieldValidator>
        <br />
        <uc:FechaNacimientoUserControl ID="fechaNacimientoUserControl" runat="server" />
        <br />
        <asp:Label ID="legajoLabel" runat="server" Text="Legajo:"></asp:Label>
        <asp:TextBox ID="legajoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="legajoFieldValidator" runat="server" ControlToValidate="legajoTextBox" ErrorMessage="El legajo no puede estar vacío."></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="legajoRangeValidator" runat="server" ControlToValidate="legajoTextBox" ErrorMessage="El legajo debe ser un número." Type="Integer" MinimumValue="0" MaximumValue="99999"></asp:RangeValidator>
        <br />
        <asp:Label ID="planLabel" runat="server" Text="Plan:"></asp:Label>
        <asp:DropDownList ID="ddlPlan" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado:"></asp:Label>
        <asp:CheckBox ID="habilitadoCheckBox" runat="server"></asp:CheckBox>
        <br />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario:"></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nombreUsuarioRequiredFieldValidator" runat="server" ControlToValidate="nombreUsuarioTextBox" ErrorMessage="El nombre de usuario no puede estar vacío."></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="tipoPersonaLabel" runat="server" Text="Tipo de persona:"></asp:Label>
        <asp:DropDownList ID="ddlTipoPersona" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave:"></asp:Label>
        <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="claveRequiredFieldValidator" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave no puede estar vacía."></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir clave:"></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="repetirClaveRequiredFieldValidator" runat="server" ControlToValidate="repetirClaveTextbox" ErrorMessage="La confirmación de clave no puede estar vacía." Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="claveCompareValidator" runat="server" ControlToValidate="repetirClaveTextBox" ControlToCompare="claveTextBox" Operator="Equal" ErrorMessage="Las claves ingresadas no coinciden."></asp:CompareValidator>
        <asp:ValidationSummary ID="erroresValidationSummary" runat="server"/>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" Visible="false" runat="server" Style="margin-top: 5px">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" Text="Aceptar" OnClick="aceptarLinkButton_Click"></asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" Text="Cancelar" OnClick="cancelarLinkButton_Click" CausesValidation="False"></asp:LinkButton>
    </asp:Panel>
</asp:Content>
