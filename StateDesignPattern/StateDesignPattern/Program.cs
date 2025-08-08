namespace StateDesignPattern
{
    //enum State
    //{
    //    open,
    //    closed,
    //    error,
    //}

    class Connection
    {
        IState state;
        //State state;

        public Connection()
        {
            state = new Open();
        }

        public void Connect()
        {
            //if (state == State.open)
            //    Console.WriteLine("Connection already open");
            //else if (state == State.error)
            //    Console.WriteLine("Connection is error state");
            //state = State.open;

            // new implementation
            this.state = state.Connect();
        }

        public void SendMessage(String? message)
        {
            //if (message == null)
            //    state = State.error;

            //if (state == State.error)
            //    Console.WriteLine("Connection is in error state");
            //else if (state == State.open)
            //    Console.WriteLine("Sending message " + message);
            //else
            //    Console.WriteLine("Connection is not open");

            // new implementation
            state.SendMessage(message);
        }

        public void Close()
        {
            //if (state == State.closed)
            //    Console.WriteLine("Connection is not open");

            // new implementation
            state.CloseConnection();
        }
    }

    public class StateDemo
    {
        public static void Main()
        {
            var connection = new Connection();
            connection.SendMessage("Hello");
            connection.Connect();
            connection.SendMessage("Hello");
            connection.Connect();
            connection.SendMessage(null);
            connection.Close();


        }
    }

    public class Open : IState
    {
        public IState SendMessage(string message)
        {
            Console.WriteLine($"Message sent successfully {message}");
            return this;
        }

        public IState CloseConnection()
        {
            Console.WriteLine("Connection closed.");
            return new Closed();
        }

        public IState Connect()
        {
            Console.WriteLine("Connection already opened.");
            return this;
        }
    }

    public class Closed : IState
    {
        public IState Connect()
        {
            Console.WriteLine("Connection just opened.");
            return new Open();
        }
        public IState SendMessage(string message)
        {
            Console.WriteLine("Cannot send message since connection is closed.");
            return this;
        }

        public IState CloseConnection()
        {
            Console.WriteLine("Connection already closed.");
            return this;
        }
    }

    public class Error : IState
    {
        public IState Connect()
        {
            Console.WriteLine("Error state: Cannot open connection");
            return this;
        }
        public IState SendMessage(string message)
        {
            Console.WriteLine("Error state: Cannot send message.");
            return this;
        }

        public IState CloseConnection()
        {
            Console.WriteLine("Error state -> Closed");
            return new Closed();
        }
    }

    public interface IState
    {
        public IState CloseConnection();
        public IState Connect();
        public IState SendMessage(string message);
    }
}
