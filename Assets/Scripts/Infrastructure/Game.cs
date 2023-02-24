using UnityEngine;

namespace Infrastructure
{
    internal class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, GameObject gameBootstrapper) => 
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), gameBootstrapper);
    }
}