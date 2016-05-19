using System.Collections.Generic;
using Pragmatic.TDD.Services.Tests.Fakes;

namespace Pragmatic.TDD.Services.Tests.Factories
{
    public static class ColorFactory
    {
        public static Models.Color Create(FakeDataContext context, byte id = 2, string name = "Chestnut")
        {
            Setup(context);

            var color = new Models.Color
            {
                Id = id,
                Name = name
            };

            context.Colors.Add(color);

            return color;
        }

        private static void Setup(FakeDataContext context)
        {
            context.Colors = context.Colors ?? new List<Models.Color>();
        }
    }
}