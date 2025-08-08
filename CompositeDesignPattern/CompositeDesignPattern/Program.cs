namespace CompositeDesignPattern
{
    interface IEmployee
    {
        public decimal calculateSalary(List<IEmployee> employee);
    }

    class Manager : IEmployee
    {
        public string name;
        public decimal salary;
        List<IEmployee> employee;
        public Manager(string name, decimal salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public decimal calculateSalary(List<IEmployee> employee)
        {
            
        }
    }

    class Developer : IEmployee
    {
        public string name;
        public decimal salary;

        public Developer(string name, decimal salary)
        {
            this.name = name;
            this.salary = salary;
        }
        public decimal calculateSalary(List<IEmployee> developers)
        {
            decimal sum = 0;
            foreach (var devs in developers)
                sum += ((Developer)devs).salary;

            return sum;
        }

    }

    class Ceo : IEmployee
    {
        public string name;
        public decimal salary;

        public Ceo(string name, decimal salary)
        {
            this.name = name;
            this.salary = salary;
        }
        public decimal calculateSalary(List<IEmployee> managerList)
        {
            decimal sum = 0;
            foreach (var manager in managerList)
                sum += ((Manager)manager).salary;

            return sum;
        }

    }

    public class CompositeDemo
    {
        public static void Main()
        {
            var devList = new List<Developer>();
            var mgrList = new List<Manager>();

            devList.Add(new Developer("Brendan Eich", 100_000));
            devList.Add(new Developer("James Gosling", 200_000));
            devList.Add(new Developer("Guido van Rossum", 250_000));
            devList.Add(new Developer("Anders Hejlsberg", 350_000));



            mgrList.Add(new Manager("Dennis Ritchie", 500_000));
            mgrList.Add(new Manager("Alan Kay", 500_000));

            decimal sum = 0;
            foreach (var dev in devList)
                sum += dev.salary;

            foreach (var mgr in mgrList)
                sum += mgr.salary;

            Console.WriteLine($"The total company salary is {sum}");
        }
    }

}
