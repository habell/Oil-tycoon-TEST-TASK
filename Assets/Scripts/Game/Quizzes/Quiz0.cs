using System;
using System.Collections.Generic;
using Infrastructure.Data;
using Infrastructure.Factory;
using Infrastructure.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Quizzes
{
    public class Quiz0 : AbstractQuiz, IQuiz
    {
        private const int QuizID = 0;

        [SerializeField]
        private TextMeshProUGUI question;

        [SerializeField]
        private List<Button> answers;

        [SerializeField]
        private int correctAnswerID;

        [SerializeField]
        private GamePreset gamePreset;

        private IGameFactory _gameFactory;

        private void Awake()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
            
            question.text = gamePreset.GameDataList[QuizID].question;

            for (int i = 0; i < answers.Count; i++)
                answers[i].GetComponentInChildren<TextMeshProUGUI>().text =
                    gamePreset.GameDataList[QuizID].answersText[i];

            correctAnswerID = gamePreset.GameDataList[QuizID].correctAnswerID;
        }

        public void OnPlayerClickAnswer(int id)
        {
            if(id == correctAnswerID) StartNextQuiz();
        }

        public void StartNextQuiz()
        {
            Destroy(this);
            _gameFactory.CreateQuiz(_gameFactory.GUIRoot, QuizID + 1);
            //TODO:: USE ANIMATIONS!
        }
    }
}