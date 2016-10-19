using System.ComponentModel;

namespace NinjaDomain.Classes.Enums
{
    public enum EquipmentType
    {
        [Description("Tool")]
        Tool = 1,
        [Description("Weapon")]
        Weapon = 2,
        [Description("Outerwear")]
        Outerwear = 3
    }
}