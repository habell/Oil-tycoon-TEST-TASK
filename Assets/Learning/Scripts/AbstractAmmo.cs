using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class AbstractAmmo : MonoBehaviour
{
    private const int DefaultDamage = 100;
    
    [SerializeField] private int _damage;
    
    protected bool DestroyableOnCollision;

    private void Awake()
    {
        var trigger = GetComponent<Collider>();
        trigger.isTrigger = true;
    }

    private void Start()
    {
        if (_damage == 0) _damage = DefaultDamage;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            var enemy = coll.GetComponent<Enemy>();
            enemy.Hurt(_damage);
            DestroyAmmo();
        }

        if (!coll.gameObject.CompareTag("Player")) DestroyAmmo();
    }

    protected abstract void DestroyAmmo();
}