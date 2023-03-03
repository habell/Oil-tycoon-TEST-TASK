using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject GUIRoot { get; }
        GameObject CreateMainHUD();
        GameObject CreateQuiz(GameObject guiParent, int quizID);

    }
}