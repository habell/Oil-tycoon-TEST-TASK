using Infrastructure.AssetManagment;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        
        
        private readonly IAssets _assetses;

        public GameFactory(IAssets assetses) => _assetses = assetses;

        public GameObject CreateHUD() => _assetses.Instantiate(AssetPath.HUDPath);
    }
}