using Infrastructure.Factory;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;


        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName) => _sceneLoader.Load(sceneName, OnLoaded);

        public void Exit() { }

        private void OnLoaded()
        {
            _gameFactory.CreateMainHUD();
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}