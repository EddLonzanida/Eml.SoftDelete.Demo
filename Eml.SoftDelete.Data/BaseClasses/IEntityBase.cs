using System;

namespace Eml.SoftDelete.Data.BaseClasses
{
    public interface IEntityBase
    {
        int Id { get; set; }
        DateTime? DateDeleted { get; set; }
    }
}