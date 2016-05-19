using System.Collections.Generic;

namespace Pragmatic.TDD.Services.Interfaces
{
    public interface IHorseService
    {
        IEnumerable<Dto.Horse> GetAll();
        Dto.Horse Get(int id);
    }
}
