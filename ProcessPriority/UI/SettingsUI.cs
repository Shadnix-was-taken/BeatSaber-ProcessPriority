using BeatSaberMarkupLanguage.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessPriority.UI
{
    public class SettingsUI : PersistentSingleton<SettingsUI>
    {
        [UIValue("priorityChoices")]
        private List<object> PriorityChoices = new List<object>
        {
            "High",
            "AboveNormal",
            "Normal",
            "BelowNormal",
            "Idle"
        };

        [UIValue("priorityChoice")]
        public string _priorityChoice
        {
            get => Configuration.PluginConfig.Instance.ProcessPriority.ToString();
            set
            {
                switch (value)
                {
                    case "High":
                        Configuration.PluginConfig.Instance.ProcessPriority = System.Diagnostics.ProcessPriorityClass.High;
                        break;
                    case "AboveNormal":
                        Configuration.PluginConfig.Instance.ProcessPriority = System.Diagnostics.ProcessPriorityClass.AboveNormal;
                        break;
                    case "Normal":
                        Configuration.PluginConfig.Instance.ProcessPriority = System.Diagnostics.ProcessPriorityClass.Normal;
                        break;
                    case "BelowNormal":
                        Configuration.PluginConfig.Instance.ProcessPriority = System.Diagnostics.ProcessPriorityClass.BelowNormal;
                        break;
                    case "Idle":
                        Configuration.PluginConfig.Instance.ProcessPriority = System.Diagnostics.ProcessPriorityClass.Idle;
                        break;
                    default:
                        Configuration.PluginConfig.Instance.ProcessPriority = System.Diagnostics.ProcessPriorityClass.Normal;
                        break;
                }
            }
        }

        /*[UIAction("#ok")]
        public void OnOk() => ApplySettings();

        [UIAction("#apply")]
        public void OnApply() => ApplySettings();


        internal void ApplySettings()
        {
            Plugin.Instance.SetProcessPriority();
        }
        */
    }
}
