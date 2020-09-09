using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntoTheArena.Shared;
using Microsoft.AspNetCore.SignalR;

namespace IntoTheArena.Server.Hubs
{
    public class ChatHub : Hub
    {

        private static readonly Dictionary<string, string> userLookup = new Dictionary<string, string>();


        public async Task SendMessage(string user, string message)
        {

            bool kludge = false;

            string fooId = "";
            if (kludge)
            {
                fooId = "";
                await Clients.Users(fooId).SendAsync(Messages.RECIEVE, user, message);
                //await Clients.Clients(fooId).SendAsync(Messages.RECIEVE, user, message);
                //await Clients.Users(fooId).SendAsync(Messages.RECIEVE, message);

            }
            else
            {
                await Clients.Users("cipherRex@gmail.com").SendAsync(Messages.RECIEVE, message);
                //await Clients.All.SendAsync(Messages.RECIEVE, user, message);

            }


            //await Clients.All.SendAsync(Messages.RECIEVE, user, message);
            //await Clients.Users(fooId).SendAsync(Messages.RECIEVE, user, message);

        }

        public async Task Register(string username)
        {
            var currentId = Context.ConnectionId;
            if (!userLookup.ContainsKey(currentId))
            {
                userLookup.Add(currentId, username);
                await Clients.AllExcept(currentId).SendAsync(
                        Messages.RECIEVE,
                        username, $"{username} joined the chat"
                    );
            }
        }

        public override Task OnConnectedAsync()
        {

            Console.WriteLine("Connected");
            return base.OnConnectedAsync();
        }



    }
}
