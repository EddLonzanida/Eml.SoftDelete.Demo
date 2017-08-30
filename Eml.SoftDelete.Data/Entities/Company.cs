using System.ComponentModel.DataAnnotations;
using Eml.SoftDelete.Data.BaseClasses;

namespace Eml.SoftDelete.Data.Entities
{
    [SoftDelete(SoftDeleteColumn.Name)]
    public class Company : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
