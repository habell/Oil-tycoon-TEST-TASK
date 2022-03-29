using UnityEngine;

namespace Learning.Scripts.DamageSystem
{
    public class Bullet : AbstractAmmo
    {
        [SerializeField] private float _bulletLifeTime = 1;

        [SerializeField] private float _bulletSpeed = 2;

        [SerializeField] private Vector3 _plVector;

        private void Start()
        {
            destroyableOnCollision = true;
            _bulletSpeed = 10 / _bulletSpeed;
        }

        protected override void CollisionAmmo(Health objHealth)
        {
            // TODO: need to make explosive effects for homework
            objHealth.Hurt(_damage);
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            _bulletLifeTime -= Time.fixedDeltaTime;
            if (_bulletLifeTime <= 0) Destroy(gameObject);
            gameObject.transform.position += _plVector / _bulletSpeed;
        }

        public void BulletSetForward(Vector3 playerForward)
        {
            _plVector = playerForward * _bulletSpeed;
        }
    }
}