namespace ApiProject.Models
{
    public class ApiGetAll_Result
    {
        public string status { get; set; }
        public List<Employee> data { get; set; }
        public string message { get; set; }
    }
}
