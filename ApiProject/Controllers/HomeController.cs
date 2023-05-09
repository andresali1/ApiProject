using ApiProject.Dtos;
using ApiProject.Models;
using ApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace ApiProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService_Api _service_Api;

        public HomeController()
        {
            _service_Api = new Service_Api();
        }

        public IActionResult Index()
        {
            Employee model = new Employee();
            return View(model);
        }

        public async Task<IActionResult> EmployeeList(Employee model)
        {
            if(model.id > 0)
            {
                EmployeeDto employee = await EmployeeById(model.id);
                return View("/Views/Home/detail.cshtml", employee);
            }
            else
            {
                List<EmployeeDto> list = await List();
                return View("/Views/Home/list.cshtml", list);
            }
        }

        public async Task<List<EmployeeDto>> List()
        {
            List<Employee> result = await _service_Api.GetAll();
            List<EmployeeDto> list = new List<EmployeeDto>();
            if(result.Count > 0)
            {
                foreach (Employee emp in result)
                {
                    list.Add(new EmployeeDto(emp.id, emp.employee_name ?? "", emp.employee_salary, emp.employee_age, emp.profile_image ?? ""));
                }
            }            
            return list;
        }

        public async Task<EmployeeDto> EmployeeById(int id)
        {
            EmployeeDto employee;
            Employee result = await _service_Api.GetById(id);
            if (result == null)
            {
                employee = new EmployeeDto();
            }
            else
            {
                employee = new EmployeeDto(result.id, result.employee_name ?? "", result.employee_salary, result.employee_age, result.profile_image ?? "");
            }
            return employee;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}