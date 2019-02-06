using BLL;
using BLLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationBanco.Registros
{
    public partial class WebFormDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                LlenarDropDown();

            FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

        }

        protected void CallModal(string mensaje)
        {
            Label label = (Label)Master.FindControl("MessageLabel");
            if (label != null)
                label.Text = mensaje;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert",
                            "$(function() { openModal(); });", true);
        }

        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        private void LlenarDropDown()
        {
            RepositorioBase<Cuentas> rep = new RepositorioBase<Cuentas>();
            CuentaDropDownList.DataSource = rep.GetList(x => true);
            CuentaDropDownList.DataValueField = "CuentaId";
            CuentaDropDownList.DataTextField = "Nombre";
            CuentaDropDownList.DataBind();
            CuentaDropDownList.Items.Insert(0, new ListItem("", ""));
        }

        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            ConceptoTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            CuentaDropDownList.SelectedIndex = 0;
        }

        private Depositos LlenaClase()
        {
            return new Depositos(
                ToInt(IdTextBox.Text),
                ToInt(CuentaDropDownList.SelectedValue),
                DateTime.Parse(FechaTextBox.Text),
                ConceptoTextBox.Text,
                int.Parse(MontoTextBox.Text)
                );
        }

        private void LlenarCampos(Depositos d)
        {
            FechaTextBox.Text = d.Fecha.ToString("yyyy-MM-dd");
            CuentaDropDownList.SelectedValue = d.CuentaId.ToString();
            ConceptoTextBox.Text = d.Concepto;
            MontoTextBox.Text = d.Monto.ToString();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        { }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        { }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        { }

        protected void GuardarLinkButton_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DepositoRepositorio repositorio = new DepositoRepositorio();

                if (ToInt(IdTextBox.Text) == 0)
                {
                    if (repositorio.Guardar(LlenaClase()))
                    {
                        CallModal("Se a registrado el deposito");
                        Limpiar();
                    }
                }
                else
                {
                    if (repositorio.Modificar(LlenaClase()))
                    {
                        CallModal("Se no se pudo registrar el deposito");
                        Limpiar();
                    }
                }
            }
        }

        protected void NuevoLinkButton_Click1(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarLinkButton_Click1(object sender, EventArgs e)
        {
            DepositoRepositorio repositorio = new DepositoRepositorio();
            Depositos depositos = repositorio.Buscar(ToInt(IdTextBox.Text));

            if (depositos != null)
            {
                if (repositorio.Eliminar(ToInt(IdTextBox.Text)))
                {
                    CallModal("Se a eliminado el deposito");
                    Limpiar();
                }
                else
                    CallModal("Se no se pudo eliminar el deposito");
            }
        }

        protected void BuscarLinkButton_Click1(object sender, EventArgs e)
        {
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            Depositos depositos = repositorio.Buscar(ToInt(IdTextBox.Text));
            if (depositos != null)
                LlenarCampos(depositos);
            else
                CallModal("Este deposito no existe");

        }
    }
}