using System;
using AppProject.Core.Models;

namespace AppProject.Models;

public class KeyResponse<TIdType> : IResponse
    where TIdType : notnull
{
    required public TIdType? Id { get; set; }
}
