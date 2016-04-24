using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace Tristerino.Modes
{
    public abstract class ModeBase
    {
        protected Spell.Active Q
        {
            get { return SpellM.Q; }
        }

        protected Spell.Skillshot W
        {
            get { return SpellM.W; }
        }

        protected Spell.Targeted E
        {
            get { return SpellM.E; }
        }

        protected Spell.Targeted R
        {
            get { return SpellM.R; }
        }

        protected float PlayerHealth
        {
            get { return Player.Instance.HealthPercent; }
        }

        protected float PlayerMana
        {
            get { return Player.Instance.ManaPercent; }
        }

        protected float PlayerManaExact
        {
            get { return Player.Instance.Mana; }
        }

        protected AIHeroClient _Player
        {
            get { return Player.Instance; }
        }

        protected Vector3 _PlayerPos
        {
            get { return Player.Instance.Position; }
        }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}