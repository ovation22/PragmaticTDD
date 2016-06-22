using Autofac;
using Pragmatic.TDD.Repositories.Interfaces;
using Pragmatic.TDD.Services.Interfaces;
using Pragmatic.TDD.Services.Tests.Fakes;

namespace Pragmatic.TDD.Services.Tests
{
    public class TestBase
    {
        private IContainer _container;

        public FakeDataContext Context => Container.Resolve<FakeDataContext>();

        protected IContainer Container
        {
            get
            {
                if (_container != null)
                    return _container;

                var builder = new ContainerBuilder();

                RegisterFakes(builder);
                RegisterRepository(builder);
                RegisterServices(builder);

                var container = builder.Build();

                _container = container;

                return _container;
            }
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<HorseService>().As<IHorseService>().SingleInstance();
        }

        private static void RegisterRepository(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(FakeRepository<>)).As(typeof(IRepository<>))
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }

        private static void RegisterFakes(ContainerBuilder builder)
        {
            builder.RegisterType<FakeDataContext>().AsSelf().SingleInstance();
            builder.RegisterType<FakeDataContextBase>().AsSelf().SingleInstance();
        }
    }
}