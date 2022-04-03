using System;
using UnityEngine;
using UnityEngine.UI;

namespace Learning.Scripts.Enemyes
{
    public class EnemyLeftTo : MonoBehaviour
    {
        private static Text _enemyCounter;
        private static float _timer = 30f;

        private void Start()
        {
            _enemyCounter = gameObject.GetComponent<Text>();
            FixEnemyCounter();
        }

        public static void UpdateEnemyCount(bool dieEnemy)
        {
            int count = int.Parse(_enemyCounter.text);
            count = dieEnemy ? count - 1 : count + 1;
            _enemyCounter.text = count.ToString();
            if (count <= 0)
            {
                print("GAME OVER!!!");
                return;
            }
            
        }

        private void FixEnemyCounter()
        {
            var allEnemyElements = GameObject.FindGameObjectsWithTag("Enemy");
            _enemyCounter.text = allEnemyElements.Length.ToString();
        }

        private void FixedUpdate()
        {
            if (_timer <= 0)
            {
                _timer = 30f;
                FixEnemyCounter();
            }
            _timer -= Time.fixedDeltaTime;
        }
    }
}
