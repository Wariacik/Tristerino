using EloBuddy.SDK;
using Settings = Tristerino.Config.ModesMenu.JungleClear;
using SettingsMana = Tristerino.Config.ManaManagerMenu;

namespace Tristerino.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            if (Settings.UseW & W.IsReady() && PlayerMana >= SettingsMana.MinWMana)
            {
                var monsters = EntityManager.MinionsAndMonsters.GetJungleMonsters(_PlayerPos, W.Range + W.Width);
                var farmLoc = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(monsters, W.Width, (int) W.Range);
            }
        }
    }
}