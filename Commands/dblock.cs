using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Doors;

namespace MiniRolePlayPlugin.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class dblock : ICommand
    {
        public string Command => "dblock";

        public string[] Aliases => new string[] {};

        public string Description => "управлять D блоком.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(PlayerPermissions.FacilityManagement))
            {
                response = "У вас не прав на использование этой комманды. (Need: FacilityManagement)";
                return false;
            }
            string res = "Вы успешно ";
            string subcommand = arguments.At(0);
            if(subcommand == "open")
            {
                foreach(Door room in Door.List)
                {
                    if(room.Type == Exiled.API.Enums.DoorType.PrisonDoor) room.IsOpen = true;
                }
                res = res + "<color=green>открыли д блок</color>";                
            } else if(subcommand == "close")
            {
                foreach(Door room in Door.List)
                {
                    if(room.Type == Exiled.API.Enums.DoorType.PrisonDoor) room.IsOpen = false;
                }
                res = res + "<color=red>закрыли Д блок</color>";                
            } else if(subcommand == "block")
            {
                foreach(Door room in Door.List)
                {
                    if(room.Type == Exiled.API.Enums.DoorType.PrisonDoor) room.Lock(Exiled.API.Enums.DoorLockType.AdminCommand);
                }
                res = res + "<color=red>заблокировали д блок Д блок</color>";                
            } else if (subcommand == "unblock")
            {
                foreach(Door room in Door.List)
                {
                    if(room.Type == Exiled.API.Enums.DoorType.PrisonDoor) room.Unlock();
                }
                res = res + "<color=green>разблокировали д блок Д блок</color>";                
            } else
            {
                res = "Используйте: dblock <open/close/block/unblock>";                
            }
            response = res;
            return true;
        }
    }
}