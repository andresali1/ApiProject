using ApiProject.Models;
using ApiProject.Services;

namespace ApiProject.Test.Services
{
    [TestClass]
    public class Service_ApiTest
    {
        /// <summary>
        /// Please Comment and Uncomment the test methods in order to do one per time, because the API has a wait time after a request have been done
        /// </summary>
        private readonly Service_Api _service_Api;

        public Service_ApiTest()
        {
            _service_Api = new Service_Api();
        }

        [TestMethod]
        public void List()
        {
            int count = 24;

            List<Employee> result = _service_Api.GetAll().Result;

            Assert.AreEqual(count, result.Count);
        }

        [TestMethod]
        public void GetById()
        {
            int id = 1;
            Employee empRef = new Employee() { id = 1, employee_name = "Tiger Nixon", employee_salary = 320800, employee_age = 61, profile_image = "" };

            Employee result = _service_Api.GetById(id).Result;

            Assert.AreEqual(empRef.employee_name, result.employee_name);
        }
    }
}
