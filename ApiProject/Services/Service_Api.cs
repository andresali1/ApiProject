using ApiProject.Models;
using Newtonsoft.Json;

namespace ApiProject.Services
{
    public class Service_Api : IService_Api
    {
        private static string _baseUrl = "";

        public Service_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee> list = new List<Employee>();
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var response = await client.GetAsync("employees");

            if(response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiGetAll_Result>(json_response);
                list = result.data;
            }

            return list;
        }

        public async Task<Employee> GetById(int id)
        {
            Employee employee = new Employee();
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            var response = await client.GetAsync($"employee/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiGetById_Result>(json_response);
                employee = result.data;
            }

            return employee;
        }
    }
}
