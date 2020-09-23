using System;
using System.Collections.Generic;
using System.Text;

namespace IntoTheArena.Shared.CombatManagement
{
    public class CombatMove
    {

        public string SessionId { get; set; }

        public string FighterId { get; set; }

        public string PlayerId { get; set; }

        public CombatAction Action { get; set; }

    }
}
