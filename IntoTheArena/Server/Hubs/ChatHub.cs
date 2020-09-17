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

        private List<string> allConnetionIdsBut(List<string> recipientIDs)
        {

            return _userLookup.Where(x => recipientIDs.All(p2 => p2 != x.Value))
                     .Select(x => x.Key)
                     .ToList();

        }

        public async Task SendChallenge(string user, string recipient,string message)
        {
            await Clients.AllExcept(allConnetionIdsBut(recipient)).SendAsync(Messages.CHALLENGE, user, message);
        }

        public async Task AcceptChallenge(string ChallengerId, string ChallengeeId)
        {
            List<string> list = new List<string>();
            list.Add(ChallengerId);
            list.Add(ChallengeeId);

            await Clients.AllExcept(allConnetionIdsBut(list)).SendAsync(Messages.ACCEPT_CHALLENGE);
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
