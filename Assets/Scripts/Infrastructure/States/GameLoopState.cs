using Infrastructure.Factory;
using UnityEngine;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IGameFactory _gameFactory;
        
        public GameLoopState(IGameFactory gameFactory) => _gameFactory = gameFactory;

        public void Enter() => _gameFactory.CreateQuiz(_gameFactory.GUIRoot,0);

        public void Exit() { }

    }
}