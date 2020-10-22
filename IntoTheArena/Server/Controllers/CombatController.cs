using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using IntoTheArena.Shared;
using IntoTheArena.Shared.CombatManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


namespace IntoTheArena.Server.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class CombatController : ControllerBase
    {
        private readonly IntoTheArena.Shared.CombatManagement.CombatManager _combatManager;
        private readonly Hubs.ChatHub _chatHubContext;

        public CombatController(IntoTheArena.Shared.CombatManagement.CombatManager combatManager, Hubs.ChatHub chatHubContext)
        {
            _combatManager = combatManager;
            _chatHubContext = chatHubContext;
            ;

        }

        [HttpPost("CombatMove")]
        public async void CombatMove([FromBody] CombatMove Move)
        {

            CombatResult result = _combatManager.Sessions[Move.SessionId].Resolve(Move);

            if (result != null)
            {
                List<string> playerIds = new List<string>();
                playerIds.Add(_combatManager.Sessions[Move.SessionId].Player1Id);
                playerIds.Add(_combatManager.Sessions[Move.SessionId].Player2Id);

                //await _chatHubContext.Clients.All.SendAsync(Messages.ENTER_LOBBY, _userEmail, JsonSerializer.Serialize(result));
                await _chatHubContext.SendCombatResult(playerIds, System.Text.Json.JsonSerializer.Serialize(result));

            }
        }

        [HttpPost("AnimationIdled")]
        public void AnimationIdled([FromBody] string fighterIdAndSessionId)
        {

            var tuple = Newtonsoft.Json.JsonConvert.DeserializeObject<Tuple<string, string>>(fighterIdAndSessionId);

            string fighterId = tuple.Item1;
            string sessionId = tuple.Item2;

            //flip the semaphore for this fighter, indicating it has reentered idle and;
            _combatManager.Sessions[sessionId].AnimationSemaphore[fighterId] = true;

            //check to see if both fighters are now idled. if so, clear out both semaphores and send out signaR notification
            if (_combatManager.Sessions[sessionId].AnimationSemaphore.Where(x => x.Value).Count() == 2)
            {
                foreach (string key in _combatManager.Sessions[sessionId].AnimationSemaphore.Keys)
                {
                    _combatManager.Sessions[sessionId].AnimationSemaphore[key] = false;
                }
            }
        }
    }
}
