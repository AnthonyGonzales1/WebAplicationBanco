using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLL
{
    public class DepositoRepositorio : RepositorioBase<Depositos>
    {
        public DepositoRepositorio() : base()
        {

        }

        public override bool Guardar(Depositos depositos)
        {
            var cuenta = _contexto.Cuenta.Find(depositos.CuentaId);
            cuenta.Balance += depositos.Monto;
            _contexto.Entry(cuenta).State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();

            return base.Guardar(depositos);
        }

        public override bool Modificar(Depositos depositos)
        {
            var antdeposito = _contexto.Deposito.Include(x => x.Cuenta)
                            .Where(z => z.DepositoId == depositos.DepositoId)
                            .AsNoTracking()
                            .FirstOrDefault();

            Cuentas cuenta = antdeposito.Cuenta;
            cuenta.Balance -= antdeposito.Monto;

            cuenta.Balance += depositos.Monto;

            _contexto.Entry(cuenta).State = EntityState.Modified;

            _contexto.SaveChanges();

            return base.Modificar(depositos);
        }

        public override bool Eliminar(int id)
        {
            var deposito = Buscar(id);
            Cuentas cuenta = deposito.Cuenta;

            cuenta.Balance -= deposito.Monto;

            _contexto.Entry(cuenta).State = EntityState.Modified;
            _contexto.SaveChanges();

            return base.Eliminar(id);
        }

        public override Depositos Buscar(int id)
        {
            var depositos = _contexto.Deposito.Include(x => x.Cuenta)
                    .Where(z => z.DepositoId == id)
                    .FirstOrDefault();
            return depositos;
        }
    }

}
