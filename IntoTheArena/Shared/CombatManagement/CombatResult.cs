﻿using System;
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
        AC_CLEAVED = 8
    }
}
