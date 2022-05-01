using Learning.Scripts.DamageSystem;
using LearnProject.Scripts;
using LearnProject.Scripts.Interfaces;
using UnityEngine;

namespace Learning.Scripts.Mechanics
{
    [RequireComponent(typeof(IHealth))]
    [RequireComponent(typeof(IMove))]
    [RequireComponent(typeof(MineFactory))]
    [RequireComponent(typeof(ShootScript))]
    public class Player : Unit
    {
        private static readonly int Shot = Animator.StringToHash("shot");

        private Animator _animator;
        public IHealth Health { get; private set; }
        public IMove MovingSystem { get; private set; }
        public InventorySystem InventorySystem { get; private set; }
        public MineFactory MineFactory { get; private set; }
        public ShootScript ShootScript { get; private set; }

        public float MaxHealth { get; private set; } = 1000;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            ShootScript = GetComponent<ShootScript>();
            MineFactory = GetComponent<MineFactory>();
        }

        private void Update()
        {
            if (PauseManager.PauseStatus) return;
            if (Input.GetMouseButtonDown(0))
            {
                ShootScript.Shot();
                _animator.SetTrigger(Shot);
            }

            if (Input.GetMouseButtonDown(1)) MineFactory.Place();
        }
    }
}