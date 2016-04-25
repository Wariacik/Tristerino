using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using Settings = Tristerino.Config.ModesMenu.Flee;
using SettingsMana = Tristerino.Config.ManaManagerMenu;

namespace Tristerino.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            if (Settings.UseR && R.IsReady() && PlayerMana >= SettingsMana.MinRManaF)
            {
                var target =
                    EntityManager.Heroes.Enemies.Where(e => e.IsValidTarget(R.Range))
                        .OrderBy(e => e.Distance(_PlayerPos))
                        .FirstOrDefault();
                if (target != null)
                {
                    if (!target.HasBuffOfType(BuffType.SpellImmunity) && !target.HasBuffOfType(BuffType.SpellShield))
                    {
                        R.Cast(target);
                        return;
                    }
                }
            }
            if (Settings.UseW && W.IsReady() && PlayerMana >= SettingsMana.MinWManaF)
            {
                var cursorPos = Game.CursorPos;
                var castPos = _PlayerPos.Distance(cursorPos) <= W.Range
                    ? cursorPos
                    : _PlayerPos.Extend(cursorPos, W.Range).To3D();
                W.Cast(castPos);
            }
        }
    }
}