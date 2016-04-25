using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace Tristerino
{
    internal class Program
    {
        public static void Main()
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Tristana")
                return;


            Config.Initialize();
            SpellM.Initialize();
            ModeM.Initialize();
            Events.Initialize();
            MiscFunctions.Initialize();
            Game.OnTick += MiscFunctions.Game_OnTick;


            Chat.Print("Tristerino 1.0 Loaded!");
        }
    }
}