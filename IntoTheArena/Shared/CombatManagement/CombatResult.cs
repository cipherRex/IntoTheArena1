using System;
using System.Collections.Generic;
using System.Text;

namespace IntoTheArena.Shared.CombatManagement
{


    public class CombatResult
    {

        public string Victor { get; set; }
        public AnimationCommand WhiteAnimationId { get; set; }
        public AnimationCommand BlackAnimationId { get; set; }
        public string Comments { get; set; }
        public int WhitePlayerAdjustment { get; set; }
        public int BlackPlayerAdjustment { get; set; }
        List<CombatAction> Restrictions { get; set; }
        public int WhitePlayerTotalHP { get; set; }
        public int BlackPlayerTotalHP { get; set; }

        public Victory VictoryData { get; set; }
}

    public class Victory 
    {
        public string FighterId { get; set; }
        public string Condition { get; set; }

    }

    public enum AnimationCommand
    { 
        AC_SWING = 0,
        AC_PARRY = 1,
        AC_COUNTERPARRY = 2,
        AC_KICK = 3,
        AC_CLEAVE = 4,
        AC_BLOCK = 5,
        AC_HEAL = 6,
        AC_GROINED = 7,
        AC_CLEAVED = 8,
        AC_DIE = 9,
        AC_CELEBRATE = 10,
        AC_LAUGH = 11,
        AC_RUN = 12
    }
}
