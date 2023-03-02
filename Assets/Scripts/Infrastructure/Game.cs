using UnityEngine;

namespace Infrastructure
{
    internal class Game
    {
        public GameStateMachine StateMachine { get; }

        public Game(ICoroutineRunner coroutineRunner, GameObject gameBootstrapper) => 
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), gameBootstrapper);

    }
}