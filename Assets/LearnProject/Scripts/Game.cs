using Learning.Scripts.Other;
using LearnProject.Scripts.Interfaces;
using LearnProject.Scripts.UI;
using UnityEngine;
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

        public GameObject PlayerPrefab => _playerPrefab;
        public GameObject Player { get; private set; }
        
        public Camera Camera => _camera;

        public AmmoPreset AmmoPreset => _ammoPreset;
        public ILevelManager LevelManager { get; private set; }

        public IUIService UIService { get; private set; }
        public static Game Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            UIService = new UIService(_uiPreset);
            UIService.Show(UIViev.main);
            LevelManager = new LevelManager();
        }

        public void PlayerSpawned(GameObject player)
        {
            Player = player;
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