namespace Pragmatic.TDD.Services.Tests.Fakes
{
    public abstract class FakeDataContextBase
    {
        public void Clear()
        {
            var me = GetType().GetProperties();
            foreach (var prop in me)
            {
                prop.SetValue(this, null);
            }
        }
    }
}
