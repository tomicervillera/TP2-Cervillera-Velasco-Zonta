<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/Site.master" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                <asp:BoundField HeaderText="E-mail" DataField="EMail"/>
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario"/>
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="gridAcionsPanel" runat="server">
                <asp:LinkButton ID="editarLinkButton" runat="server" Text="Editar" OnClick="editarLinkButton_Click"></asp:LinkButton>
                <asp:LinkButton ID="eliminarLinkButton" runat="server" Text="Eliminar" OnClick="eliminarLinkButton_Click"></asp:LinkButton>
                <asp:LinkButton ID="nuevoLinkButton" runat="server" Text="Nuevo" OnClick="nuevoLinkButton_Click"></asp:LinkButton>
            </asp:Panel>
    <br />

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nombreRequiredFieldValidator" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El nombre no puede estar vacío." Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido:"></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="apellidoRequiredFieldValidator" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El apellido no puede estar vacío." Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="emailLabel" runat="server" Text="E-mail:"></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El email no puede estar vacío." Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado:"></asp:Label>
        <asp:CheckBox ID="habilitadoCheckBox" runat="server"></asp:CheckBox>
        <br />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario:"></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nombreUsuarioRequiredFieldValidator" runat="server" ControlToValidate="nombreUsuarioTextBox" ErrorMessage="El nombre de usuario no puede estar vacío." Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave:"></asp:Label>
        <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="claveRequiredFieldValidator" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave no puede estar vacía." Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir clave:"></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="repetirClaveRequiredFieldValidator" runat="server" ControlToValidate="repetirClaveTextbox" ErrorMessage="La confirmación de clave no puede estar vacía." Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" Text="Aceptar" OnClick="aceptarLinkButton_Click"></asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" Text="Cancelar" OnClick="cancelarLinkButton_Click"></asp:LinkButton>
    </asp:Panel>
</asp:Content>
