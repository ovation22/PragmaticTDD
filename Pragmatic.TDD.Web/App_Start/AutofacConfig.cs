using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Pragmatic.TDD.Models;
using Pragmatic.TDD.Repositories;
using Pragmatic.TDD.Repositories.Interfaces;
using Pragmatic.TDD.Services;
using Pragmatic.TDD.Services.Interfaces;
using Pragmatic.TDD.Web.Interfaces;
using Pragmatic.TDD.Web.Mappers;

namespace Pragmatic.TDD.Web
{
    public static class AutofacConfig
    {
        private static ContainerBuilder _builder;

        public static void RegisterDependencies()
        {
            _builder = new ContainerBuilder();

            _builder.RegisterControllers(Assembly.GetExecutingAssembly());

            RegisterItems();

            var container = _builder.Build();

            var resolver = new AutofacDependencyResolver(container);

            DependencyResolver.SetResolver(resolver);
        }

        private static void RegisterItems()
        {
            _builder.RegisterType<PragmaticEntities>().As(typeof(DbContext)).InstancePerLifetimeScope();
            _builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            _builder.RegisterType(typeof(HorseService)).As(typeof(IHorseService)).InstancePerRequest();
            _builder.RegisterType(typeof(HorseToHorseDetailMapper)).As(typeof(IMapper<Dto.Horse, Models.HorseDetail>)).InstancePerRequest();
            _builder.RegisterType(typeof(HorseToHorseSummaryMapper)).As(typeof(IMapper<Dto.Horse, Models.HorseSummary>)).InstancePerRequest();
        }
    }
}