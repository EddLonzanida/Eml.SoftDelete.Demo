using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eml.SoftDelete.Data.BaseClasses;

namespace Eml.SoftDelete.Data.Entities
{
    [Table("Companies")]
    public class CompanyNoSoftDelete : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
