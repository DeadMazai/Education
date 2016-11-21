// <copyright file="IProvider.cs" company="Mikhail Kinchin">
// Copyright (c) 2016 All Rights Reserved
// </copyright>

namespace ApiLibrary.Providers
{
    public interface IProvider
    {
        bool HealthStatus();

        string GetResultAsString();

        T GetResult<T>();
    }
}
