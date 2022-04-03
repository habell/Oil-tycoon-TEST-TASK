using System.Collections.Generic;
using UnityEngine;

namespace Learning.Scripts.Enemyes.Turret
{
    [RequireComponent(typeof(Collider))]
    public class Turret : MonoBehaviour
    {
        [SerializeField] private string[] _EnemyTags;
        [field: SerializeField] public bool DamageAll { get; set; }

        [SerializeField] private float _rotateSpeed = 2;
    
        private Transform _targetEnemyPosition;

        private List<Collider> _AllCollisions = new List<Collider>();

        public Transform GetTargetEnemyPosition()
        {
            return _targetEnemyPosition;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            Transform enemyPosition = other.transform;
            if (DamageAll || (_EnemyTags.Length < 1))
            {
                SetEnemy(enemyPosition, other);
                return;
            }
            foreach (var _tag in _EnemyTags)
            {
                if (other.CompareTag(_tag))
                {
                    SetEnemy(enemyPosition, other);
                    break;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _AllCollisions.Remove(other);
            RemoveEnemy();
        }

        private void SetEnemy(Transform enemyPosition, Collider other)
        {
            //if (CompareTag(other.gameObject.tag)) return;
            if (other != null) _AllCollisions.Add(other);
            if (TryGetComponent(out TurretAttack turret ))
            {
                turret.SetAttackStatus(true);
            }
            _targetEnemyPosition = enemyPosition;
        }
    
        private void RemoveEnemy() 
        {
            if (_AllCollisions.Count < 1)
            {

                if (TryGetComponent(out TurretAttack turret))
                {
                    turret.SetAttackStatus(false);
                }

                _targetEnemyPosition = null;
            }
            else
            {
                SetEnemy(_AllCollisions[_AllCollisions.Count-1].transform, null);
            }
        }

        public void EnableDamageAllEntities(bool status)
        {
            DamageAll = status;
        }

        private void FixedUpdate()
        {
            if (_targetEnemyPosition != null)
            {
                var direction = _targetEnemyPosition.position - transform.position;
                var rotateStep = Vector3.RotateTowards(transform.forward, direction, _rotateSpeed * Time.fixedDeltaTime, 0f );
                transform.rotation = Quaternion.LookRotation(rotateStep);
            }
        }
    }
}
