using Learning.Scripts.Other;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace LearnProject.Scripts.UI
{
    public class MainView : View
    {
        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private Button _loadButton;

        [SerializeField]
        private Button _configButton;

        private readonly Game _game = Game.Instance;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartButtonClick);
            _loadButton.onClick.AddListener(LoadButtonClick);
            _configButton.onClick.AddListener(ConfigButtonClick);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartButtonClick);
            _loadButton.onClick.RemoveListener(LoadButtonClick);
            _configButton.onClick.RemoveListener(ConfigButtonClick);
        }

        private void StartButtonClick()
        {
            _game.UIService.Hide(UIViev.main);
            _game.LevelManager.LoadScene(_game.LevelManager.GetSceneId() + 1);
        }

        private void LoadButtonClick()
        {
            _game.UIService.Hide(UIViev.main);
            _game.LevelManager.LoadScene("Main");
        }

        private void ConfigButtonClick()
        {
            _game.UIService.Hide(UIViev.main);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}