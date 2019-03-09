using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrestamoRepositorio : RepositorioBase<Prestamos>
    {
        public PrestamoRepositorio() : base()
        {

        }

        public override bool Guardar(Prestamos prestamos)
        {
            Cuentas cuenta = _contexto.Cuenta.Find(prestamos.CuentaId);
            GuardarBalance(cuenta, prestamos.Monto);


            return base.Guardar(prestamos);
        }

        private void GuardarBalance(Cuentas cuenta, decimal valor)
        {
            cuenta.Balance += valor;
            _contexto.Entry(cuenta).State = EntityState.Modified;
        }

        private void SacarBalance(Cuentas cuenta, decimal valor)
        {
            cuenta.Balance -= valor;
            _contexto.Entry(cuenta).State = EntityState.Modified;
        }

        public override bool Modificar(Prestamos prestamos)
        {
            var prestamoAnt = BuscarAsNoTracking(prestamos.PrestamoId);
            var cuenta = _contexto.Cuenta.Find(prestamos.CuentaId);
            SacarBalance(cuenta, prestamoAnt.Monto);

            foreach (var item in prestamoAnt.Detalle)
                _contexto.Entry(item).State = EntityState.Deleted;


            foreach (var item in prestamos.Detalle)
                _contexto.Entry(item).State = (item.Id == 0) ? EntityState.Added : EntityState.Modified;

            GuardarBalance(cuenta, prestamos.Monto);

            return base.Modificar(prestamos);
        }

        public override bool Eliminar(int id)
        {
            Prestamos prestamo = Buscar(id);
            Cuentas cuenta = _contexto.Cuenta.Find(prestamo.CuentaId);
            SacarBalance(cuenta, prestamo.Monto);
            return base.Eliminar(id);
        }

        public override Prestamos Buscar(int id)
        {
            Prestamos prestamo = _contexto.Prestamo.
                                 Include(x => x.Detalle)
                                 .Where(z => z.PrestamoId == id)
                                 .FirstOrDefault();
            return prestamo;
        }

        public Prestamos BuscarAsNoTracking(int id)
        {
            Prestamos prestamo = _contexto.Prestamo.
                                 Include(x => x.Detalle)
                                 .Where(z => z.PrestamoId == id)
                                 .AsNoTracking()
                                 .FirstOrDefault();
            return prestamo;
        }

        public new List<Prestamos> GetList(Expression<Func<Prestamos, bool>> expression)
        {
            var lista = _contexto.Prestamo.Include(x => x.Detalle).Where(expression).ToList();
            return lista;
        }
    }
}
