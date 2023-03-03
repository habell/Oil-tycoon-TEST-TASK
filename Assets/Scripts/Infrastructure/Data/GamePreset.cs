using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Data
{
    [CreateAssetMenu(fileName = "Game Preset", menuName = "Game settings preset")]
    public class GamePreset : ScriptableObject
    {
        [field: SerializeField]
        public List<GameData> GameDataList { get; private set; }
    }
}