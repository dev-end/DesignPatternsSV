using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPattern
{
    internal class Mediator : IMediator
    {
        public List<User> Friends = new List<User>();

        //public void SendMessage(object friend, )
        //{
        //    if (message == null)
        //    {
        //        return;
        //    }
        //    Console.WriteLine(message);
        //}

        public void AddFriend(object friend)
        {
            this.Friends.Add(friend);
        }

        public void MessageAll(string message)
        {
            foreach(object friend in this.Friends)
            {
                Console.WriteLine($"sending message to {friend.ToString()}");
            }
        }

        public void MessageOne(object obj, string message)
        {
            foreach(object friend in this.Friends)
            {
                if(friend.GetType() == typeof(object)) { 
                    Console.WriteLine($"Message sent to {friend.ToString()}");
                }
            }
        }
    }
}
