using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BeatSaberMarkupLanguage.Settings;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace ProcessPriority
{

    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public void Init(IPALogger logger, Config conf)
        {
            Instance = this;
            Log = logger;
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Info("ProcessPriority initialized.");
        }

        [OnStart]
        public void OnApplicationStart()
        {
            BSMLSettings.instance.AddSettingsMenu("ProcessPriority", "ProcessPriority.UI.SettingsUI.bsml", UI.SettingsUI.instance);
            SetProcessPriority();
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Configuration.PluginConfig.Instance.Changed();
        }

        internal void SetProcessPriority()
        {
            Process gp = Process.GetCurrentProcess();
            Log.Info("Aquired process is " + gp.ProcessName + " with ID " + gp.Id.ToString());

            try
            {
                gp.PriorityClass = Configuration.PluginConfig.Instance.ProcessPriority;
                Log.Info("Set process priority to " + Configuration.PluginConfig.Instance.ProcessPriority.ToString());
            }
            catch (Exception ex)
            {
                Log.Info("Unable to set priority. The config probably hasn't loaded yet.");
            }
        }
    }
}
