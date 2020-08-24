using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Ninject;
using Magazyn.Domain.Abstract;
using Magazyn.Domain.Concrete;


namespace Magazyn.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam; AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<ILoginRepository>().To<EFLoginRepository>();
            kernel.Bind<IOrderRepository>().To<EFOrderRepository>();
            kernel.Bind<ISaleRepository>().To<EFSaleRepository>();
            kernel.Bind<IPartnerRepository>().To<EFPartnerRepository>();
            kernel.Bind<IMMRepository>().To<EFMMRepository>();
            kernel.Bind<IPWRepository>().To<EFPWRepository>();
            kernel.Bind<IPZRepository>().To<EFPZRepository>();
            kernel.Bind<IRWRepository>().To<EFRWRepository>();
            kernel.Bind<IRZRepository>().To<EFRZRepository>();
            kernel.Bind<ISetRepository>().To<EFSetRepository>();


            EmailSettings emailSettings = new EmailSettings {
                WriteAsFile = bool.Parse(ConfigurationManager
                .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>()
                .To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);

            
        }
    }
}
