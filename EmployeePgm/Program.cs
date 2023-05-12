partial class Program
{
    static List<Employee> employees;
    static void Main(string[] args)
    {
        employees = ReadEmployeesFromFile();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Employee Management System");
            Console.WriteLine("1. View Employees");
            Console.WriteLine("2. Add Employee");
            Console.WriteLine("3. Edit Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Save Employee Data to File");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1-6): ");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewEmployees(employees);
                    break;
                case "2":
                    AddEmployee(employees);
                    break;
                case "3":
                    EditEmployee(employees);
                    break;
                case "4":
                    DeleteEmployee(employees);
                    break;
                case "5":
                    SaveEmployeesToFile(employees);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
