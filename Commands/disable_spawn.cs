using System;
using CommandSystem;
using MiniRolePlayPlugin;

namespace MiniRolePlayPlugin.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class disable_spawn : ICommand
    {
        public string Command => "disablespawn";

        public string[] Aliases => new string[] {};

        public string Description => "Отключить спавн МОГ и ПХ.";

        public static bool Mode = Plugin.Instance.Config.DisableSpawningMTFandCH;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(PlayerPermissions.FacilityManagement))
            {
                response = "У вас не прав на использование этой комманды. (Need: FacilityManagement)";
                return false;
            }
            string res = "Вы успешно ";
            string subcommand = arguments.At(0);
            if(subcommand == "on")
            {
                Mode = true;
                res = res + "<color=green>отключили спавн МОГ и ПХ</color>";                
            } else if(subcommand == "off")
            {
                Mode = false;
                res = res + "<color=red>включили спавн МОГ и ПХ</color>";                         
            } else
            {
                res = "Используйте: disablespawn <on/off>";                
            }
            response = res;
            return true;
        }
    }
}