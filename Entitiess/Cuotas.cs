using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Cuotas
    {
        [Key]
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal Cuota { get; set; }
        public decimal Balance { get; set; }

        public Cuotas()
        {
            Id = 0;
            PrestamoId = 0;
            Capital = 0;
            Interes = 0;
            Cuota = 0;
            Balance = 0;
        }

        public Cuotas(int id, int prestamoId, decimal capital, decimal interes, decimal cuota, decimal balance)
        {
            Id = id;
            PrestamoId = prestamoId;
            Capital = capital;
            Interes = interes;
            Cuota = cuota;
            Balance = balance;
        }
    }
}