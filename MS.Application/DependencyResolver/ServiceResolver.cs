using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MS.Application.DependencyResolver
{
    public class ServiceResolver
    {
        private static WindsorContainer _container;
        private static IServiceProvider _serviceProvider;
        public ServiceResolver(IServiceCollection services)
        {
            _container = new WindsorContainer();
            _container.Kernel.ComponentModelBuilder.AddContributor(new ContributeConstruct());
            
            _container.Register();
            //Register your components in container
            //then
            _serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(_container, services);
        }

        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }

        Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().
                   SingleOrDefault(assembly => assembly.GetName().Name == name);
        }

    }
}
