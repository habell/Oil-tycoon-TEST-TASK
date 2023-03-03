using System;
using DG.Tweening;
using Infrastructure.AssetManagment;
using Infrastructure.Data;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Game.Quizzes
{
    public class Quiz3 : AbstractQuiz, IQuiz
    {
        [SerializeField]
        private Image hypnoCircle;
        
        private const int QuizID = 3;

        private IAssets _assets;

        private int _activeID = 0;

        private float _activeTime = 1f;
        
        private readonly Random _random = new Random();
        private PlayerProgress _playerProgress;

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
            _assets = AllServices.Container.Single<IAssets>();

            hypnoCircle.sprite = _assets.GetSprite(AssetPath.HypnoCirclePath);
            
            SetVisibleObjects(false);
            
            answers[0].gameObject.SetActive(true);
        }

        private void Update()
        {
            hypnoCircle.gameObject.transform.Rotate(0, 0, 70 * Time.deltaTime, Space.Self);

            _activeTime -= Time.deltaTime;

            if (!(_activeTime <= 0)) return;
            
            _activeTime = 1;
                
            answers[_activeID].gameObject.SetActive(false);
            _activeID++;
            if (answers.Count - 1 < _activeID)
                _activeID = 0;
                
            answers[_activeID].gameObject.SetActive(true);
            
            answers[_activeID].transform.position += new Vector3(_random.Next(-50, 50),_random.Next(-50, 50));
        }
    }
}