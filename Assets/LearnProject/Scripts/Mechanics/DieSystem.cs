using System;
using Learning.Scripts.Enemyes;
using Learning.Scripts.Other;
using UnityEngine;
using UnityEngine.UI;

namespace Learning.Scripts.Mechanics
{
    public class DieSystem : MonoBehaviour
    {
        [SerializeField] private Text _enemyCounter;

        public event Action OnDied;
        
        private void Start()
        {
            _enemyCounter = (Text)GameObject.FindGameObjectWithTag("EnemyCounter").GetComponent(typeof(Text));
        }

        protected void Die(CharactersType type)
        {
            switch (type)
            {
                case CharactersType.Enemy:
                    if(_enemyCounter != null) _enemyCounter.text = (int.Parse(_enemyCounter.text) + 1).ToString(); 
                    EnemyLeftTo.UpdateEnemyCount(true);
                    DefaultDie();
                    break;
                default:
                    DefaultDie();
                    break;
            }
        }

        private void DefaultDie()
        {
            OnDied?.Invoke();
            Destroy(gameObject);
        }
    }
}
