using System;

namespace AppProject.Exceptions;

public class AppException(
    ExceptionCode exceptionCode = ExceptionCode.Generic,
    string? additionalInfo = null,
    Exception? innerException = null) : Exception(innerException?.Message, innerException)
{
    public ExceptionCode ExceptionCode { get; } = exceptionCode;

    public string? AdditionalInfo { get; } = additionalInfo;
}
