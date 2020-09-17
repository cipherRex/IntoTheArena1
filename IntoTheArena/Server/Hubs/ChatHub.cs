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

        private static readonly Dictionary<string, string> _userLookup = new Dictionary<string, string>();

        private List<string>  allConnetionIdsBut(string recipientID) 
        { 
            return _userLookup.Where(x => x.Value != recipientID)
                     .Select(x => x.Key)
                     .ToList();
        }

        public async Task SendChallenge(string user, string recipient,string message)
        {

            //var playersToExclude = _userLookup.Where(x => x.Value != recipient)
            //     .Select(x => x.Key)
            //     .ToList();

            //await Clients.AllExcept(playersToExclude).SendAsync(Messages.CHALLENGE, user, message);
            await Clients.AllExcept(allConnetionIdsBut(recipient)).SendAsync(Messages.CHALLENGE, user, message);


        }

        public async Task Register(string username)
        {
            

            var currentId = Context.ConnectionId;
            if (!_userLookup.ContainsKey(currentId))
            {
                _userLookup.Add(currentId, username);
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
