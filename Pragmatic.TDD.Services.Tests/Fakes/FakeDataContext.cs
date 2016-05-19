using System.Collections.Generic;

namespace Pragmatic.TDD.Services.Tests.Fakes
{
    public class FakeDataContext : FakeDataContextBase
    {
        public IList<Models.Horse> Horses { get; set; }
        public IList<Models.Color> Colors { get; set; }
    }
}
