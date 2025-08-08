namespace FacadeDesignPattern
{
    internal class FacadeDemo
    {
        static void Main(string[] args)
        {

            string name = "Anil Ambani";
            double loanAmount = 100_000;

            LoanSystemFacade facade = new LoanSystemFacade();
            facade.GiveMeLoan(name, loanAmount);

            string name2 = "Mukesh Ambani";
            double loanAmount2 = 100_000;
            facade.GiveMeLoan(name2, loanAmount2);

            //Bank bank = new Bank(null);
            //CreditRating rating = new CreditRating();
            //CreditHistory history = new CreditHistory();
            //Account account = bank.GetAccount(name);

            //bool approved = true;
            //if (null == account)
            //{
            //    Console.Error.WriteLine($"Application {name} does not have a bank account");
            //    approved = false;
            //}

            //if (!rating.EligibleForLoan(name))
            //{
            //    Console.Error.WriteLine($"Application {name} is not eligible for loan");
            //    approved = false;
            //}

            //if (history.HasDefaulted(name))
            //{
            //    Console.Error.WriteLine($"Application {name} has defaulted before");
            //    approved = false;
            //}

            //if (null != account)
            //{
            //    if (account.balance < loanAmount / 10)
            //    {
            //        Console.Error.WriteLine($"Application {name} does not have sufficient funds");
            //        approved = false;
            //    }
            //}

            //string appStr = approved ? " " : " not ";
            //Console.WriteLine($"Loan of amount {loanAmount} of {name} has{appStr}been approved");
        }
    }

    class Account
    {
        public int accountNumber;
        public string holdersName;
        public double balance;

        public Account(int accountNumber, string holdersName, double balance)
        {
            this.accountNumber = accountNumber;
            this.holdersName = holdersName;
            this.balance = balance;
        }
    }

    class Bank
    {
        List<Account> accounts = new();

        public Bank(Account account)
        {
            accounts.Add(new Account(101, "Mukesh Ambani", 100_000_000));
            accounts.Add(new Account(102, "Gautam Adani", 200_000_000));
            accounts.Add(new Account(103, "Anil Ambani", 100_000));
        }

        public Account GetAccount(string name)
        {
            string searchName = name.Trim();
            Account found = accounts
                                .Find(acc => acc.holdersName.Trim().Equals(searchName, StringComparison.OrdinalIgnoreCase));
            return found;
        }
    }


    class Rating
    {
        public string name;
        public int rating;

        public Rating(string name, int rating)
        {
            this.name = name;
            this.rating = rating;
        }
    }

    class CreditRating
    {
        List<Rating> ratings = new();

        public CreditRating()
        {
            ratings.Add(new Rating("Mukesh Ambani", 900));
            ratings.Add(new Rating("Gautam Adani", 750));
            ratings.Add(new Rating("Anil Ambani", 250));
        }

        public bool EligibleForLoan(string name)
        {
            string searchName = name.Trim();
            Rating person = ratings.Find(rating => rating.name.Trim().Equals(searchName, StringComparison.OrdinalIgnoreCase));
            if (null != person)
                return person.rating >= 650;
            return false;
        }
    }

    class LoanHistory
    {
        public string name;
        public int loanAmount;
        public string paid;

        public LoanHistory(string name, int loanAmount, string paid)
        {
            this.name = name;
            this.loanAmount = loanAmount;
            this.paid = paid;
        }
    }

    class CreditHistory
    {
        List<LoanHistory> history = new();

        public CreditHistory()
        {
            history.Add(new LoanHistory("Mukesh Ambani", 100000, "paid"));
            history.Add(new LoanHistory("Mukesh Ambani", 500000, "ongoing"));
            history.Add(new LoanHistory("Gautam Ambani", 10000000, "ongoing"));
            history.Add(new LoanHistory("Gautam Ambani", 15000000, "ongoing"));
            history.Add(new LoanHistory("Gautam Ambani", 2000000, "paid"));
            history.Add(new LoanHistory("Anil Ambani", 5000000, "paid"));
            history.Add(new LoanHistory("Anil Ambani", 10000000, "defaulted"));
        }

        public bool HasDefaulted(string name)
        {
            string searchName = name.Trim();
            LoanHistory result = history.Find(his =>
            {
                return his.name.Trim().Equals(searchName, StringComparison.OrdinalIgnoreCase)
                       && his.paid.Trim().Equals("defaulted", StringComparison.OrdinalIgnoreCase);
            });
            return null != result;
        }
    }
    class LoanSystemFacade
    {
        public void GiveMeLoan(string name, double loanAmount)
        {
            Bank bank = new Bank(null);
            CreditRating rating = new CreditRating();
            CreditHistory history = new CreditHistory();
            Account account = bank.GetAccount(name);

            bool approved = true;
            if (null == account)
            {
                Console.Error.WriteLine($"Application {name} does not have a bank account");
                approved = false;
            }

            if (!rating.EligibleForLoan(name))
            {
                Console.Error.WriteLine($"Application {name} is not eligible for loan");
                approved = false;
            }

            if (history.HasDefaulted(name))
            {
                Console.Error.WriteLine($"Application {name} has defaulted before");
                approved = false;
            }

            if (null != account)
            {
                if (account.balance < loanAmount / 10)
                {
                    Console.Error.WriteLine($"Application {name} does not have sufficient funds");
                    approved = false;
                }
            }

            string appStr = approved ? " " : " not ";
            Console.WriteLine($"Loan of amount {loanAmount} of {name} has{appStr}been approved");

        }
    }
}

// NOTES:
// Proxy has one to one(real object) mapping. It implements exactly same interface.
// Facade has one to many mapping. Most of the time it wont implement any of the interfaces.
// no pre planning, you add it later when you realize the complexity increase.
