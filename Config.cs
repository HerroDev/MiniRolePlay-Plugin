using System.ComponentModel;
using Exiled.API.Interfaces;

namespace MiniRolePlayPlugin
{
    public class Config : IConfig
    {
        [Description("Включить плагин")]
        public bool IsEnabled { get; set; } = true;
        [Description("Включить debug")]
        public bool Debug { get; set; } = false;
        [Description("Отключить побег из комплекса")]
        public bool DisableEscaping {get; set;} = false;
        [Description("Отключить спавн SCP-244B")]
        public bool DisableSpawningSCP244B {get; set;} = false;
    }
}