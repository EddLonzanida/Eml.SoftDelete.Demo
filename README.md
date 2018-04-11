# [Eml.SoftDelete](https://www.nuget.org/packages/Eml.SoftDelete/)
Implement SoftDeletes using Entity Framework 6.


## Usage
#### 1. Add *softDeleteColumnConvention* in your [DbContext](https://github.com/EddLonzanida/Eml.SoftDelete.Demo/blob/master/Tests/TestArtifacts/Eml.SoftDelete.Data/TestDbSoftDelete.cs).

```javascript
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    var softDeleteColumnConvention = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
        SoftDeleteColumn.Key, (type, attributes) => attributes.Single().SoftDeleteColumnName);

    modelBuilder.Conventions.Add(softDeleteColumnConvention);
    base.OnModelCreating(modelBuilder);
}
```

#### 2. Inherit from any of the [base classes](https://www.nuget.org/packages/Eml.EntityBaseClasses/):  
* EntityBaseSoftDeleteGuid
* EntityBaseSoftDeleteInt

```javascript
public class Company : EntityBaseSoftDeleteInt
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
}
```

#### 3. Add a new class SoftDeleteInterceptor inheriting ***SoftDeleteInterceptorBase*** and let the base class do the heavy lifting.

```javascript
public class SoftDeleteInterceptor : SoftDeleteInterceptorBase
{
}
```


## That's it.
