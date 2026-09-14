using System;
using AppProject.Core.Models;

namespace AppProject.Models;

public class DeleteRequest<TIdType> : IRequest
    where TIdType : notnull
{
    required public TIdType? Id { get; set; }
}
