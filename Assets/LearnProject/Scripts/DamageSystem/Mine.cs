using System.Collections.Generic;
using UnityEngine;

namespace Learning.Scripts.DamageSystem
{
    [RequireComponent(typeof(SphereCollider))]
    public class Mine : AbstractAmmo
    {
        [SerializeField]
        private float _explosiveMovingForce = 6f;

        [SerializeField]
        private float _explosiveRadius = 12f;

        private List<GameObject> _ExplosivedEnemyes;
        private SphereCollider _explosiveZoneCollider;

        private void Awake()
        {
            _ExplosivedEnemyes = new List<GameObject>();
            _explosiveZoneCollider = GetComponent<SphereCollider>();
            _explosiveZoneCollider.radius = _explosiveRadius;
        }

        private void OnTriggerEnter(Collider other)
        {
            foreach (var explosivedEnemy in _ExplosivedEnemyes)
                if (explosivedEnemy == other.gameObject)
                    return;
            _ExplosivedEnemyes.Add(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            foreach (var explosivedEnemy in _ExplosivedEnemyes)
                if (explosivedEnemy == other.gameObject)
                {
                    _ExplosivedEnemyes.Remove(other.gameObject);
                    break;
                }
        }

        protected override void CollisionAmmo(Health objHealth)
        {
            // TODO: need to make explosive effects for homework
            foreach (var contactPoint in _ExplosivedEnemyes)
            {
                Debug.Log("contactPoint");
                if (!contactPoint) continue;
                if (contactPoint.TryGetComponent(out Rigidbody explosivedObject))
                    explosivedObject.AddForce(-explosivedObject.transform.forward * _explosiveMovingForce,
                        ForceMode.Impulse);
            }
            objHealth.Hurt(_damage);

            Destroy(gameObject);
        }
    }
}