using System.Collections.Generic;
using Learning.Scripts.Other;
using LearnProject.Scripts;
using UnityEngine;

namespace Learning.Scripts.DamageSystem
{
    public class ShootScript : MonoBehaviour
    {
        private static readonly int _bulletsBuffer = 30;

        [SerializeField]
        private Bullet _bullet;

        [SerializeField]
        private Transform _bulletSpawnPlace;

        [SerializeField]
        private Vector3 _bulletShotPositionCorrect = new(0, 0, 0);

        [SerializeField]
        private AmmoTypes _ammoType;

        private readonly List<Bullet> _Bullets = new(_bulletsBuffer);

        private void Start()
        {
            var ammoPreset = Game.Instance.AmmoPreset.Ammos;
            foreach (var ammo in ammoPreset)
                if (ammo.AmmoTypes == _ammoType)
                {
                    _bullet = (Bullet)ammo.AbstractAmmo;
                    break;
                }

            if (!_bulletSpawnPlace) _bulletSpawnPlace = transform;
            for (var i = 0; i < _bulletsBuffer; i++)
            {
                var bullet = Instantiate(_bullet, transform);
                bullet.tag = gameObject.tag;
                _Bullets.Add(bullet);
                bullet.gameObject.SetActive(false);
            }

            //Debug.Log($"{_Bullets.Count} Bullets in buffer has created!");
        }

        public void Shot()
        {
            foreach (var bullet in _Bullets)
                if (!bullet.gameObject.activeSelf)
                {
                    InstantNewBullet(bullet);
                    return;
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
            var bulletTransform = bullet.gameObject.transform;
            bulletTransform.position =
                _bulletSpawnPlace.position + _bulletShotPositionCorrect + gameObject.transform.forward;
            bulletTransform.rotation = _bulletSpawnPlace.rotation;
            bullet.ShotBullet();
        }
    }
}