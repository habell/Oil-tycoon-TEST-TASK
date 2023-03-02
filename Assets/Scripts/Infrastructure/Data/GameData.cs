using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    [Serializable]
    public struct GameData
    {
        public LevelType levelType;

        public string questionString;

        public List<string> answerOptions;

        public float waitSecondsToOpenQuestion;

        public string dataReference;
    }
}