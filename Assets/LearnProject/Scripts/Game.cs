using System;
using Learning.Scripts.DamageSystem;
using Learning.Scripts.Other;
using LearnProject.Scripts.Interfaces;
using LearnProject.Scripts.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace LearnProject.Scripts
{
    public class Game : MonoBehaviour
    {
        // game entry script
        [FormerlySerializedAs("_player")]
        [SerializeField]
        private GameObject _playerPrefab;

        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private UIPreset _uiPreset;

        [SerializeField]
        private AmmoPreset _ammoPreset;

        [SerializeField]
        private AudioSource _audioSource;

        public GameObject PlayerPrefab => _playerPrefab;
        public GameObject Player { get; private set; }
        
        public Camera Camera => _camera;

        public AmmoPreset AmmoPreset => _ammoPreset;
        public ILevelManager LevelManager { get; private set; }

        public IUIService UIService { get; private set; }
        public static Game Instance { get; private set; }

        private Health _plyHealth;

        private void Awake()
        {
            Instance = this;
            UIService = new UIService(_uiPreset);
            UIService.Show(UIViev.main);
            LevelManager = new LevelManager();
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayerSpawned(GameObject player)
        {
            Player = player;
        }

        private void FixedUpdate()
        {
            if (Player)
            {
                if (!_plyHealth) _plyHealth = Player.GetComponent<Health>();
                var healthSound = 2 - (_plyHealth.Amount / _plyHealth.MaxHealth);
                if (healthSound == _audioSource.pitch) return;
                if (healthSound < _audioSource.pitch)
                {
                    _audioSource.pitch -= 0.0001f;
                }
                else if(healthSound > _audioSource.pitch)
                {
                    _audioSource.pitch += 0.0001f;
                }
                //_audioSource.
            }
        }
        /*
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameTime.IsRunning)
                {
                    GameTime.Stop();
                    LevelManager.UnloadScene("Game");
                }
                UIService.Hide(UIView.Result);
                UIService.Show(UIView.Main);
            }
        }
        */
    }
}