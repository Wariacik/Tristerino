using EloBuddy;
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
            PredictionMenu.Initialize();
            ManaManagerMenu.Initialize();
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

                static Combo()
                {
                    MenuModes.AddGroupLabel("Combo");
                    _useQ = MenuModes.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = MenuModes.Add("comboUseW", new CheckBox("Use W"));
                    _useE = MenuModes.Add("comboUseE", new CheckBox("Use E"));
                    _useR = MenuModes.Add("comboUseR", new CheckBox("Use R"));
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
                    MenuModes.AddGroupLabel("LaneClear");
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
                private static readonly Slider _minWTargets;
                private static readonly Slider _minETargets;

                static JungleClear()
                {
                    MenuModes.AddGroupLabel("JungleClear");
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

            static MiscMenu()
            {
                MenuMisc = Menu.AddSubMenu("Misc");

                MenuMisc.AddGroupLabel("Skin Hack");
                _skinhack = MenuMisc.Add("SkinHack", new CheckBox("Use Skin Hack", false));
                _skin = MenuMisc.Add("Skin", new Slider("Choose skin", 0, 0, 10));



                MenuMisc.AddGroupLabel("Auto Level Up");
                _autolvlup = MenuMisc.Add("Autolvlup", new CheckBox("Use auto level up", false));
                _lvlup = MenuMisc.Add("Lvlup", new ComboBox("Choose level up order", 0, "E>W>Q","E>Q>W"));
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

            public static void Initialize()
            {
            }
        }

        public static class ManaManagerMenu
        {
            private static readonly Menu MenuManaManager;
            private static readonly Slider _minQMana;
            private static readonly Slider _minWMana;
            private static readonly Slider _minEMana;
            private static readonly Slider _minRMana;

            static ManaManagerMenu()
            {
                MenuManaManager = Menu.AddSubMenu("Mana Manager");
                _minQMana = MenuManaManager.Add("minQMana", new Slider("Minimum mana % to use Q", 25, 0, 100));
                _minWMana = MenuManaManager.Add("minWMana", new Slider("Minimum mana % to use W", 0, 0, 100));
                _minEMana = MenuManaManager.Add("minEMana", new Slider("Minimum mana % to use E", 35, 0, 100));
                _minRMana = MenuManaManager.Add("minRMana", new Slider("Minimum mana % to use R", 0, 0, 100));
            }

            public static int MinQMana
            {
                get { return _minQMana.CurrentValue; }
            }

            public static int MinWMana
            {
                get { return _minWMana.CurrentValue; }
            }

            public static int MinEMana
            {
                get { return _minEMana.CurrentValue; }
            }

            public static int MinRMana
            {
                get { return _minRMana.CurrentValue; }
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
                MenuPrediction.AddLabel("Here you can control the minimum HitChance to cast skills.");
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

            static DrawingMenu()
            {
                MenuDrawing = Menu.AddSubMenu("Drawing");
                _drawW = MenuDrawing.Add("drawW", new CheckBox("Draw W"));
                _drawE = MenuDrawing.Add("drawE", new CheckBox("Draw E"));
                _drawR = MenuDrawing.Add("drawR", new CheckBox("Draw R"));
                _drawOnlyReady = MenuDrawing.Add("drawOnlyReady", new CheckBox("Draw Only Ready Skills"));
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

            public static void Initialize()
            {
            }
        }
    }
}