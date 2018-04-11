using System.ComponentModel.DataAnnotations;
using Eml.EntityBaseClasses;

namespace Eml.SoftDelete.Data.Entities
{
    public class Company : EntityBaseSoftDeleteInt
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}