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
            response = "Вы успешно ";
            string subcommand = string.Join(" ", arguments);
            if(subcommand == "open")
            {
                foreach(Door room in Door.List)
                {
                    if(room.Type == Exiled.API.Enums.DoorType.PrisonDoor) room.IsOpen = true;
                }
                response = response + "<color=green>открыли д блок</color>";                
            } else if(subcommand == "close")
            {
                foreach(Door room in Door.List)
                {
                    if(room.Type == Exiled.API.Enums.DoorType.PrisonDoor) room.IsOpen = false;
                }
                response = response + "<color=red>закрыли Д блок</color>";                
            } else if(subcommand == "block")
            {
                foreach(Door room in Door.List)
                {
                    if(room.Type == Exiled.API.Enums.DoorType.PrisonDoor) room.Lock(Exiled.API.Enums.DoorLockType.AdminCommand);
                }
                response = response + "<color=red>заблокировали д блок Д блок</color>";                
            } else if (subcommand == "unblock")
            {
                foreach(Door room in Door.List)
                {
                    if(room.Type == Exiled.API.Enums.DoorType.PrisonDoor) room.Unlock();
                }
                response = response + "<color=green>разблокировали д блок Д блок</color>";                
            } else
            {
                response = "Используйте: dblock <open/close/block/unblock>";  
                return false;              
            }
            return true;
        }
    }
}