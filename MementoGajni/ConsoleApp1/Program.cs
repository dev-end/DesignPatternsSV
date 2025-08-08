namespace ConsoleApp1
{
    public class Location
    {
        private static int locationSequence = 1;
        private int sequence = 0;
        private string city;

        public void MoveTo(string city)
        {
            this.city = city;
            this.sequence = Location.locationSequence++;
        }

        public void print()
        {
            System.Console.WriteLine($"{sequence}: {city}");
        }

        public void SetMemento(Location l)
        {
            new Memento().state = $"{l.sequence}+{l.city}";
        }

        public Memento getMemento()
        {
            
        }
    }


    // this is what you give to the caretaker
    public class Memento
    {
        public object state; // cannot have too many field. We need not change too many things
        public Object 
       
        public object AskMementoObject()
        {
            return this.state;
        }
    }

    public class MementoDemo // You implement the various different caretaker(persistence), waha se tum loge
    {
        public static void Main(string[] args)
        {
            var location = new Location();
            location.MoveTo("Kolkata");
            location.print();

            location.MoveTo("Indore");
            location.print();

            location.MoveTo("Mumbai");
            location.print();


            // a memento is not the actual object. You need to package the data. Not the same object, hence clone it.
            // create structure and pass it. Think in  terms of passing data. 
            // concatenation, packge, do whatever... not separate set of values..
            // Tomorrow i can use bankaccount class to j
            location.SetMemento(new  { state = location }); 


            // caretaker: this is missing.
            // it can be filesystem, any persistence
        }
    }
}
