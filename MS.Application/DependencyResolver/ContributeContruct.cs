using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;
using MS.Application.DependencyManager;
using MS.Core.RepositoryBase.DependencyManager;
using MS.Core.UoWInterceptor;
using System.Linq;

namespace MS.Application.DependencyResolver
{
    public class ContributeConstruct : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            if (model.Services.Any(s => s == typeof(IServiceDependency)))
            {
                model.Interceptors.Add(InterceptorReference.ForType<UoWInterceptor>());
            }
        }
    }
}
