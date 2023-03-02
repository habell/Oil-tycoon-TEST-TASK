using UnityEngine;

namespace Infrastructure
{
    public class GameLoopState : IState
    {
        private readonly GameObject _game;

        public GameLoopState(GameObject game) => _game = game;

        public void Enter() { }

        public void Exit() { }

    }
}