using System.Collections.Generic;
using Pragmatic.TDD.Services.Tests.Fakes;

namespace Pragmatic.TDD.Services.Tests.Factories
{
    public static class HorseFactory
    {
        private static FakeDataContext _context;

        public static Models.Horse Create(FakeDataContext context, int id = 1, string name = "Man o' War")
        {
            _context = context;
            Setup(context);

            var horse = new Models.Horse
            {
                Id = id,
                Name = name
            };

            context.Horses.Add(horse);

            return horse;
        }

        public static Models.Horse WithColor(this Models.Horse horse)
        {
            var color = ColorFactory.Create(_context);

            horse.Color = color;
            horse.ColorId = color.Id;

            return horse;
        }

        public static Models.Horse WithDam(this Models.Horse horse, int id = 2, string name = "Dam")
        {
            var dam = Create(_context, id, name);

            horse.Dam = dam;
            horse.DamId = dam.Id;

            return horse;
        }

        public static Models.Horse WithSire(this Models.Horse horse, int id = 3, string name = "Sire")
        {
            var sire = Create(_context, id, name);

            horse.Sire = sire;
            horse.SireId = sire.Id;

            return horse;
        }

        private static void Setup(FakeDataContext context)
        {
            context.Horses = context.Horses ?? new List<Models.Horse>();
        }
    }
}