partial class Program
{
    static void SaveEmployeesToFile(List<Employee> employees)
    {
        List<string> contents = new List<string>();
        foreach (Employee item in employees)
        {

            System.Console.WriteLine(item);
            contents.Add(item.ToString());
        }

        using (StreamWriter writer = new StreamWriter(@"employee.txt"))
        {
            foreach (string item in contents)
            {
                writer.WriteLine(item);
            }
            // Flush the buffer and close the StreamWriter
            writer.Flush();
        }
        System.Console.WriteLine("Employee data updated to file!");



    }
}