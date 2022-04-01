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

        private void Start()
        {
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
            _lifeTimer = _bulletLifeTime;
            gameObject.SetActive(true);
        }
        private void DestroyBullet()
        {
            gameObject.transform.position = Vector3.zero;
            gameObject.SetActive(false);
        }

        public void BulletSetForward(Vector3 playerForward)
        {
            _plVector = playerForward * _bulletSpeed;
        }
    }
}