using System;
using EloBuddy;

namespace Tristerino
{
    public static class MiscFunctions
    {
        public static void Game_OnTick(EventArgs args)
        {
            //Skin Hack
            Player.SetSkinId(Config.MiscMenu.SkinHack ? Config.MiscMenu._skin.CurrentValue : 0);


            //Auto Level Up
            vars.AbilitySequence = Config.MiscMenu._lvlup.CurrentValue == 0
                ? new[] {3, 2, 1, 3, 3, 4, 3, 2, 3, 2, 4, 2, 2, 1, 1, 4, 1, 1}
                : new[] {3, 2, 1, 3, 3, 4, 3, 1, 3, 1, 4, 1, 1, 2, 2, 4, 2, 2};

            if (Config.MiscMenu.Autolvlup)
            {
                var qL = vars._Player.Spellbook.GetSpell(SpellSlot.Q).Level + vars.QOff;
                var wL = vars._Player.Spellbook.GetSpell(SpellSlot.W).Level + vars.WOff;
                var eL = vars._Player.Spellbook.GetSpell(SpellSlot.E).Level + vars.EOff;
                var rL = vars._Player.Spellbook.GetSpell(SpellSlot.R).Level + vars.ROff;
                if (qL + wL + eL + rL >= vars._Player.Level) return;
                int[] level = {0, 0, 0, 0};
                for (var i = 0; i < vars._Player.Level; i++)
                {
                    level[vars.AbilitySequence[i] - 1] = level[vars.AbilitySequence[i] - 1] + 1;
                }
                if (qL < level[0]) vars._Player.Spellbook.LevelSpell(SpellSlot.Q);
                if (wL < level[1]) vars._Player.Spellbook.LevelSpell(SpellSlot.W);
                if (eL < level[2]) vars._Player.Spellbook.LevelSpell(SpellSlot.E);
                if (rL < level[3]) vars._Player.Spellbook.LevelSpell(SpellSlot.R);
            }

            //Auto Heal

        }

        public static void Initialize()
        {
        }
    }
}