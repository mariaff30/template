using System;
using AppProject.Core.Models;

namespace AppProject.Models;

public class SummaryResponse<TSummary> : IResponse
    where TSummary : class, ISummary
{
    required public TSummary? Summary { get; set; }
}
