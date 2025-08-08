using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignPattern
{
    internal interface IMediator
    {
        //public void SendMessage(string message);
        public void AddFriend(object friend);

        public void MessageAll(string message);
        public void MessageOne(int id, string message);
    }

}
