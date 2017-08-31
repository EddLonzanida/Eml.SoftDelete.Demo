# [Eml.SoftDelete](https://www.nuget.org/packages/Eml.SoftDelete/)
Implement SoftDeletes using Entity Framework 6.


## Usage
#### 1. Add *softDeleteColumnConvention* in your [DbContext](https://github.com/EddLonzanida/Eml.SoftDelete.Demo/blob/master/Eml.SoftDelete.Data/DefaultDb.cs).

```javascript
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    var softDeleteColumnConvention = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
        SoftDeleteColumn.Key, (type, attributes) => attributes.Single().SoftDeleteColumnName);

    modelBuilder.Conventions.Add(softDeleteColumnConvention);
    base.OnModelCreating(modelBuilder);
}
```

#### 2. Decorate your Entities with  *[SoftDelete(**"DateDeleted"**)]* where ***DateDeleted*** is the SoftDeleteColumnName.

```javascript
[SoftDelete(SoftDeleteColumn.Name)]
public class Company : EntityBase
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
}
```

```javascript
public abstract class EntityBase : IEntityBase
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "DateDeleted")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? DateDeleted { get; set; }  // <- SoftDeleteColumnName
}
```

#### 3. Add SoftDeleteInterceptor.

```javascript
public class SoftDeleteInterceptor : SoftDeleteInterceptorBase
{
}
```


## That's it.
