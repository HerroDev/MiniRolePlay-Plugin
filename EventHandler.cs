using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;

namespace MiniRolePlayPlugin
{
    public class EventHandler
    {
        public void RegisterEvents()
        {
            if(Plugin.Instance.Config.DisableEscaping) Exiled.Events.Handlers.Player.Escaping += OnEscaping;
            if(Plugin.Instance.Config.DisableSpawningSCP244B) Exiled.Events.Handlers.Map.Scp244Spawning += OnScp244Spawning;
            Exiled.Events.Handlers.Player.TriggeringTesla += OnPlayerTriggeringTesla;
            Exiled.Events.Handlers.Server.RespawningTeam += OnRespawningTeam;
        }
        public void UnRegisterEvents()
        {
            if(Plugin.Instance.Config.DisableEscaping) Exiled.Events.Handlers.Player.Escaping -= OnEscaping;
            if(Plugin.Instance.Config.DisableSpawningSCP244B) Exiled.Events.Handlers.Map.Scp244Spawning -= OnScp244Spawning; 
            Exiled.Events.Handlers.Player.TriggeringTesla -= OnPlayerTriggeringTesla;
            Exiled.Events.Handlers.Server.RespawningTeam -= OnRespawningTeam;           
        }

        public void OnEscaping(EscapingEventArgs ev)
        {
            ev.IsAllowed = false;
        }  
        public void OnScp244Spawning(Scp244SpawningEventArgs ev)
        {
            ev.IsAllowed = false;
        }
        public void OnPlayerTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (!MiniRolePlayPlugin.Commands.tesla.teslaMode)
            {
                ev.IsTriggerable = false;
                ev.IsInHurtingRange = false;
                ev.IsAllowed = false;
            }
        }
        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if(MiniRolePlayPlugin.Commands.disable_spawn.Mode)
            {
                ev.IsAllowed = false;
                ev.MaximumRespawnAmount = 0;
                ev.Players.Clear();           
            }                 
        }
    }
}