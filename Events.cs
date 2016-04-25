using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Rendering;
using SharpDX;
using SettingsMana = Tristerino.Config.ManaManagerMenu;
using SettingsModes = Tristerino.Config.ModesMenu;
using SettingsDrawing = Tristerino.Config.DrawingMenu;

namespace Tristerino
{
    public static class Events
    {
        static Events()
        {
            Orbwalker.OnPreAttack += OrbwalkerOnPreAttack;
            Orbwalker.OnAttack += OrbwalkerOnAttack;
            Drawing.OnDraw += OnDraw;
        }

        private static float PlayerMana
        {
            get { return Player.Instance.ManaPercent; }
        }

        private static void OrbwalkerOnAttack(AttackableUnit target, EventArgs args)
        {
            if (!SpellM.Q.IsReady())
            {
                return;
            }
            if ((SettingsModes.Combo.UseQ && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) ||
                (SettingsModes.Harass.UseQ && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass)) ||
                (SettingsModes.LaneClear.UseQ && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear)) ||
                (SettingsModes.JungleClear.UseQ && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear)))
            {
                if (target is AIHeroClient)
                {
                    SpellM.Q.Cast();
                    return;
                }
            }


            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear) ||
                Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                if (target is Obj_AI_Minion)
                {
                    if (SettingsModes.JungleClear.UseQ && target.Team == GameObjectTeam.Neutral)
                    {
                        SpellM.Q.Cast();
                    }
                    else if (SettingsModes.LaneClear.UseQ && target.IsEnemy)
                    {
                        SpellM.Q.Cast();
                    }
                }
            }
        }

        private static void OrbwalkerOnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (!SpellM.E.IsReady())
            {
                return;
            }
            if ((SettingsModes.Combo.UseE && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) &&
                 PlayerMana >= SettingsMana.MinEManaC) ||
                (SettingsModes.Harass.UseE && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass) &&
                 PlayerMana >= SettingsMana.MinEManaH) ||
                (SettingsModes.LaneClear.UseE && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) &&
                 PlayerMana >= SettingsMana.MinEManaLC) ||
                (SettingsModes.JungleClear.UseE && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear) &&
                 PlayerMana >= SettingsMana.MinEManaJC))
            {
                if (target is AIHeroClient)
                {
                    SpellM.E.Cast((Obj_AI_Base) target);
                    return;
                }
            }


            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) ||
                Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                if (target is Obj_AI_Minion)
                {
                    if (SettingsModes.LaneClear.UseE && target.IsEnemy && PlayerMana >= SettingsMana.MinEManaLC)
                    {
                        var ETargets =
                            EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                                target.Position, 250.0f).Count();
                        if (ETargets >= SettingsModes.LaneClear.MinETargets)
                        {
                            SpellM.E.Cast((Obj_AI_Base) target);
                        }
                    }
                    if (SettingsModes.JungleClear.UseE && target.Team == GameObjectTeam.Neutral &&
                        PlayerMana >= SettingsMana.MinEManaJC)
                    {
                        SpellM.E.Cast((Obj_AI_Base) target);
                    }
                }
            }
        }

        public static void Initialize()
        {
        }


        private static void OnDraw(EventArgs args)
        {
            var ERRange = SpellM.ERRange();
            if (SettingsDrawing.DrawW)
            {
                if (!(SettingsDrawing.DrawOnlyReady && !SpellM.W.IsReady()))
                {
                    Circle.Draw(Color.Black, SpellM.W.Range, Player.Instance.Position);
                }
            }
            if (SettingsDrawing.DrawE)
            {
                if (!(SettingsDrawing.DrawOnlyReady && !SpellM.E.IsReady()))
                {
                    Circle.Draw(Color.White, ERRange, Player.Instance.Position);
                }
            }
            if (SettingsDrawing.DrawR)
            {
                if (!(SettingsDrawing.DrawOnlyReady && !SpellM.R.IsReady()))
                {
                    Circle.Draw(Color.Red, ERRange, Player.Instance.Position);
                }
            }
        }
    }
}