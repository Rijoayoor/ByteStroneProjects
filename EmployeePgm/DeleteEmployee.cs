partial class Program
{
    static void DeleteEmployee(List<Employee> employees)
    {
        employees.Clear();
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
            System.Console.Write("Enter Employee name to remove");
            string? nameToRemove = Console.ReadLine();
            Employee? employeeToRemove = employees.Find(item => item.Name?.ToLower() == nameToRemove?.ToLower());
            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
                System.Console.WriteLine("Employee deleted Successfully");
            }
            else
            {
                System.Console.WriteLine("Employee not found");
            }
        }

        // System.Console.WriteLine("updated list is:");
        // foreach (Employee item in employees)
        // {
        //     System.Console.WriteLine(item);
        // }

        // List<string> contents = new List<string>();
        // foreach (Employee item in employees)
        // {

        //     contents.Add(item.ToString());
        // }

        // using (StreamWriter writer = new StreamWriter(@"employee.txt"))
        // {
        //     foreach (string item in contents)
        //     {
        //         writer.WriteLine(item);
        //     }
        //     // Flush the buffer and close the StreamWriter
        //     writer.Flush();
        // }
    }

}