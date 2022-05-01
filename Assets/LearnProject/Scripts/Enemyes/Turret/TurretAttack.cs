using Learning.Scripts.DamageSystem;
using UnityEngine;

namespace Learning.Scripts.Enemyes.Turret
{
    //[RequireComponent(typeof(Turret))]
    [RequireComponent(typeof(ShootScript))]
    public class TurretAttack : MonoBehaviour
    {
        [SerializeField]
        private float _attackSpeed = 1;

        private bool _attackStatus;

        private ShootScript _shootScript;

        private float _timer;

        private void Start()
        {
            _shootScript = (ShootScript)GetComponent(typeof(ShootScript));
        }

        private void FixedUpdate()
        {
            if (_attackStatus)
            {
                if (_timer < Time.fixedDeltaTime)
                {
                    _timer = _attackSpeed;
                    _shootScript.Shot();
                }

                _timer -= Time.fixedDeltaTime;
            }
        }

        public void SetAttackStatus(bool status)
        {
            _timer = _attackSpeed;
            _attackStatus = status;
        }
    }
}