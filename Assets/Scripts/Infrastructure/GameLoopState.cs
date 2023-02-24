using Services.Input;
using UnityEngine;

namespace Infrastructure
{
    public class GameLoopState : IState
    {
        private readonly GameObject _game;

        public GameLoopState(GameObject game) => _game = game;

        public void Enter() => _game.AddComponent<InputService>();
        public void Exit() { }

    }
}