using ApiProject.Controllers;
using ApiProject.Dtos;
using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Test.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// Please Comment and Uncomment the test methods in order to do one per time, because the API has a wait time after a request have been done
        /// </summary>
        private readonly HomeController _homeController;

        public HomeControllerTest()
        {
            _homeController = new HomeController();
        }

        [TestMethod]
        public void GetAll()
        {
            List<EmployeeDto> refType = new List<EmployeeDto>();
            var response = _homeController.List().Result;

            Assert.IsInstanceOfType(response, refType.GetType());
        }

        [TestMethod]
        public void EmployeeById()
        {
            int id = 23;
            int anualSalary = 1277400;

            EmployeeDto result = _homeController.EmployeeById(id).Result;

            Assert.AreEqual(anualSalary, result.Employee_anual_salary);
        }
    }
}
