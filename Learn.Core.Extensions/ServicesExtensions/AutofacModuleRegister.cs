using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Learn.Core.Api.AOP;
using Learn.Core.Repository.BASE;

namespace Learn.Core.Extensions
{
	public class AutofacModuleRegister:Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var basePath = AppContext.BaseDirectory;

			var servicesDllFile = Path.Combine(basePath, "Learn.Core.Services.dll");
			var repositoryDllFile = Path.Combine(basePath, "Learn.Core.Repository.dll");
			if ((File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
			{
				//注册泛型仓储
				builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
				//注册AOP日志拦截器
				builder.RegisterType<LogAOP>();
				// 获取 Service.dll 程序集服务，并注册
				var assemblysServices = Assembly.LoadFrom(servicesDllFile);
				builder.RegisterAssemblyTypes(assemblysServices)
					//.Where(x=>x.Name.EndsWith("Services.dll"))//满足条件类型注册
					.AsImplementedInterfaces()            //注册的类型是interface
					.InstancePerDependency()             //指定生命周期
					.PropertiesAutowired()              //注册对象中的所有属性
					.EnableInterfaceInterceptors()      //引用Autofac动态代理
					.InterceptedBy(typeof(LogAOP));		//注册拦截器


				// 获取 Repository.dll 程序集服务，并注册
				var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
				builder.RegisterAssemblyTypes(assemblysRepository)
					.AsImplementedInterfaces()
					.PropertiesAutowired()
					.InstancePerDependency();

			}
		}
	}
}
