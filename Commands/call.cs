using CommandSystem;
using System.Collections.Generic;
using System;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using MEC;
using System.Text;
using NorthwoodLib.Pools;
using MiniRolePlayPlugin;

namespace MiniRolePlayPlugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class call : ICommand
    {
        public List<int> Players_Muted = new List<int>();
        public string Command => "call";

        public string[] Aliases => new string[] { };

        public string Description => "Вызвать администратора.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player sendPlayer = Player.Get(sender);
            string message = string.Join(" ", arguments);
            string result;
            if (Players_Muted.Contains(sendPlayer.Id))
            {
                response = $"Подождите {Plugin.Instance.Config.CallCooldown} секунд перед повторной отпракой команды .call!";
                return false;
            }
            if (message.Contains("<") || message.Contains(">") || message.Contains("@") || message.Contains("#") || message.Contains("%") || message.Contains("$") || message.Contains("^") || message.Contains("&") || message.Contains("*") || message.Contains("(") || message.Contains(")") || message.Contains("{") || message.Contains("}"))
            {
                response = "В сообщениие запрещено использовать спец.символы!";
                return false;
            }
            if (message.IsEmpty())
            {
                result = $"<color=red>[{sendPlayer.Id}] {sendPlayer.Nickname}</color> вызывает администратора!";
            }
            else
            {
                result = $"<color=red>[{sendPlayer.Id}] {sendPlayer.Nickname}</color> вызывает администратора! Подробности в ` !";
            }
            foreach (Player pl in Player.List)
            {
                if (pl.CheckPermission(PlayerPermissions.AdminChat))
                {
                    pl.Broadcast(10, result);
                    string console = $"[{sendPlayer.Id}] {sendPlayer.Nickname} вызывает администратора по причине: {message}";
                    pl.SendConsoleMessage(console, "yellow");
                }
            }
            Players_Muted.Add(sendPlayer.Id);
            Timing.CallDelayed(Plugin.Instance.Config.CallCooldown, () =>
            {
                Players_Muted.Remove(sendPlayer.Id);
            });
            response = "Вы успешно вызвали администратора!";
            return true;
        }
    }
}
