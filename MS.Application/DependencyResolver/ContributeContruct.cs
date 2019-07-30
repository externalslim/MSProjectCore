using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;
using MS.Core.RepositoryBase;
using MS.Core.UoWInterceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.Application.DependencyResolver
{
    public class ContributeConstruct : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            if (model.Services.Any(s => s == typeof(IRepository)))
            {
                model.Interceptors.Add(InterceptorReference.ForType<UowInterceptor>());
            }
        }
    }
}
