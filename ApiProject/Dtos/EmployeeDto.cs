namespace ApiProject.Dtos
{
    public class EmployeeDto
    {
        private int id;
        private string employee_name;
        private int employee_salary;
        private int employee_anual_salary;
        private int employee_age;
        private string profile_image;

        public int Id { get => id; }
        public string Employee_name { get => employee_name; }
        public int Employee_salary { get => employee_salary; }
        public int Employee_anual_salary { get => employee_anual_salary; }
        public int Employee_age { get => employee_age; }
        public string Profile_image { get => profile_image; }
        public string Employee_salary_string { get; set; }
        public string Employee_anual_salary_string { get; set; }

        public EmployeeDto() { }

        public EmployeeDto(int id, string employee_name, int employee_salary, int employee_age, string profile_image)
        {
            this.id = id;
            this.employee_name = employee_name;
            this.employee_salary = employee_salary;
            this.employee_anual_salary = employee_salary * 12;
            this.employee_age = employee_age;
            this.profile_image = profile_image;
            Employee_salary_string = String.Format("{0:C0}", employee_salary);
            Employee_anual_salary_string = String.Format("{0:C0}", Employee_anual_salary);
        }
    }
}
