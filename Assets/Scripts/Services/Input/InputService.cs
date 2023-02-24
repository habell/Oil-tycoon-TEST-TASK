using System;
using Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.Input
{
    class InputService : MonoBehaviour, IInputService
    {
        private const string HUDTag = "HUD";
        private const string OilFactoryTag = "Clickable";
        private GameView _gameView;
        private Camera _camera;

        private void Awake()
        {
            _gameView = GameObject.FindWithTag(HUDTag).GetComponent<GameView>();
            _camera = Camera.main;
        }

        private void Update() => IsPlayerClicked();

        public void IsPlayerClicked()
        {
            if(_gameView.SellOilUI.activeSelf) return;
            if (!UnityEngine.Input.GetMouseButtonDown(0)) return;
            if (!Physics.Raycast(_camera.ScreenPointToRay(UnityEngine.Input.mousePosition), out RaycastHit hit)) return;
            if (hit.transform.CompareTag(OilFactoryTag))
                _gameView.UpgradeUI.SetActive(true);
        }
    }
}