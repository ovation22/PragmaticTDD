using Pragmatic.TDD.Web.Interfaces;

namespace Pragmatic.TDD.Web.Mappers
{
    public class HorseToHorseSummaryMapper : IMapper<Dto.Horse, Models.HorseSummary>
    {
        public Models.HorseSummary Map(Dto.Horse horse)
        {
            return new Models.HorseSummary
            {
                Id = horse.Id,
                Name = horse.Name,
                Color = horse.Color,
                Dam = horse.Dam,
                DamId = horse.DamId,
                Sire = horse.Sire,
                SireId = horse.SireId
            };
        }
    }
}