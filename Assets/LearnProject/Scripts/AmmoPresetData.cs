using System;
using Learning.Scripts.DamageSystem;
using Learning.Scripts.Other;

namespace LearnProject.Scripts
{
    [Serializable]
    public struct AmmoPresetData
    {
        public AmmoTypes AmmoTypes;
        public AbstractAmmo AbstractAmmo;
    }
}