using Infrastructure.Data;
using Infrastructure.Services;
using UnityEngine;

namespace Game.Quizzes
{
    public class Quiz2 : AbstractQuiz, IQuiz
    {
        [SerializeField]
        private AudioSource audioSource;

        private PlayerProgress _playerProgress;

        private const int QuizID = 2;

        public void OnPlayerClickAnswer(int id)
        {
            if (id == correctAnswerID) _playerProgress.playerScore++;
            
            _playerProgress.playerAnswers.Add(gamePreset.GameDataList[QuizID].answersText[id]);

            StartNextQuiz();
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
            if (question.text != null) return;
            
            if (audioSource.clip.length - 4 < audioSource.time)
            {
                SetVisibleObjects(true);
                ShowQuestionText();
            }
        }
        
        private void ShowQuestionText() => question.text = gamePreset.GameDataList[QuizID].question;
    }
}