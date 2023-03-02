using Infrastructure.Factory;
using Unity.VisualScripting;

namespace Infrastructure.Services
{
    public class AllServices
    {
        private static AllServices _instance;

        public static AllServices Container => _instance ??= new AllServices();


        public void RegisterSingle<TService>(TService implement) where TService : IService => 
            Implementation<TService>.ServiceInstance = implement;

        public TService Single<TService>() where TService : IService => 
            Implementation<TService>.ServiceInstance;

    }
}