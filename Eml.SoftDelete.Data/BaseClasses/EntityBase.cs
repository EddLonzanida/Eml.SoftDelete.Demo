using System;
using System.ComponentModel.DataAnnotations;

namespace Eml.SoftDelete.Data.BaseClasses
{
    public abstract class EntityBase : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "DateDeleted")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateDeleted { get; set; }
    }
}
