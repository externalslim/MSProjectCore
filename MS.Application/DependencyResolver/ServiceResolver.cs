using AutoMapper;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MS.Application.DependencyManager;
using MS.Core.RepositoryBase.DependencyManager;
using MS.Core.UoW;
using MS.Core.UoWInterceptor;
using MS.Helper.Mapping;
using System;
using System.Reflection;

namespace MS.Application.DependencyResolver
{
    public class ServiceResolver
    {
        private static WindsorContainer _container;
        private static IServiceProvider _serviceProvider;
        public ServiceResolver(IServiceCollection services)
        {
            _container = new WindsorContainer();
            
            _container.Kernel.ComponentRegistered += Kernel_ComponentRegistered;

            Assembly assemblyServices = typeof(IServiceDependency).Assembly;
            Assembly assemblyRepository = typeof(IRepositoryDependency).Assembly;
            _container.Register(
                  Component.For<UoWInterceptor>().LifeStyle.Transient
                , Classes.FromAssembly(assemblyServices).BasedOn(typeof(IServiceDependency)).WithService.AllInterfaces()
                , Classes.FromAssembly(assemblyRepository).BasedOn(typeof(IRepositoryDependency)).WithService.AllInterfaces()
                );

            _serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(_container, services);
        }

        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }

        void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            if (UnitOfWorkHelper.IsRepositoryClass(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(UoWInterceptor)));
            }

            foreach (var method in handler.ComponentModel.Implementation.GetMethods())
            {
                if (UnitOfWorkHelper.HasUnitOfWorkAttribute(method))
                {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(UoWInterceptor)));
                    return;
                }
            }
        }


    }
}
