using EloBuddy;
using EloBuddy.SDK;
using Settings = Tristerino.Config.ModesMenu.Combo;
using SettingsMana = Tristerino.Config.ManaManagerMenu;
using SettingsPrediction = Tristerino.Config.PredictionMenu;

namespace Tristerino.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            // Skills
            if (Settings.UseR && R.IsReady() && PlayerMana >= SettingsMana.MinRManaC)
            {
                var target = TargetSelector.GetTarget(R.Range, DamageType.Magical);
                if (target != null)
                {
                    if (!target.HasBuffOfType(BuffType.SpellImmunity) && !target.HasBuffOfType(BuffType.SpellShield))
                    {
                        var targetHealth = target.TotalShieldHealth();
                        if (target.HasBuff("TristanaEChargeSound"))
                        {
                            targetHealth -= Damages.EDamage(target);
                        }
                        if (targetHealth < Damages.RDamage(target))
                        {
                            R.Cast(target);
                            return;
                        }
                    }
                }
                
            }
            if (Settings.UseW && W.IsReady() && PlayerMana >= SettingsMana.MinWManaC)
            {
                var target = TargetSelector.GetTarget(W.Range, DamageType.Magical);

                if (target != null)
                {
                    if (!Settings.WTurret && Extensions.CountEnemiesInRange(target, 200) <= 2)
                    {
                        if (!target.HasBuffOfType(BuffType.SpellImmunity) && !target.HasBuffOfType(BuffType.SpellShield) &&
                            !target.IsUnderTurret())
                        {
                            var pred = W.GetPrediction(target);
                            if (pred.HitChance >= SettingsPrediction.MinWHCCombo)
                            {
                                W.Cast(pred.CastPosition);
                            }
                        }
                    }
                    else
                    {
                        if (!target.HasBuffOfType(BuffType.SpellImmunity) && !target.HasBuffOfType(BuffType.SpellShield))
                        {
                            var pred = W.GetPrediction(target);
                            if (pred.HitChance >= SettingsPrediction.MinWHCCombo)
                            {
                                W.Cast(pred.CastPosition);
                            }
                        }
                    }
                }
            }
        }
    }
    
}