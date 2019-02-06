<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebConsultCuenta.aspx.cs" Inherits="WebApplicationBanco.Consultas.WebConsultCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
    <div class="card-header text-center text-white bg-primary">
        <h3>Consulta de cuentas</h3>
    </div>
    <div class="card-body">
            <!---->
            <div class="row justify-content-center">
                <div class="col-lg-4">
                    <asp:Label ID="FiltroLabel" runat="server" Text="Filtrar-por">
                        Filtro:
                    </asp:Label>
                    <asp:DropDownList ID="FiltroDropDownList" runat="server" CssClass="form-control">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>CuentaId</asp:ListItem>
                        <asp:ListItem>Fecha</asp:ListItem>
                        <asp:ListItem>Nombre</asp:ListItem>
                        <asp:ListItem>Balance</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-lg-1">
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="BuscarLabel" runat="server" Text="Buscar">Buscar:</asp:Label>
                    <asp:TextBox ID="BuscarTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-lg-1 p-0">
                    <asp:LinkButton ID="BuscarLinkButton" runat="server" CssClass="btn btn-secondary mt-4" OnClick="BuscarLinkButton_Click1" >
                        <span class="fas fa-search"></span>
                        Buscar
                    </asp:LinkButton>
                    <br />
                    <div class="form-group col-md-2">
                        <asp:Label ID="Label1" runat="server" Text="Desde" />
                        <asp:TextBox ID="DesdeTextBox" runat="server" class="form-control input-group" TextMode="Date" />
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label ID="Label2" runat="server" Text="Hasta" />
                        <asp:TextBox ID="HastaTextBox" runat="server" class="form-control input-group" TextMode="Date" />
                    </div>
                    <br />
                </div>
        </div>

            <!--Grid-->
            <div class="row justify-content-center mt-3">
                <div class="col-lg-11">
                    <asp:GridView ID="CuentaGridView" runat="server" AllowPaging="true" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-responsive-lg" PageSize="7" OnPageIndexChanged="CuentaGridView_SelectedIndexChanged1" OnSelectedIndexChanged="CuentaGridView_SelectedIndexChanged1" >
                        <Columns>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Balance" HeaderText="Balance" />
                        </Columns>
                    </asp:GridView>
                </div>
        </div>

            <!--Card body end-->
        </div>

        <!--Card end-->
    </div>
</asp:Content>
