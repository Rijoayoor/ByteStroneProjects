partial class Program
{
    class Employee
    {
        

        public string Name { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }
        public double Salary { get; set; }
        public Employee(string name, int age, string jobTitle, double salary)
        {
            Name = name;
            Age = age;
            JobTitle = jobTitle;
            Salary = salary;
        }

        

        public override string ToString()
        {
            return $"{Name},{Age},{JobTitle},{Salary}";
        }
    }
}