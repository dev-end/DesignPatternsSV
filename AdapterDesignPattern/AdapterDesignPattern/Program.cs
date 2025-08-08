
namespace AdapterDesignPattern // this pattern you dont plan in advance. Agar naya incompatible object aaya to we use it.
{
    internal interface ICommunication
    {
        void SendMessage(string message);
    }

    class Email : ICommunication
    {
        string recipient;

        public Email(string recipient)
        {
            this.recipient = recipient;
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"Email sent to {recipient}");
        }
    }

    class SMS : ICommunication
    {
        string recipient;
        public SMS(string recipient)
        {
            this.recipient = recipient;
        }
        public void SendMessage(string message)
        {
            Console.WriteLine($"Email sent to {recipient}");
        }
    }

    class Subscriber
    {

        public string firstName;
        public string lastName;
        List<ICommunication> notifier = new List<ICommunication>();

        public Subscriber(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void AddNotifier(ICommunication comm)
        {
            notifier.Add(comm);
        }

        public void NotifySubscriber(string message)
        {
            foreach (var comm in notifier)
                comm.SendMessage(firstName);
        }
    }

    class Telegram // incompatible object aaya, ab kaise ? :-)
    {
        long number;
        public void SendTelegramMessage(string msg)
        {
            Console.WriteLine($"Telegram {msg} sent to recipient {number}");
        }
    }

    class AdapterTelegram : ICommunication
    {
        private Telegram _telegram; // dont say new Telegram here, instead pass the object
        public AdapterTelegram(Telegram telegram)
        {
            _telegram = telegram;
        }
        public void SendMessage(string message)
        {
            _telegram.SendTelegramMessage(message); //recipient 
            Console.WriteLine("used telegram msg to forward");
        }
    }

    internal class AdapterDemo
    {
        static void Main(string[] args)
        {
            var list = new List<Subscriber>();

            var bill = new Subscriber("Bill", "Gates");
            bill.AddNotifier(new Email("billg@microsoft.com"));
            list.Add(bill);

            var elon = new Subscriber("Elon", "Musk");
            elon.AddNotifier(new SMS("1-CALL-ELONMUSK"));
            list.Add(elon);

            var sanjay = new Subscriber("Sanjay", "Vyas");
            sanjay.AddNotifier(new AdapterTelegram(new Telegram()));
            list.Add(sanjay);

            foreach (var person in list)
                person.NotifySubscriber("Bill due in 3 days");
        }
    }
}
