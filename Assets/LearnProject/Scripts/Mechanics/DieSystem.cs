using System;
using Learning.Scripts.Enemyes;
using Learning.Scripts.Other;
using LearnProject.Scripts.Enemyes;
using LearnProject.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Learning.Scripts.Mechanics
{
    public class DieSystem : MonoBehaviour
    {
        [SerializeField]
        private Text _enemyCounter;

        public static Action<int> EnemiesChanged;

        protected void Die(CharactersType type)
        {
            print("DIE");
            switch (type)
            {
                case CharactersType.Enemy:
                    EnemiesChanged?.Invoke(-1);
                    print("DIEDIE");
                    DefaultDie();
                    break;
                default:
                    DefaultDie();
                    break;
            }
        }

        private void DefaultDie()
        {
            Destroy(gameObject);
        }
    }
}