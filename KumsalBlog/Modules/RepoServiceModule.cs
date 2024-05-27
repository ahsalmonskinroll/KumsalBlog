using Autofac;
using KumsalBlog.Business.Mapping;
using KumsalBlog.Business.Service;
using KumsalBlog.Kernel.Repository;
using KumsalBlog.Kernel.Service;
using KumsalBlog.Kernel.UnityOfWork;
using KumsalBlog.Types.Repositories;
using KumsalBlog.Types.UnityOfWork;
using KumsalBlog.Types;
using System.Reflection;


namespace KumsalBlog.Modules
{
	public class RepoServiceModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{

			builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
			builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

			builder.RegisterType<UnityOfWork>().As<IUnityOfWork>();



			var apiAssembly = Assembly.GetExecutingAssembly();
			var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
			var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

			builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


			builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();




		}
	}
}