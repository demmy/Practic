using Blog.Domain.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cache;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Blog.WebUI
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISessionFactory>()
                .ToMethod
                (
                    e =>
                        Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\BlogDB.mdf';Integrated Security=True"))
                        .Cache(c => c.UseQueryCache().ProviderClass<HashtableCacheProvider>())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BlogModel>())
                        // .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true,false))
                        .BuildConfiguration()
                        .BuildSessionFactory()
                )
                .InSingletonScope();

            Bind<ISession>()
                .ToMethod((ctx) => ctx.Kernel.Get<ISessionFactory>().OpenSession())
                .InRequestScope();
        }
    }
}