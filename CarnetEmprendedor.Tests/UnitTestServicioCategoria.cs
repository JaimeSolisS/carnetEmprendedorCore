using CarnetEmprendedor.Data;
using CarnetEmprendedor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarnetEmprendedor.Tests
{
    [TestClass]
    public class UnitTestServicioCategoria
    {
        [TestMethod]
        public void No_CreateCategory_WithCategoryEventFieldEmpty()
        {
            var Servicio = new ServicioCategoria();

            var categoria = new Categoria()
            {
                // Category Field Is Empty in order to recieve an error
                //CategoriaEvento = "Evento 1"
            };

            int result = Servicio.CrearNuevoAsync(categoria).Result;
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void CreateCategory_WithCategoryEventFieldNotEmpty()
        {
            var Servicio = new ServicioCategoria();

            var categoria = new Categoria()
            {
                CategoriaEvento = "Evento 1"
            };

            int result = Servicio.CrearNuevoAsync(categoria).Result;
            Assert.IsTrue(result == 1);
        }
    }
}
