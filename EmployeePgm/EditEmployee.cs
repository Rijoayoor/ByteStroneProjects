partial class Program
{
    static void EditEmployee(List<Employee> employees)
    {
        Console.Write("Enter employee name to edit: ");
        string? name = Console.ReadLine();
        Employee? employeeToEdit = employees.Find(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (employeeToEdit == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }
        Console.Write("Enter updated employee name: ");
        string? updatedName = Console.ReadLine();

        Console.Write("Enter the updated employee age:");
        int updatedAge = int.Parse(Console.ReadLine());

        Console.Write("Enter the updated employee job title:");
        string? updatedJobTitle = Console.ReadLine();

        Console.Write("Enter the updated employee salary:");
        double updatedSalary = double.Parse(Console.ReadLine());

        employeeToEdit.Name = updatedName;
        employeeToEdit.Age = updatedAge;
        employeeToEdit.JobTitle = updatedJobTitle;
        employeeToEdit.Salary = updatedSalary;
        Console.Write("Employee updated successfully.");
    }
}