namespace Pragmatic.TDD.Web.Models
{
    public class HorseSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Dam { get; set; }
        public int? DamId { get; set; }
        public string Sire { get; set; }
        public int? SireId { get; set; }
    }
}