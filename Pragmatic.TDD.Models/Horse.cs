namespace Pragmatic.TDD.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Horses")]
    public partial class Horse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Horse()
        {
            SireOffspring = new HashSet<Horse>();
            DamOffspring = new HashSet<Horse>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public byte ColorId { get; set; }

        public int? SireId { get; set; }

        public int? DamId { get; set; }

        public int RaceStarts { get; set; }

        public int RaceWins { get; set; }

        public int RacePlace { get; set; }

        public int RaceShow { get; set; }

        public int Earnings { get; set; }

        public virtual Color Color { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horse> SireOffspring { get; set; }

        public virtual Horse Sire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horse> DamOffspring { get; set; }

        public virtual Horse Dam { get; set; }
    }
}
