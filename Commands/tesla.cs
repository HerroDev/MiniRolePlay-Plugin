using System;
using CommandSystem;
using Exiled.API.Features;
using MiniRolePlayPlugin;

namespace MiniRolePlayPlugin.Commands
{
    
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class tesla : ICommand
    {
        public static bool teslaMode = Plugin.Instance.Config.TeslaGatesMode;
        public string Command => "tesla";

        public string[] Aliases => new string[] {};

        public string Description => "on/off тесла ворота.";

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
                teslaMode = true;
                res = res + "<color=green>включили тесла ворота</color>";                
            } else if(subcommand == "off")
            {
                teslaMode = false;
                res = res + "<color=red>отключили тесла ворота</color>";                         
            } else
            {
                res = "Используйте: tesla <on/off>";                
            }
            response = res;
            return true;
        }
    }
}