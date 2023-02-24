using System;
using Services.Input;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private IInputService _inputService;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            _game = new Game(this, gameObject);
            _game.StateMachine.Enter<BootstrapState>();
        }
    }
}