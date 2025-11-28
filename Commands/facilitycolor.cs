using System;
using CommandSystem;
using Exiled.API.Features;

namespace MiniRolePlayPlugin.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class facilitycolor : ICommand
    {
        public string Command => "facilitycolor";

        public string[] Aliases => new string[] {};

        public string Description => "Изменить цвет света в комплекса(Стандартные значения 1 1 1).";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(PlayerPermissions.FacilityManagement))
            {
                response = "У вас не прав на использование этой комманды. (Need: FacilityManagement)";
                return false;
            }

            if (arguments.Count < 3)
            {
                response = "Use: facilitycolor <r:number> <g:number> <b:number>";
                return false;
            }
            int r, g, b;
            if (!int.TryParse(arguments.At(0), out r) || !int.TryParse(arguments.At(1), out g) || !int.TryParse(arguments.At(2), out b))
            {
                response = "Use: facilitycolor <r:number> <g:number> <b:number>";
                return false;
            }

            if (r > 255 || g > 255 || b > 255 || r < 0 || g < 0 || b < 0)
            {
                response = "Use: r g b не должны быть больше 255 и меньше 0";
                return false;
            }
            if(r == 1 && g == 1 && b == 1)
            {
                Map.ResetLightsColor();
            }
            UnityEngine.Color color = new UnityEngine.Color(r, g, b);
            Map.ChangeLightsColor(color);
            response = "Вы успешно изменили цвет света во всем комплексе!";
            return true;
        }
    }
}