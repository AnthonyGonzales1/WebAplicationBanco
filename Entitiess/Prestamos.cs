using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public float Interes { get; set; }
        public int Tiempo { get; set; }
        public decimal Capital { get; set; }
        public decimal Monto { get; set; }
        public virtual List<Cuotas> Detalle { get; set; }

        public Prestamos()
        {
            PrestamoId = 0;
            CuentaId = 0;
            Fecha = DateTime.Now;
            Interes = 0;
            Tiempo = 0;
            Monto = 0;
            Detalle = new List<Cuotas>();
        }

        public Prestamos(int id, int cuentaId, DateTime fecha, decimal capital, float interes, int tiempo, decimal monto)
        {
            PrestamoId = id;
            CuentaId = cuentaId;
            Fecha = fecha;
            Interes = interes;
            Tiempo = tiempo;
            Monto = monto;
            Detalle = new List<Cuotas>();
        }

        public Prestamos(int id, int cuentaId, DateTime fecha, decimal capital, float interes, int tiempo, decimal monto, List<Cuotas> detalle)
        {
            PrestamoId = id;
            CuentaId = cuentaId;
            Fecha = fecha;
            Capital = capital;
            Interes = interes;
            Tiempo = tiempo;
            Monto = monto;
            Detalle = detalle;
        }

        public void AddCuota(int prestamoId, decimal capital, decimal interes, decimal cuota, decimal balance)
        {
            Detalle.Add(new Cuotas(0, prestamoId, capital, interes, cuota, balance));
        }

        public void AddCuota(string prestamoId, string nopago, string capital, string interes, string cuota, string balance)
        {

            Detalle.Add(new Cuotas(
                0,
                int.Parse(prestamoId),
                decimal.Parse(capital),
                decimal.Parse(interes),
                decimal.Parse(cuota),
                decimal.Parse(balance)));
        }

        public void AddCuota(Cuotas cuota)
        {
            Detalle.Add(cuota);
        }
    }
}
