using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletSpawnPlace;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InstantNewBullet();
        }
    }

    void InstantNewBullet()
    {
        var bullet = Instantiate(_bullet, _bulletSpawnPlace.position + new Vector3(0, 1, 0), _bulletSpawnPlace.rotation);
        bullet.BulletSetForward(gameObject.transform.forward);
    }
}
