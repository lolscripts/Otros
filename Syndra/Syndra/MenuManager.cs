using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Syndra
{
    public static class MenuManager
    {
        public static Menu AddonMenu;
        public static Dictionary<string, Menu> SubMenu = new Dictionary<string, Menu>();
        public static void Init(EventArgs args)
        {
            var addonName = Champion.AddonName;
            var author = Champion.Author;
            AddonMenu = MainMenu.AddMenu(addonName, addonName + " por " + author + " v1.2 ");
            AddonMenu.AddLabel(addonName + " echo por " + author);

            SubMenu["Prediccion"] = AddonMenu.AddSubMenu("Prediccion", "Prediccion 2.1");
            SubMenu["Prediccion"].AddGroupLabel("Q Configuracion");
            SubMenu["Prediccion"].Add("QCombo", new Slider("Combo HitChancePorcentaje", 65, 0, 100));
            SubMenu["Prediccion"].Add("Tirar", new Slider("Harass HitChancePorcentaje", 70, 0, 100));
            SubMenu["Prediccion"].AddGroupLabel("W Configuracion");
            SubMenu["Prediccion"].Add("WCombo", new Slider("Combo HitChancePorcentaje", 65, 0, 100));
            SubMenu["Prediccion"].Add("WTirar", new Slider("Harass HitChancePorcentaje", 65, 0, 100));
            SubMenu["Prediccion"].AddGroupLabel("QE Configuracion");
            SubMenu["Prediccion"].Add("ECombo", new Slider("Combo HitChancePorcentaje", 65, 0, 100));
            SubMenu["Prediccion"].Add("ETirar", new Slider("Tirar HitChancePorcentaje", 70, 0, 100));


            SubMenu["Combo"] = AddonMenu.AddSubMenu("Combo", "Combo 2");
            SubMenu["Combo"].Add("Q", new CheckBox("Usar Q", true));
            SubMenu["Combo"].Add("W", new CheckBox("Usar W", true));
            SubMenu["Combo"].Add("E", new CheckBox("Usar E", true));
            SubMenu["Combo"].Add("QE", new CheckBox("Usar QE", true));
            SubMenu["Combo"].Add("WE", new CheckBox("Usar WE", true));
            SubMenu["Combo"].AddStringList("R", "Usar R", new[] { "Nunca", "Si killable", "Si es necesario", "Siempre" }, 1);
            SubMenu["Combo"].Add("Zhonyas", new Slider("Usar Zhonya Porcentaje de Vida <=", 10, 0, 100));
            SubMenu["Combo"].Add("Cooldown", new Slider("Tiempo de reutilización de los hechizos R", 4, 0, 10));

            SubMenu["Tirar"] = AddonMenu.AddSubMenu("Tirar", "Tirar");
            SubMenu["Tirar"].Add("Toggle", new KeyBind("Tirar", false, KeyBind.BindTypes.PressToggle, 'K'));
            SubMenu["Tirar"].Add("Q", new CheckBox("Usar Q", true));
            SubMenu["Tirar"].Add("W", new CheckBox("Usar W", false));
            SubMenu["Tirar"].Add("E", new CheckBox("Usar E", false));
            SubMenu["Tirar"].Add("QE", new CheckBox("Usar QE", false));
            SubMenu["Tirar"].Add("WE", new CheckBox("Usar WE", false));
            SubMenu["Tirar"].Add("Turret", new CheckBox("No atacar bajo torreta enemiga", true));
            SubMenu["Tirar"].Add("Mana", new Slider("Min. Mana Porcentaje:", 20, 0, 100));

            SubMenu["LimpiarLinea"] = AddonMenu.AddSubMenu("LimpiarLinea", "LimpiarLinea");
            SubMenu["LimpiarLinea"].Add("Q", new Slider("Usar Q si Hit >=", 3, 0, 10));
            SubMenu["LimpiarLinea"].Add("W", new Slider("Usar W if Hit >=", 3, 0, 10));
            SubMenu["LimpiarLinea"].AddGroupLabel("Unkillable minions");
            SubMenu["LimpiarLinea"].Add("Q2", new CheckBox("Usar Q", true));
            SubMenu["LimpiarLinea"].Add("Mana", new Slider("Min. Mana Porcentaje:", 50, 0, 100));
            
            SubMenu["LimpiarJungla"] = AddonMenu.AddSubMenu("LimpiarJungla", "LimpiarJungla");
            SubMenu["LimpiarJungla"].Add("Q", new CheckBox("Usar Q", true));
            SubMenu["LimpiarJungla"].Add("W", new CheckBox("Usar W", true));
            SubMenu["LimpiarJungla"].Add("E", new CheckBox("Usar E", true));
            SubMenu["LimpiarJungla"].Add("Mana", new Slider("Min. Mana Porcentaje:", 20, 0, 100));

            SubMenu["UltimoGolpe"] = AddonMenu.AddSubMenu("UltimoGolpe", "UltimoGolpe");
            SubMenu["UltimoGolpe"].AddGroupLabel("Unkillable minions");
            SubMenu["UltimoGolpe"].Add("Q", new CheckBox("Usar Q", true));
            SubMenu["UltimoGolpe"].Add("Mana", new Slider("Min. Mana Porcentaje:", 50, 0, 100));
            
            SubMenu["KillSteal"] = AddonMenu.AddSubMenu("KillSteal", "KillSteal");
            SubMenu["KillSteal"].Add("Q", new CheckBox("Usar Q", true));
            SubMenu["KillSteal"].Add("W", new CheckBox("Usar W", true));
            SubMenu["KillSteal"].Add("E", new CheckBox("Usar E", true));
            SubMenu["KillSteal"].Add("R", new CheckBox("Usar R", false));
            SubMenu["KillSteal"].Add("Ignite", new CheckBox("Usar Ignite", true));

            SubMenu["Escapar"] = AddonMenu.AddSubMenu("Escapar", "Escapar");
            SubMenu["Escapar"].Add("Movimiento", new CheckBox("Desactivar Movimiento", true));
            SubMenu["Escapar"].Add("E", new CheckBox("Usar QE/WE el enemigo cerca de ratón", true));

            SubMenu["Circulos"] = AddonMenu.AddSubMenu("Circulos", "Circulos");
            SubMenu["Circulos"].Add("Disable", new CheckBox("Desactivar los circulos", false));
            SubMenu["Circulos"].AddSeparator();
            SubMenu["Circulos"].Add("Q", new CheckBox("Draw Q Rango", true));
            SubMenu["Circulos"].Add("W", new CheckBox("Draw W Rango", false));
            SubMenu["Circulos"].Add("QE", new CheckBox("Draw QE Rango", true));
            SubMenu["Circulos"].Add("R", new CheckBox("Draw R Rango", false));
            SubMenu["Circulos"].Add("DamageIndicator", new CheckBox("Draw indicador de daño", true));
            SubMenu["Circulos"].Add("Target", new CheckBox("Draw Circulo en tarjet", true));
            SubMenu["Circulos"].Add("Killable", new CheckBox("Draw texto si enemigo es killable", true));
            SubMenu["Circulos"].Add("W.Object", new CheckBox("Draw círculo en w objeto", true));
            SubMenu["Circulos"].Add("Harass.Toggle", new CheckBox("Draw texto para el estado de conmutación tirar", true));
            SubMenu["Circulos"].AddStringList("E.Lines", "Draw lineas de E", new[] { "Nunca", "Si llegará enemigo", "Siempre" }, 1);

            SubMenu["Otros"] = AddonMenu.AddSubMenu("Otros", "Otros");
            SubMenu["Otros"].Add("GapCloser", new CheckBox("Usar QE/WE para interrumpir", true));
            SubMenu["Otros"].Add("Interrupter", new CheckBox("Usar QE/WE a Interrumpirhechizos", true));
            SubMenu["Otros"].Add("QE.Range", new Slider("Menos QE Rango", 0, 0, 650));
            SubMenu["Otros"].Add("Overkill", new Slider("Overkill % de prediccion de daño", 10, 0, 100));
            if (EntityManager.Heroes.Enemies.Count > 0)
            {
                SubMenu["Otros"].AddGroupLabel("No usar R en");
                foreach (var enemy in EntityManager.Heroes.Enemies)
                {
                    SubMenu["Otros"].Add("Dont.R." + enemy.ChampionName, new CheckBox(enemy.ChampionName, false));
                }
            }

        }

        public static int GetSliderValue(this Menu m, string s)
        {
            if (m != null)
                return m[s].Cast<Slider>().CurrentValue;
            return -1;
        }
        public static bool GetCheckBoxValue(this Menu m, string s)
        {
            return m != null && m[s].Cast<CheckBox>().CurrentValue;
        }

        public static bool GetKeyBindValue(this Menu m, string s)
        {
            return m != null && m[s].Cast<KeyBind>().CurrentValue;
        }

        public static void AddStringList(this Menu m, string uniqueId, string displayName, string[] values, int defaultValue)
        {
            var mode = m.Add(uniqueId, new Slider(displayName, defaultValue, 0, values.Length - 1));
            mode.DisplayName = displayName + ": " + values[mode.CurrentValue];
            mode.OnValueChange += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
            {
                sender.DisplayName = displayName + ": " + values[args.NewValue];
            };
        }
        public static Menu GetSubMenu(string s)
        {
            return (from t in SubMenu where t.Key.Equals(s) select t.Value).FirstOrDefault();
        }

        public static Menu MiscMenu
        {
            get { return GetSubMenu("Otros"); }
        }

        public static Menu PredictionMenu
        {
            get { return GetSubMenu("Prediccion"); }
        }

        public static Menu DrawingsMenu
        {
            get { return GetSubMenu("Circulos"); }
        }
    }
}
