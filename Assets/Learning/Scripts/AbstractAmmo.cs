using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAmmo : MonoBehaviour
{
    [SerializeField] private int _damage;
    private int defaultDamage = 100;
    protected private bool _destroyableOnCollision = false;

    public abstract void DestroyAmmo(); 

    void Start()
    {
        if (_damage == 0) _damage = defaultDamage;
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            var enemy = coll.GetComponent<ItsEnemy>();
            enemy.Hurt(_damage);
            DestroyAmmo();
        }
        if (!coll.gameObject.CompareTag("Player")) DestroyAmmo();
    }
}
