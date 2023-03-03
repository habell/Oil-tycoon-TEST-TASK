using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Infrastructure.Data
{
    [Serializable]
    public struct GameData
    {
        public string question;
        
        public List<string> answersText;
        
        public int correctAnswerID;
    }
}