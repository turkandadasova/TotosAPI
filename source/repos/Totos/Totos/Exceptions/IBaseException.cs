﻿namespace Totos.Exceptions
{
    public interface IBaseException
    {
        int StatusCode { get; }
        string ErrorMessage { get; }
    }
}
