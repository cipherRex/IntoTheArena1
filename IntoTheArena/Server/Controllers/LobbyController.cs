using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using IntoTheArena.Server.Models;
using IntoTheArena.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace IntoTheArena.Server.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class LobbyController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Arena _arena;
        Hubs.ChatHub _chatHubContext;

        //Hubs.ChatHub _chatHubContext;



        //public LobbyController(UserManager<ApplicationUser> userManager, Arena arena, Hubs.ChatHub chatHubContext)
        public LobbyController(UserManager<ApplicationUser> userManager, Arena arena, Hubs.ChatHub chatHubContext)
        {
            
            _chatHubContext = chatHubContext;
            _arena = arena;
            _userManager = userManager;
            // _chatHub = chatHub;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Fighter>> Get()
        {

           // var _userEmail = userEmail().Result;
            return _arena.Fighters().ToArray();
        }


        [HttpGet("PlayerFighters")]
        public async Task<IEnumerable<Fighter>> PlayerFighters()
        {

            List<Fighter> fighters = new List<Fighter>();
            fighters.Add(new Fighter() {id = "3a5c704b-07a9-4fcb-81f5-756c9bf6e054", Name = "Grule", Picture="fig1.png" });
            fighters.Add(new Fighter() { id = "8dd578f7-9c67-4228-ab5e-7e1d5d47d918", Name = "Malok", Picture = "fig2.png" });
            fighters.Add(new Fighter() { id = "a34d680a-2892-4da2-803d-22022b5eac42", Name = "Sam", Picture = "fig3.png" });

            return fighters;

        }

        [HttpGet("Combatants")]
        public async Task<IEnumerable<Fighter>> Combatants()
        {
            return _arena.Fighters().ToArray();
        }

        [HttpPost("EnterLobby")]
        public async Task EnterLobby([FromBody] string FigherJson)
        {
            var _userEmail = userEmail().Result;
            Fighter newFighter = System.Text.Json.JsonSerializer.Deserialize<Fighter>(FigherJson);

            _arena.AddFighter(newFighter);
            await _chatHubContext.Clients.All.SendAsync(Messages.ENTER_LOBBY, _userEmail, JsonSerializer.Serialize(newFighter));

        }

        [HttpPost("ExitLobby")]
        public async Task ExitLobby([FromBody] string FigherJson)
        {
            var _userEmail = userEmail().Result;
            Fighter fighterToRemove = System.Text.Json.JsonSerializer.Deserialize<Fighter>(FigherJson);

            Fighter fx = _arena.Fighters().First(x => x.id == fighterToRemove.id);

            _arena.RemoveFighter(fx);
            await _chatHubContext.Clients.All.SendAsync(Messages.LEAVE_LOBBY, _userEmail, JsonSerializer.Serialize(fighterToRemove));

        }

        //[HttpPost("ExitLobby")]
        //public async Task<IEnumerable<ContestantInfo>> ExitLobby()
        //{


        //    Hubs.ChatHub chatHub = new Hubs.ChatHub();
        //    // _chatHub.SendMessage("someUser", "wahhhh");

        //    //Console.Write(_chatHubContext.Clients);

        //    var _userEmail = userEmail().Result;


        //    //var clientCount = _chatHubContext.Clients.clientCount - 1;

        //    //_chatHubContext.Clients.All.SendAsync("ReceiveMessage", "mr foo", "foo me");
        //    await _chatHubContext.Clients.All.SendAsync("ReceiveMessage", "mr foo", "foo me");
        //    // _chatHubContext.

        //    _lobby.LeaveLobby(_userEmail);
        //    return _lobby.Contestants().Select(e => e)
        //    .ToArray();

        //}


        [AllowAnonymous]
        private async Task<string> userEmail()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            //var user = await _userManager.FindByIdAsync(userId);
            //var userEmail = user.Email;
            //return userEmail;
            return "cipherRex@gmail.com";
        }

    }   


}
