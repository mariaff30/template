using System;
using AppProject.Core.Models;

namespace AppProject.Models;

public class GetByIdRequest<TIdType> : IRequest
{
    required public TIdType Id { get; set; }
}
