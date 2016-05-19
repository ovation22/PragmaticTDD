using System.Collections.Generic;
using System.Linq;
using Pragmatic.TDD.Repositories.Interfaces;
using Pragmatic.TDD.Services.Interfaces;

namespace Pragmatic.TDD.Services
{
    public class HorseService : IHorseService
    {
        private readonly IRepository<Models.Horse> _horseRepository;

        public HorseService(IRepository<Models.Horse> horseRepository)
        {
            _horseRepository = horseRepository;
        }

        public IEnumerable<Dto.Horse> GetAll()
        {
            var horses = _horseRepository.GetAll();

            return horses.Select(Map);
        }

        public Dto.Horse Get(int id)
        {
            var horse = _horseRepository.Get(id);

            return horse == null ? null : Map(horse);
        }

        private static Dto.Horse Map(Models.Horse horse)
        {
            return new Dto.Horse
            {
                Id = horse.Id,
                Name = horse.Name,
                Color = horse.Color.Name,
                Dam = horse.Dam != null ? horse.Dam.Name : string.Empty,
                DamId = horse.DamId,
                Sire = horse.Sire != null ? horse.Sire.Name : string.Empty,
                SireId = horse.SireId
            };
        }
    }
}
