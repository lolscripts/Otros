﻿using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;

namespace The_Ball_Is_Angry
{
    public static class LastHit
    {
        public static Menu Menu
        {
            get { return MenuManager.GetSubMenu("LastHit"); }
        }

        public static bool IsActive
        {
            get { return ModeManager.IsLastHit; }
        }
        

        public static void Execute()
        {
        }
    }
}