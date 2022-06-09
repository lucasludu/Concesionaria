using API.Core.Business.Entities;
using API.Uses.Cases.UOWork;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using VentaDeVehiculo.Controllers;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        private readonly IUnitOfWork _context = A.Fake<IUnitOfWork>();
        Vehiculo vehiculo = new Vehiculo()
        {
            Id = 1,
            Precio = 1000,
            Modelo = "Logan",
            Marca = "Renault",
            DateModel = 2020,
            FechaBaja = new DateTime(2022,06,09)
        };
        Cliente cliente = new Cliente()
        {
            Id = 1,
            Nombre = "Lucas",
            Apellido = "Luduena",
            DNI = "38.468.465",
            Direccion = "Santa Fe 2323"
        };


        [Fact]
        public void GetTestCliente()
        {
            var controller = new ClienteController(_context);
            var result = controller.Get();
            Assert.NotNull(result);
        }

        [Fact]
        public void PostTestVehiculo()
        {
            var controller = new VehiculoController(_context);
            var result = controller.Post(vehiculo);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DeleteTestVehiculoException()
        {
            A.CallTo(() => _context.VehiculoRepo.GetById(1)).Returns(null);
            var controller = new VehiculoController(_context);
            var result = controller.Delete(1);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteTestCliente()
        {
            var controller = new ClienteController(_context);
            var result = controller.Delete(cliente.Id);
            Assert.IsType<OkResult>(result);
        }

    }}