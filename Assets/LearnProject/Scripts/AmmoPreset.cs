using System.Collections.Generic;
using UnityEngine;

namespace LearnProject.Scripts
{
    [CreateAssetMenu(fileName = "Ammo Types", menuName = "Config/Ammo Types")]
    public class AmmoPreset : ScriptableObject
    {
        [SerializeField]
        private List<AmmoPresetData> _ammos;

        public List<AmmoPresetData> Ammos => _ammos;
    }
}