using Mediator.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.V3
{
    public abstract class TeamMember
    {
        private ChatRoom chatRoom;

        public string Name { get; }

        protected TeamMember(string name)
        {
            this.Name = name;
        }

        internal void SetChatroom(ChatRoom chatroom) { 
            this.chatRoom = chatroom;
        }

        public void Send(string message)
        {
            this.chatRoom.Send(this.Name, message);
        }
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"from {from}: '{message}'");
        }
        public void SendTo<T>(string message) where T : TeamMember
        {
            this.chatRoom.SendTo<T>(this.Name, message);
        }
    }
}
