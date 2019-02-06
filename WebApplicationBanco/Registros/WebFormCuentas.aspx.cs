using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationBanco.Registros
{
    public partial class WebFormCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            NombreTextBox.Text = string.Empty;
            BalanceTextBox.Text = string.Empty;
        }

        private Cuentas LlenaClase()
        {
            return new Cuentas(
                ToInt(IdTextBox.Text),
                DateTime.Parse(FechaTextBox.Text),
                NombreTextBox.Text,
                0
                );
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
            {
                if (Page.IsValid)
                {
                    RepositorioBase<Cuentas> rep = new RepositorioBase<Cuentas>();

                    if (ToInt(IdTextBox.Text) == 0)
                    {
                        if (rep.Guardar(LlenaClase()))
                        {
                            CallModal("Se guardo la cuenta");
                            Limpiar();

                        }
                    }
                    else
                    {
                        if (rep.Modificar(LlenaClase()))
                        {
                            CallModal("Se modifico la cuenta");
                            Limpiar();
                        }
                    }
                }
            }
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
        }

        protected void BuscarLinkButton_Click1(object sender, EventArgs e)
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuentas = repositorio.Buscar(ToInt(IdTextBox.Text));
            if (cuentas != null)
            {
                FechaTextBox.Text = cuentas.Fecha.ToString("yyyy-MM-dd");
                NombreTextBox.Text = cuentas.Nombre;
                BalanceTextBox.Text = cuentas.Balance.ToString();
            }
            else
                CallModal("Esta cuenta no existe");
        }

        protected void NuevoLinkButton_Click1(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarLinkButton_Click1(object sender, EventArgs e)
        {
            CuentaRepositorio repositorio = new CuentaRepositorio();
            Cuentas cuentas = repositorio.Buscar(ToInt(IdTextBox.Text));

            if (cuentas != null)
            {
                // if (c.Depositos.Count == 0)
                //{
                if (repositorio.Eliminar(ToInt(IdTextBox.Text)))
                {
                    CallModal("Se elimino la cuenta");
                    Limpiar();
                }
                else
                    CallModal("No se elimino la cuenta");
                /* }
                 else
                     CallModal("Esta cuenta posee depositos enlazados a ella, no se puede eliminar");*/
            }
        }
    }
}
