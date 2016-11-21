
namespace ApiLibrary.Providers
{
    using System;

    public class PublicApiProvider : IProvider
    {
        public Boolean HealthStatus()
        {
            throw new NotImplementedException();
        }

        public String GetResultAsString()
        {
            throw new NotImplementedException();
        }

        public T GetResult<T>()
        {
            throw new NotImplementedException();
        }
    }
}
