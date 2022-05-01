using System;
using Learning.Scripts.DamageSystem;
using Learning.Scripts.Mechanics;
using LearnProject.Scripts.Enemyes;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LearnProject.Scripts.UI
{
    public class PlayerView : View
    {
        public Text EnemyLeftTo;
        public Text EnemyCounter;
        [FormerlySerializedAs("_playerHealthBar")]
        public Slider PlayerHealthBar;
        private Health _playerHealth;

        private void Start()
        {
            _playerHealth = Game.Instance.Player.GetComponent<Health>();
            PlayerHealthBar.maxValue = _playerHealth.MaxHealth;
            PlayerHealthBar.minValue = 0;
            var allEnemyElements = GameObject.FindGameObjectsWithTag("Enemy");
            EnemyLeftTo.text = allEnemyElements.Length.ToString();
            EnemySpawner.EnemiesChanged += EnemiesChanged;
            DieSystem.EnemiesChanged += EnemiesChanged;
        }

        private void EnemiesChanged(int obj)
        {
            var count = int.Parse(EnemyLeftTo.text);
            count = Math.Clamp((obj + count), 0, int.MaxValue);
            EnemyLeftTo.text = count.ToString();
            if (obj < 0)
                EnemyCounter.text = (int.Parse(EnemyCounter.text) + 1).ToString();
        }

        private void FixedUpdate()
        {
            Debug.Log(_playerHealth.Amount);

            PlayerHealthBar.value = _playerHealth.Amount;
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}