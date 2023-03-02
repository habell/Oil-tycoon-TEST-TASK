namespace Infrastructure.Services
{
    public static class Implementation<TService> where TService : IService
    {
        public static TService ServiceInstance;
    }
}