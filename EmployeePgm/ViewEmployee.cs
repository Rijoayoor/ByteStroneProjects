partial class Program
{
    static List<Employee> ReadEmployeesFromFile()
    {
        List<Employee> employees = new List<Employee>();
        {
            if (File.Exists(@"employee.txt"))
            {

                using (StreamReader reader = new StreamReader(@"employee.txt"))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        string name = parts[0];
                        int age = int.Parse(parts[1]);
                        string jobTitle = parts[2];
                        double salary = double.Parse(parts[3]);
                        Employee employee = new Employee(name, age, jobTitle, salary);
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }
    }
    static void ViewEmployees(List<Employee> employees)
    {
        Console.WriteLine("Employee List:");
        foreach (Employee employee in employees)
        {
            // Console.WriteLine(employee);
            System.Console.WriteLine($"Name:{employee.Name}\tAge:{employee.Age}\tJobtitle:{employee.JobTitle}\tSalary:{employee.Salary}");
        }
    }
}