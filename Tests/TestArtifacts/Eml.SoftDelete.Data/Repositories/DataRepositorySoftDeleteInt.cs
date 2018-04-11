using System.ComponentModel.Composition;
using Eml.Contracts.Entities;
using Eml.DataRepository;

namespace Eml.SoftDelete.Data.Repositories
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataRepositorySoftDeleteInt<T> : DataRepositorySoftDeleteInt<T, TestDb>
        where T :  class, IEntityBase<int>, IEntitySoftdeletableBase 
    {
    }
}
