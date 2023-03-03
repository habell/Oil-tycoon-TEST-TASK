namespace Game.Quizzes
{
    public interface IQuiz
    {
        void StartNextQuiz();

        void OnPlayerClickAnswer(int id);
    }
}