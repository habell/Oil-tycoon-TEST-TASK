using UnityEngine;

namespace Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private const string HUDPath = "Prefabs/HUD";

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) => _sceneLoader.Load(sceneName, OnLoaded);

        public void Exit() { }

        private void OnLoaded()
        {
            var obj = Instantiate(HUDPath);
            _gameStateMachine.Enter<GameLoopState>();
        }

        private GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
    }
}