using Learning.Scripts.Other;
using UnityEngine;

namespace Learning.Scripts.DamageSystem
{
    public class Bullet : AbstractAmmo
    {
        [SerializeField] private float _bulletLifeTime = 1;
        private float _lifeTimer;

        [SerializeField] private float _bulletSpeed = 2;

        [SerializeField] private Vector3 _plVector;

        private Transform _parentTransform;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _parentTransform = GetComponentInParent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
            destroyableOnCollision = true;
            _bulletSpeed = 10 / _bulletSpeed;
            _lifeTimer = _bulletLifeTime;
        }

        protected override void CollisionAmmo(Health objHealth)
        {
            // TODO: need to make explosive effects for homework
            objHealth.Hurt(_damage);
            DestroyBullet();
        }

        private void FixedUpdate()
        {
            if (!gameObject.activeSelf) return;
            _lifeTimer -= Time.fixedDeltaTime;
            if (_lifeTimer <= 0) DestroyBullet();
            gameObject.transform.position += _plVector / _bulletSpeed;
        }

        public void ShotBullet()
        {
            gameObject.SetActive(true);
            _lifeTimer = _bulletLifeTime;
            _plVector = _parentTransform.forward * _bulletSpeed;
        }
        private void DestroyBullet()
        {
            gameObject.transform.position = Vector3.zero;
            _rigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}