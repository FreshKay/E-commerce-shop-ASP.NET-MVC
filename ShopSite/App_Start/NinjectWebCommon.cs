[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ShopSite.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ShopSite.App_Start.NinjectWebCommon), "Stop")]

namespace ShopSite.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using ShopSite.Infrastructure;

    //Dependency injector
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        // Starts the application
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        // Stops the application.
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        //Creates the kernel that will manage your application.
        // <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        // Load your modules or register your services here!
        // <param name="kernel">The kernel.</param>

        // Postal service
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IMailService>().To<HangfireMailService>();
        }        
    }
}
