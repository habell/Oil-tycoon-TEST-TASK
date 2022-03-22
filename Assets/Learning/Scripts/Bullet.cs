using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AbstractAmmo
{
    [SerializeField] private float _bulletLifeTime = 1;
    [SerializeField] private float _bulletSpeed = 10;
    [SerializeField] private Vector3 _plVector;

    void Start()
    {
        _destroyableOnCollision = true;
        _bulletSpeed = 10 / _bulletSpeed;
    }
    override public void DestroyAmmo()
    {
        // TODO: need to make explosive effects for homework
        Destroy(gameObject);
    }

    public void BulletSetForward(Vector3 playerForward)
    {
        _plVector = playerForward;
    }

    void FixedUpdate()
    {
        _bulletLifeTime -= Time.fixedDeltaTime;
        if (_bulletLifeTime <= 0) Destroy(gameObject);
        gameObject.transform.position += _plVector / _bulletSpeed;
    }
}
