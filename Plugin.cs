using System;
using Exiled.API.Features;

namespace MiniRolePlayPlugin
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "MiniRolePlayPlugin";
        public override string Author => "HerroDev";
        public override Version Version => new Version(0,0,1);

        public static Plugin Instance;
        public static EventHandler eventHandler;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Instance = this;
            eventHandler = new EventHandler();
            eventHandler.RegisterEvents();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            eventHandler.UnRegisterEvents();

            eventHandler = null;
            Instance = null;
        }
    }
}