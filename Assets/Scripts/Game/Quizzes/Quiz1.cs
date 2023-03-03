using DG.Tweening;
using Infrastructure.Data;
using Infrastructure.Factory;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Game.Quizzes
{
    public class Quiz1 : AbstractQuiz, IQuiz
    {
        [SerializeField]
        private RectTransform rectTransform;
        
        [SerializeField]
        private VideoPlayer videoPlayer;

        private const int QuizID = 1;
        
        private float _animationTimer = 2f;
        private bool _animationEnable = false;

        private IGameFactory _gameFactory;
        private PlayerProgress _playerProgress;

        public void OnPlayerClickAnswer(int id)
        {
            if (id == correctAnswerID) _playerProgress.playerScore++;
            
            _playerProgress.playerAnswers.Add(gamePreset.GameDataList[QuizID].answersText[id]);
            
            rectTransform.DOScale(3, _animationTimer);
            rectTransform.gameObject.GetComponent<Image>().color = Color.green;
            question.text = "УИИИИ";

            _animationEnable = true;
        }

        public void StartNextQuiz()
        {
            gameFactory.CreateQuiz(gameFactory.GUIRoot, QuizID + 1);
            Destroy(gameObject);
        }

        private void SetVisibleObjects(bool status)
        {
            foreach (var button in answers) 
                button.gameObject.SetActive(status);
        }

        private void Awake()
        {
            _playerProgress = AllServices.Container.Single<PlayerProgress>();
            DefaultInitializeQuiz(QuizID);
            question.text = null;
            SetVisibleObjects(false);
        }

        private void Update()
        {
            if (videoPlayer.length - 4 < videoPlayer.time)
            {
                SetVisibleObjects(true);
                ShowQuestionText();
            }
            
            if (!_animationEnable) return;

            _animationTimer -= Time.deltaTime;

            if (_animationTimer < 0)
                StartNextQuiz();
        }

        private void ShowQuestionText() => question.text = gamePreset.GameDataList[QuizID].question;
    }
}