using API.Core.Business.Entities;
using API.Uses.Cases.UOWork;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VentaDeVehiculo.Controllers;

namespace Test
{
    public class UnitTest1
    {
        private readonly IUnitOfWork _context = A.Fake<IUnitOfWork>();
        private readonly ILogger<ClienteController> _logger = A.Fake<ILogger<ClienteController>>();

    
        Cliente cliente = new Cliente()
        {
            Id = 1,
            Nombre = "Lucas",
            Apellido = "Luduena",
            DNI = "38.468.465",
            Direccion = "Santa Fe 2323"
        };


        #region GetTest
        [Fact]
        public void GetTestCliente()
        {
            var controller = new ClienteController(_context, _logger);
            var result = controller.Get();
            Assert.NotNull(result);
        }
        #endregion


        #region PostTest
        [Fact]
        public void PostTestCliente()
        {
            var controller = new ClienteController(_context, _logger);
            var result = controller.Post(cliente);
            Assert.IsType<OkResult>(result);
        }
        #endregion


        #region DeleteTestException
        [Fact]
        public void DeleteTestClienteException()
        {
            A.CallTo(() => _context.ClienteRepo.GetById(1)).Returns(null);
            var controller = new ClienteController(_context, _logger);
            var result = controller.Delete(1);
            Assert.IsType<NotFoundResult>(result);
        }
        #endregion


        #region DeleteTest
        [Fact]
        public void DeleteTestCliente()
        {
            var controller = new ClienteController(_context, _logger);
            var result = controller.Delete(cliente.Id);
            Assert.IsType<OkResult>(result);
        }
        #endregion


    }
}