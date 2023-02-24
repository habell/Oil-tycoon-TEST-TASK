using UnityEngine;

namespace Infrastructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private const string InitialScene = "Initial";
        private const string MainScene = "Main";
        

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() => _sceneLoader.Load(InitialScene, EnterLoadLevel);

        private void EnterLoadLevel() => 
            _gameStateMachine.Enter<LoadLevelState, string>(MainScene);

        public void Exit() { }
    }
}