using System;
using Learning.Scripts.Other;
using LearnProject.Scripts.Interfaces;
using UnityEngine;

namespace LearnProject.Scripts
{
    public class PauseManager : MonoBehaviour
    {
        public static bool PauseStatus { get; private set; }
        private IUIService _pauseView;
        private void Awake()
        {
            _pauseView = Game.Instance.UIService;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseStatus = !PauseStatus;

                if (PauseStatus)
                {
                    Time.timeScale = 0;
                    _pauseView.Show(UIViev.pause);
                }

                else
                {
                    Time.timeScale = 1;
                    _pauseView.Hide(UIViev.pause);
                }
            }
        }
    }
}