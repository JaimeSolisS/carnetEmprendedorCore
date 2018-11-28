using CarnetEmprendedor.Data;
using CarnetEmprendedor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarnetEmprendedor.Tests
{
    [TestClass]
    public class UnitTestServicioCarrera
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [ClassInitialize]
        public void SetUp()
        {

        }

        [TestMethod]
        public void No_CreateCarreera_WithNameFieldEmpty()
        {
            var Servicio = new ServicioMateria();

            var carrera = new Materia()
            {
                // Name Field Is Empty in order to recieve an error
                //Nombre = "Carrera 1"
            };;

            int result = Servicio.CrearNuevoAsync(carrera).Result;
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void CreateCarrera_WithNameFieldNotEmpty()
        {
            var Servicio = new ServicioMateria();

            var Carrera = new Materia()
            {
                Nombre = "Carrera 1"
            };

            int result = Servicio.CrearNuevoAsync(Carrera).Result;
            Assert.IsTrue(result == 1);
        }
    }
}
