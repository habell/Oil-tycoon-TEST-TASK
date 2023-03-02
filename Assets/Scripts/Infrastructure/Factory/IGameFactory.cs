using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateMainHUD();
        GameObject CreateQuiz(GameObject guiParent, int quizID);
    }
}