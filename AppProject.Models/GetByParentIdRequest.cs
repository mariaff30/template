using System;
using AppProject.Core.Models;

namespace AppProject.Models;

public class GetByParentIdRequest<TIdType> : IRequest
    where TIdType : notnull
{
    required public TIdType ParentId { get; set; }
}
