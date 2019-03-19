using Autofac;
using GicPortal.Business.Manager;
using GicPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace GicPortal.WebApi.Helper
{
    public static class WebApiDependency
    {
        /// <summary>
        /// Starts the registering components with DI container and registers default dependency resolver and HTTP controller invoker.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="assemblies">The assemblies.</param>
        public static void Start(HttpConfiguration config, params Assembly[] assemblies)
        {
            // Add list of assemblies to be covered in IoC 
            var assemblyList = new List<Assembly>(assemblies) { Assembly.GetExecutingAssembly() };

            // Create your builder.
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(assemblyList.ToArray());

            //InitContainer(config, assemblyList);
        }

        //private static void InitContainer(HttpConfiguration config, List<Assembly> assemblies)
        //{
        //    var eventHandler = new IoCEventHandler
        //    {
        //        ApiConfig = config,
        //        AssemblyStartsWithFilter = new List<string> { },
        //        BeforeContainerBuild = BeforeContainerBuild
        //    };

        //    //eventHandler.TypesToBeExcluded.Add(typeof(JobSecurityContext));
        //    //eventHandler.TypesToBeExcluded.Add(typeof(HttpSecurityContext));

        //    //eventHandler.TypesToBeExcludedPredicate = t =>
        //    //    (t.IsSubclassOf(typeof(ApiController))
        //    //     || (t.FullName != null && (t.FullName.ToLower().Contains(".model.") || t.FullName.ToLower().Contains(".models.") || t.FullName.ToLower().Contains(".businessentities.")
        //    //          || t.FullName.ToLower().Contains(".repositoryexceptions."))));


        //    var container = IoCContainer.GetContainer(eventHandler, assemblies);
        //    Resolver.Container = container;
        //}

        //private static void BeforeContainerBuild(ContainerBuilder containerBuilder)
        //{
        //    //containerBuilder.RegisterType<HttpSecurityContext>().AsImplementedInterfaces();
        //    containerBuilder.RegisterType<UserManager>().As<IUserManager>();
        //    containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();

        //}

    }
}