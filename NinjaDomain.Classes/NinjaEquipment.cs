using NinjaDomain.Classes.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using NinjaDomain.Classes.Enums;

namespace NinjaDomain.Classes
{
    public class NinjaEquipment : IModificationHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        [Required]
        public Ninja Ninja { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDirty { get; set; }
    }
}
