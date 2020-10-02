using System;
using System.Collections.Generic;
using System.Text;

namespace IntoTheArena.Shared.CombatManagement
{


    public class CombatResult
    {

        public string Victor { get; set; }
        public int AnimationId { get; set; }
        public string Comments { get; set; }
        public int WhitePlayerAdjustment { get; set; }
        public int BlackPlayerAdjustment { get; set; }
        List<CombatAction> Restrictions { get; set; }


    }
}
