namespace Pragmatic.TDD.Web.Interfaces
{
    public interface IMapper<TFrom, TTo>
    {
        TTo Map(TFrom from);
    }
}