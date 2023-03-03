using Infrastructure.AssetManagment;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        public GameObject GUIRoot { get; private set; }

        public GameFactory(IAssets assets) => _assets = assets;

        public GameObject CreateMainHUD() => GUIRoot = _assets.Instantiate(AssetPath.HUDPath);

        public GameObject CreateQuiz(GameObject guiParent, int quizID) => _assets.Instantiate(guiParent, $"{AssetPath.QuizzesPath}{quizID}");
    }
}