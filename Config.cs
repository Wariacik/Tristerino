using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Tristerino
{
    public static class Config
    {
        private const string MenuName = "Tristerino";

        private static readonly Menu Menu;

        static Config()
        {
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Tristerino 1.0 by WodzuPL");
            ModesMenu.Initialize();
            ManaManagerMenu.Initialize();
            PredictionMenu.Initialize();
            DrawingMenu.Initialize();
            MiscMenu.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class ModesMenu
        {
            private static readonly Menu MenuModes;

            static ModesMenu()
            {
                MenuModes = Menu.AddSubMenu("Modes");

                Combo.Initialize();
                MenuModes.AddSeparator();

                Harass.Initialize();
                MenuModes.AddSeparator();

                LaneClear.Initialize();
                MenuModes.AddSeparator();

                JungleClear.Initialize();
                MenuModes.AddSeparator();

                Flee.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;
                private static readonly CheckBox _Wturret;

                static Combo()
                {
                    MenuModes.AddGroupLabel("Combo");
                    _useQ = MenuModes.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = MenuModes.Add("comboUseW", new CheckBox("Use W"));
                    _useE = MenuModes.Add("comboUseE", new CheckBox("Use E"));
                    _useR = MenuModes.Add("comboUseR", new CheckBox("Use R"));
                    _Wturret = MenuModes.Add("WTurret", new CheckBox("Use W under enemy turret", false));
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static bool WTurret
                {
                    get { return _Wturret.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useE;

                static Harass()
                {
                    MenuModes.AddGroupLabel("Harass");
                    _useQ = MenuModes.Add("harassUseQ", new CheckBox("Use Q"));
                    _useE = MenuModes.Add("harassUseE", new CheckBox("Use E"));
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _minWTargets;
                private static readonly Slider _minETargets;

                static LaneClear()
                {
                    MenuModes.AddGroupLabel("Lane Clear");
                    _useQ = MenuModes.Add("laneUseQ", new CheckBox("Use Q"));
                    _useW = MenuModes.Add("laneUseW", new CheckBox("Use W"));
                    _useE = MenuModes.Add("laneUseE", new CheckBox("Use E"));
                    _minWTargets = MenuModes.Add("minWTargetsLC", new Slider("Minimum targets for W", 6, 1, 10));
                    _minETargets = MenuModes.Add("minETargetsLC", new Slider("Minimum targets for E", 3, 1, 10));
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static int MinWTargets
                {
                    get { return _minWTargets.CurrentValue; }
                }

                public static int MinETargets
                {
                    get { return _minETargets.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;

                static JungleClear()
                {
                    MenuModes.AddGroupLabel("Jungle Clear");
                    _useQ = MenuModes.Add("jungleUseQ", new CheckBox("Use Q"));
                    _useW = MenuModes.Add("jungleUseW", new CheckBox("Use W"));
                    _useE = MenuModes.Add("jungleUseE", new CheckBox("Use E"));
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useR;

                static Flee()
                {
                    MenuModes.AddGroupLabel("Flee");
                    _useW = MenuModes.Add("fleeUseW", new CheckBox("Use W"));
                    _useR = MenuModes.Add("fleeUseR", new CheckBox("Use R", false));
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }
        }

        public static class MiscMenu
        {
            private static readonly Menu MenuMisc;
            public static readonly CheckBox _skinhack;
            public static readonly Slider _skin;
            private static readonly CheckBox _autolvlup;
            public static readonly ComboBox _lvlup;
            /*public static readonly CheckBox _heal;
            public static readonly Slider _hp;*/

            static MiscMenu()
            {
                MenuMisc = Menu.AddSubMenu("Misc");

                MenuMisc.AddGroupLabel("Skin Hack");
                _skinhack = MenuMisc.Add("SkinHack", new CheckBox("Use Skin Hack", false));
                _skin = MenuMisc.Add("Skin", new Slider("Choose skin", 0, 0, 10));


                MenuMisc.AddGroupLabel("Auto Level Up");
                _autolvlup = MenuMisc.Add("Autolvlup", new CheckBox("Use auto level up", false));
                _lvlup = MenuMisc.Add("Lvlup", new ComboBox("Choose level up order", 0, "E>W>Q", "E>Q>W"));

                /*MenuMisc.AddGroupLabel("Auto Heal [WIP]");
                _heal = MenuMisc.Add("Heal", new CheckBox("Use auto heal", false));
                _hp = MenuMisc.Add("HP", new Slider("Minimum health % to use heal", 15, 0, 100));*/
            }

            public static bool SkinHack
            {
                get { return _skinhack.CurrentValue; }
            }

            public static int Skin
            {
                get { return _skin.CurrentValue; }
            }

            public static bool Autolvlup
            {
                get { return _autolvlup.CurrentValue; }
            }

            /*public static bool Heal
            {
                get { return _heal.CurrentValue; }
            }
            public static int HP
            {
                get { return _hp.CurrentValue; }
            }*/

            public static void Initialize()
            {
            }
        }

        public static class ManaManagerMenu
        {
            private static readonly Menu MenuManaManager;
            private static readonly Slider _minWManaC;
            private static readonly Slider _minEManaC;
            private static readonly Slider _minRManaC;

            private static readonly Slider _minEManaH;

            private static readonly Slider _minWManaLC;
            private static readonly Slider _minEManaLC;

            private static readonly Slider _minWManaJC;
            private static readonly Slider _minEManaJC;

            private static readonly Slider _minWManaF;
            private static readonly Slider _minRManaF;


            static ManaManagerMenu()
            {
                MenuManaManager = Menu.AddSubMenu("Mana Manager");
                MenuManaManager.AddGroupLabel("Combo");

                _minWManaC = MenuManaManager.Add("minWManaC", new Slider("Minimum mana % to use W", 35, 0, 100));
                _minEManaC = MenuManaManager.Add("minEManaC", new Slider("Minimum mana % to use E", 35, 0, 100));
                _minRManaC = MenuManaManager.Add("minRManaC", new Slider("Minimum mana % to use R", 35, 0, 100));

                MenuManaManager.AddGroupLabel("Harass");
                _minEManaH = MenuManaManager.Add("minEManaH", new Slider("Minimum mana % to use E", 50, 0, 100));

                MenuManaManager.AddGroupLabel("Lane Clear");
                _minWManaLC = MenuManaManager.Add("minWManaLC", new Slider("Minimum mana % to use W", 50, 0, 100));
                _minEManaLC = MenuManaManager.Add("minEManaLC", new Slider("Minimum mana % to use E", 50, 0, 100));

                MenuManaManager.AddGroupLabel("JungleClear");
                _minWManaJC = MenuManaManager.Add("minWManaJC", new Slider("Minimum mana % to use W", 50, 0, 100));
                _minEManaJC = MenuManaManager.Add("minEManaJC", new Slider("Minimum mana % to use E", 50, 0, 100));

                MenuManaManager.AddGroupLabel("Flee");
                _minWManaF = MenuManaManager.Add("minWManaF", new Slider("Minimum mana % to use W", 0, 0, 100));
                _minRManaF = MenuManaManager.Add("minRManaF", new Slider("Minimum mana % to use R", 0, 0, 100));
            }

            //Combo

            public static int MinWManaC
            {
                get { return _minWManaC.CurrentValue; }
            }

            public static int MinEManaC
            {
                get { return _minEManaC.CurrentValue; }
            }

            public static int MinRManaC
            {
                get { return _minRManaC.CurrentValue; }
            }

            //Harass

            public static int MinEManaH
            {
                get { return _minEManaH.CurrentValue; }
            }

            //LC

            public static int MinWManaLC
            {
                get { return _minWManaLC.CurrentValue; }
            }

            public static int MinEManaLC
            {
                get { return _minEManaLC.CurrentValue; }
            }

            //JC

            public static int MinWManaJC
            {
                get { return _minWManaJC.CurrentValue; }
            }

            public static int MinEManaJC
            {
                get { return _minEManaJC.CurrentValue; }
            }

            //Flee
            public static int MinWManaF
            {
                get { return _minWManaF.CurrentValue; }
            }

            public static int MinRManaF
            {
                get { return _minRManaF.CurrentValue; }
            }

            public static void Initialize()
            {
            }
        }

        public static class PredictionMenu
        {
            private static readonly Menu MenuPrediction;
            private static readonly Slider _minWHCCombo;
            private static readonly Slider _minWHCKillSteal;

            static PredictionMenu()
            {
                MenuPrediction = Menu.AddSubMenu("Prediction");
                MenuPrediction.AddGroupLabel("W Prediction");
                MenuPrediction.AddGroupLabel("Combo");
                _minWHCCombo = Misc.CreateHitChanceSlider("comboMinWHitChance", "Combo", HitChance.High, MenuPrediction);
                MenuPrediction.AddGroupLabel("Kill Steal");
                _minWHCKillSteal = Misc.CreateHitChanceSlider("killStealMinWHitChance", "Kill Steal", HitChance.Medium,
                    MenuPrediction);
            }

            public static HitChance MinWHCCombo
            {
                get { return Misc.GetHitChanceSliderValue(_minWHCCombo); }
            }

            public static HitChance MinWHCKillSteal
            {
                get { return Misc.GetHitChanceSliderValue(_minWHCKillSteal); }
            }

            public static void Initialize()
            {
            }
        }

        public static class DrawingMenu
        {
            private static readonly Menu MenuDrawing;
            private static readonly CheckBox _drawW;
            private static readonly CheckBox _drawE;
            private static readonly CheckBox _drawR;
            private static readonly CheckBox _drawOnlyReady;
            private static readonly CheckBox _drawStacks;

            static DrawingMenu()
            {
                MenuDrawing = Menu.AddSubMenu("Drawing");
                _drawW = MenuDrawing.Add("drawW", new CheckBox("Draw W"));
                _drawE = MenuDrawing.Add("drawE", new CheckBox("Draw E"));
                _drawR = MenuDrawing.Add("drawR", new CheckBox("Draw R"));
                _drawOnlyReady = MenuDrawing.Add("drawOnlyReady", new CheckBox("Draw only ready skills"));
                _drawStacks = MenuDrawing.Add("DrawStacks", new CheckBox("Draw E Stacks"));
            }

            public static bool DrawW
            {
                get { return _drawW.CurrentValue; }
            }

            public static bool DrawE
            {
                get { return _drawE.CurrentValue; }
            }

            public static bool DrawR
            {
                get { return _drawR.CurrentValue; }
            }

            public static bool DrawOnlyReady
            {
                get { return _drawOnlyReady.CurrentValue; }
            }

            public static bool DrawStacks
            {
                get { return _drawStacks.CurrentValue; }
            }

            public static void Initialize()
            {
            }
        }
    }
}