namespace CodeModelFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ninja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ninja()
        {
            NinjaEquipments = new HashSet<NinjaEquipment>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool ServedInOniwaban { get; set; }

        public int ClanId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual Clan Clan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NinjaEquipment> NinjaEquipments { get; set; }
    }
}
