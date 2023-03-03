using System.Collections.Generic;
using Infrastructure.Data;
using Infrastructure.Factory;
using Infrastructure.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Quizzes
{
    public abstract class AbstractQuiz : MonoBehaviour
    {
        [SerializeField]
        protected TextMeshProUGUI question;

        [SerializeField]
        protected List<Button> answers;

        [SerializeField]
        protected int correctAnswerID;

        [SerializeField]
        protected GamePreset gamePreset;

        protected IGameFactory gameFactory;

        protected void DefaultInitializeQuiz(int quizID)
        {
            gameFactory = AllServices.Container.Single<IGameFactory>();

            for (int i = 0; i < answers.Count; i++)
                answers[i].GetComponentInChildren<TextMeshProUGUI>().text =
                    gamePreset.GameDataList[quizID].answersText[i];

            correctAnswerID = gamePreset.GameDataList[quizID].correctAnswerID;
        }
    }
}