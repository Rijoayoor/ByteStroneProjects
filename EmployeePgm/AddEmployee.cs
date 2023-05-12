partial class Program
{
    static void AddEmployee(List<Employee> employees)
    {
        Console.Write("Enter employee name: ");
        string? name = Console.ReadLine();

        Console.Write("Enter employee age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter employee job title: ");
        string? jobTitle = Console.ReadLine();

        Console.Write("Enter employee salary: ");
        double salary = double.Parse(Console.ReadLine());

        Employee employee = new Employee(name, age, jobTitle, salary);
        employees.Add(employee);
        Console.WriteLine("Employee added successfully.");

        List<string> contents = new List<string>();
        foreach (Employee item in employees)
        {
            System.Console.WriteLine(item);
            contents.Add(item.ToString());
        }

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