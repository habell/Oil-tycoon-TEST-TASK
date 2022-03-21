using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AbstractAmmo
{
    [SerializeField] private float _bulletLifeTime = 1;
    [SerializeField] private float _bulletSpeed = 10;
    [SerializeField] internal Vector3 _plVector;

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

    void FixedUpdate()
    {
        _bulletLifeTime -= Time.deltaTime;
        if (_bulletLifeTime <= 0) Destroy(gameObject);
        gameObject.transform.position += _plVector / _bulletSpeed;
    }
}
