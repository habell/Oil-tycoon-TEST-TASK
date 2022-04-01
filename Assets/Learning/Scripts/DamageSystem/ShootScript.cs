using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Learning.Scripts.DamageSystem
{
    public class ShootScript : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _bulletSpawnPlace;
        [SerializeField] private Vector3 _bulletShotPositionCorrect = new Vector3(0, 0, 0);
        private static int _bulletsBuffer = 30;

        private List<Bullet> _Bullets = new List<Bullet>(_bulletsBuffer);

        private void Start()
        {
            if (!_bullet)
            {
                Debug.LogError("Not have _bullet object! Bullet type! ShootScript.cs please fix it!");
                _bullet = (Bullet)FindObjectOfType(typeof(Bullet)); // it is not good! Please, fix it if you have this error
                //return;
            }
            if (!_bulletSpawnPlace) _bulletSpawnPlace = transform; 
            for (int i = 0; i < _bulletsBuffer; i++)
            {
                var bullet = Instantiate(_bullet, transform);
                bullet.tag = gameObject.tag;
                _Bullets.Add(bullet);
                bullet.gameObject.SetActive(false);
            }
            Debug.Log($"{_bulletsBuffer} Bullets in buffer has created!");
        }

        public void Shot()
        {
            foreach (var bullet in _Bullets)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    InstantNewBullet(bullet);
                    return;
                }
            }
            Debug.LogError("You need to upgrade bullets buffer!");
            var fixBullet = Instantiate(_bullet, transform);
            InstantNewBullet(fixBullet);
            fixBullet.tag = gameObject.tag;
        }
        
        private void InstantNewBullet(Bullet bullet)
        {
            //var bullet = Instantiate(_bullet, _bulletSpawnPlace.position + _bulletShotPositionCorrect + gameObject.transform.forward,
            //    _bulletSpawnPlace.rotation);
            //bullet.tag = gameObject.tag;
            Transform bulletTransform = bullet.gameObject.transform;
            bulletTransform.position = Vector3.zero;
            bulletTransform.position = _bulletSpawnPlace.position + _bulletShotPositionCorrect + gameObject.transform.forward;
            bulletTransform.rotation = _bulletSpawnPlace.rotation;
            bullet.BulletSetForward(transform.forward);
            bullet.ShotBullet();
        }
    }
}