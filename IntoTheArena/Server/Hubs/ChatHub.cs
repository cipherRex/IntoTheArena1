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

        public async Task SendCombatResult(List<string> PlayerIds, string message)
        {
            await Clients.AllExcept(allConnetionIdsBut(PlayerIds)).SendAsync(Messages.COMBAT_ROUND_RESULT,  message);
        }

        public async Task AcceptChallenge(string CombatSessionId,string user, string Player1Id, string Player2Id, string Fighter1Id, string Fighter2Id)
        {
            //List<string> list = new List<string>();
            //list.Add(Player1Id);
            //list.Add(Player2Id);

            //Dictionary<string, string> message = new Dictionary<string, string>();
            //message["Player1Id"] = Player1Id;
            //message["Fighter1Id"] = Fighter1Id;
            //message["Player2Id"] = Player2Id;
            //message["Fighter2Id"] = Fighter2Id;

            //await Clients.AllExcept(allConnetionIdsBut(list)).SendAsync(Messages.ACCEPT_CHALLENGE, user,System.Text.Json.JsonSerializer.Serialize(message));

            Dictionary<string, string> message1 = new Dictionary<string, string>();
            message1["SessionId"] = CombatSessionId;
            message1["FighterId"] = Fighter1Id;
            message1["PlayerId"] = Player1Id;
            message1["Role"] = "White";

            Dictionary<string, string> message2 = new Dictionary<string, string>();
            message2["SessionId"] = CombatSessionId;
            message2["FighterId"] = Fighter2Id;
            message2["PlayerId"] = Player2Id;
            message2["Role"] = "Black";

            await Clients.AllExcept(allConnetionIdsBut(Player1Id)).SendAsync(Messages.ACCEPT_CHALLENGE, user, System.Text.Json.JsonSerializer.Serialize(message1));
            await Clients.AllExcept(allConnetionIdsBut(Player2Id)).SendAsync(Messages.ACCEPT_CHALLENGE, user, System.Text.Json.JsonSerializer.Serialize(message2));

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
            
           // Console.WriteLine("Connected");
            return base.OnConnectedAsync();
        }



    }
}
