using Pragmatic.TDD.Web.Interfaces;

namespace Pragmatic.TDD.Web.Mappers
{
    public class HorseToHorseDetailMapper : IMapper<Dto.Horse, Models.HorseDetail>
    {
        public Models.HorseDetail Map(Dto.Horse horse)
        {
            return new Models.HorseDetail
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