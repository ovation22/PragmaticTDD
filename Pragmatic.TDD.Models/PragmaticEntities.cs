namespace Pragmatic.TDD.Models
{
    using System.Data.Entity;

    public partial class PragmaticEntities : DbContext
    {
        public PragmaticEntities()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Horse> Horses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>()
                .HasMany(e => e.Horses)
                .WithRequired(e => e.Color)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Horse>()
                .HasMany(e => e.SireOffspring)
                .WithOptional(e => e.Sire)
                .HasForeignKey(e => e.SireId);

            modelBuilder.Entity<Horse>()
                .HasMany(e => e.DamOffspring)
                .WithOptional(e => e.Dam)
                .HasForeignKey(e => e.DamId);
        }
    }
}
