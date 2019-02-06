using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Depositos
    {
        [Key]
        public int DepositoId { get; set; }
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public int Monto { get; set; }
        public virtual Cuentas Cuenta { get; set; }

        public Depositos()
        {
            DepositoId = 0;
            CuentaId = 0;
            Fecha = DateTime.Now;
            Concepto = string.Empty;
            Monto = 0;
        }

        public Depositos(int id, int cuentaId, DateTime fecha, string concepto, int monto)
        {
            DepositoId = id;
            CuentaId = cuentaId;
            Fecha = fecha;
            Concepto = concepto;
            Monto = monto;
        }
    }
}
