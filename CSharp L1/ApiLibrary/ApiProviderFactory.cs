namespace ApiLibrary
{
    using ApiLibrary.Providers;

    public static class ApiProviderFactory
    {
        public static IProvider GetApiProvider()
        {
            return new PublicApiProvider();
        }
    }
}
