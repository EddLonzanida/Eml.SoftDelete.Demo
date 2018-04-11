using System.ComponentModel.Composition;
using Eml.Contracts.Entities;
using Eml.DataRepository;

namespace Eml.SoftDelete.Data.Repositories
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataRepositoryInt<T> : DataRepositoryInt<T, TestDb>
        where T : class, IEntityBase<int>
    {
    }
}
