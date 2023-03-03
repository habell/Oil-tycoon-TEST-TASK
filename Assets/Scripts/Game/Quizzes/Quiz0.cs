using DG.Tweening;
using Infrastructure.Data;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Quizzes
{
    public class Quiz0 : AbstractQuiz, IQuiz
    {
        [SerializeField]
        private RectTransform rectTransform;

        private const int QuizID = 0;

        private float _animationTimer = 2f;
        private bool _animationEnable = false;

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
            rectTransform.DOKill();
            gameFactory.CreateQuiz(gameFactory.GUIRoot, QuizID + 1);
            Destroy(gameObject);
        }

        private void Update()
        {
            if (!_animationEnable) return;

            _animationTimer -= Time.deltaTime;

            if (_animationTimer < 0)
                StartNextQuiz();
        }

        private void Awake()
        {
            _playerProgress = AllServices.Container.Single<PlayerProgress>();
            question.text = gamePreset.GameDataList[QuizID].question;
            DefaultInitializeQuiz(QuizID);
        }
    }
}