using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplicationBanco.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuenta = new Cuentas();
            bool paso = false;

            cuenta.CuentaId = 4;
            cuenta.Fecha = DateTime.Now;
            cuenta.Nombre = "Pedro";
            cuenta.Balance = 0;

            paso = repositorio.Guardar(cuenta);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            var cuenta = Buscar();
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();

            bool paso = false;
            cuenta.Nombre = "Anthony";
            paso = repositorio.Modificar(cuenta);
            Assert.AreEqual(true, paso);
        }

        public Cuentas Buscar()
        {
            int id = 3;
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuenta = new Cuentas();
            cuenta = repositorio.Buscar(id);
            return cuenta;
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            int id = 4;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void BuscarD()
        {
            int id = 3;
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            Cuentas cuenta = new Cuentas();
            cuenta = repositorio.Buscar(id);
            Assert.IsNotNull(cuenta);
        }

        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Cuentas> repositorio = new RepositorioBase<Cuentas>();
            List<Cuentas> lista = new List<Cuentas>();
            Expression<Func<Cuentas, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }

        //Test de Depósitos.
        [TestMethod]
        public void GuardarD()
        {
            DepositoRepositorio repositorio = new DepositoRepositorio();
            Depositos deposito = new Depositos();
            bool paso = false;

            deposito.DepositoId = 3;
            deposito.Fecha = DateTime.Now;
            deposito.CuentaId = 3;
            deposito.Concepto = "Pago Jose";
            deposito.Monto = 100;

            paso = repositorio.Guardar(deposito);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void ModificarMD()
        {
            var deposito = BuscarMD();
            DepositoRepositorio repositorio = new DepositoRepositorio();

            bool paso = false;
            deposito.Concepto = "Pago de Alfredo";
            paso = repositorio.Modificar(deposito);
            Assert.AreEqual(true, paso);
        }

        public Depositos BuscarMD()
        {
            int id = 2;
            DepositoRepositorio repositorio = new DepositoRepositorio();
            Depositos deposito = new Depositos();
            deposito = repositorio.Buscar(id);
            return deposito;
        }

        [TestMethod]
        public void EliminarD()
        {
            DepositoRepositorio repositorio = new DepositoRepositorio();
            int id = 3;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void BuscarDm()
        {
            int id = 1;
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            Depositos deposito = new Depositos();
            deposito = repositorio.Buscar(id);
            Assert.IsNotNull(deposito);
        }

        [TestMethod()]
        public void GetListD()
        {
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            List<Depositos> lista = new List<Depositos>();
            Expression<Func<Depositos, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }
    }
}
   
