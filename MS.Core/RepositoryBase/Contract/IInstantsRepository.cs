using MS.Core.RepositoryBase.DependencyManager;
using MS.Data.Models;
using MS.Helper.Dtos.Instants;

namespace MS.Core.RepositoryBase.Contract
{
    public interface IInstantsRepository : IRepository<Instants>, IRepositoryDependency
    {
        InstantsOutput GetAllInstants();
        InstantsOutput GetAllActiveInstants();

        InstantsOutput GetInstantByIdFilter(InstantsInput input);

        InstantsOutput CreateInstant(InstantsInput input);
        InstantsOutput UpdateInstant(InstantsInput input);
        bool DeleteInstant(InstantsInput input);

    }
}
