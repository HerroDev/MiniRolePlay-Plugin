using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;

namespace MiniRolePlayPlugin
{
    public class EventHandler
    {
        public void RegisterEvents()
        {
            if(Plugin.Instance.Config.DisableEscaping) Exiled.Events.Handlers.Player.Escaping += OnEscaping;
            if(Plugin.Instance.Config.DisableSpawningSCP244B) Exiled.Events.Handlers.Map.Scp244Spawning += OnScp244Spawning;
        }
        public void UnRegisterEvents()
        {
            if(Plugin.Instance.Config.DisableEscaping) Exiled.Events.Handlers.Player.Escaping -= OnEscaping;
            if(Plugin.Instance.Config.DisableSpawningSCP244B) Exiled.Events.Handlers.Map.Scp244Spawning -= OnScp244Spawning;            
        }

        public void OnEscaping(EscapingEventArgs ev)
        {
            ev.IsAllowed = false;
        }  
        public void OnScp244Spawning(Scp244SpawningEventArgs ev)
        {
            ev.IsAllowed = false;
        }
    }
}