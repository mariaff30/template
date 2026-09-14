using System;
using AppProject.Core.Models;

namespace AppProject.Models;

public class EntitiesResponse<TEntity> : IResponse
    where TEntity : class
{
    required public IReadOnlyCollection<TEntity>? Entities { get; set; } = [];
}
