using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationBanco.Consultas
{
    public partial class WebConsultDeposito : System.Web.UI.Page
    {
        Expression<Func<Depositos, bool>> filter = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DesdeTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

            }
        }

        private void LlenarGridView()
        {
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            DepositoGridView.DataSource = repositorio.GetList(filter);
            DepositoGridView.DataBind();
        }

        private List<Cuentas> FilaVacia()
        {
            List<Cuentas> f = new List<Cuentas>();
            f.Add(new Cuentas());
            return f;
        }

        public int ToInt(string text)
        {
            return (string.IsNullOrWhiteSpace(text)) ? 0 : int.Parse(text);
        }

        public decimal ToDecimal(string text)
        {
            return (string.IsNullOrWhiteSpace(text)) ? 0 : decimal.Parse(text);
        }

        private void Filtrar()
        {
            int dato = 0;

            string i = DateTime.Parse(DesdeTextBox.Text).Date.ToString("yyyy-MM-dd");
            DateTime fInicial = DateTime.Parse(i);

            string f = DateTime.Parse(HastaTextBox.Text).Date.ToString("yyyy-MM-dd");
            DateTime fFinal = DateTime.Parse(f);

            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filter = x => true;
                    break;

                case 1://DepositoId
                    dato = ToInt(BuscarTextBox.Text);
                    filter = (x => x.DepositoId == dato && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;

                case 2://CuentaId
                    dato = ToInt(BuscarTextBox.Text);
                    filter = (x => x.CuentaId == dato && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;

                case 3://Fecha
                    DateTime date = DateTime.Parse(BuscarTextBox.Text);
                    filter = (x => x.Fecha == date);
                    break;

                case 4://Concepto
                    dato = ToInt(BuscarTextBox.Text);
                    filter = (x => x.Concepto.Contains(BuscarTextBox.Text) && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;

                case 5://Monto
                    int monto = int.Parse(BuscarTextBox.Text);
                    filter = (x => x.Monto >= monto && ((x.Fecha >= fInicial) && (x.Fecha <= fFinal)));
                    break;
            }
        }


        protected void CuentaGridView_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            

        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
        }

        protected void BuscarLinkButton_Click1(object sender, EventArgs e)
        {

            Filtrar();
            LlenarGridView();
        }

        protected void DepositoGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            DepositoGridView.DataSource = repositorio.GetList(filter);
            //DepositoGridView.PageIndex = e.NewPageIndex;
            DepositoGridView.DataBind();
        }
    }
}