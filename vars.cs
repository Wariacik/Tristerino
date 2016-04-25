using EloBuddy;

namespace Tristerino
{
    internal class vars
    {
        public static int[] AbilitySequence;


        public static int QOff = 0, WOff = 0, EOff = 0, ROff = 0;

        public static AIHeroClient _Player
        {
            get { return ObjectManager.Player; }
        }
    }
}