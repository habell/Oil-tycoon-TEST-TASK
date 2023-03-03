using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class PlayerProgress : IService
    {
        public List<string> playerAnswers = new List<string>(4);
        public int playerScore;

        public string GetPlayerInfo()
        {
            return $"Ваши баллы: {playerScore}\n\n" +
                   $"Ваши ответы на вопросы:\n" +
                   $"1: {playerAnswers[0]}\n" +
                   $"2: {playerAnswers[1]}\n" +
                   $"3: {playerAnswers[2]}\n" +
                   $"4: {playerAnswers[3]}\n";
        }
    }
}