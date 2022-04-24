using UnityEngine;

namespace Learning.Scripts.DamageSystem
{
    [RequireComponent(typeof(Collider))]
    public abstract class AbstractAmmo : MonoBehaviour
    {
        private const int DefaultDamage = 100;

        [SerializeField]
        protected int _damage;

        private Collider _selfCollider;

        protected bool destroyableOnCollision;

        private void Start()
        {
            if (_damage == 0) _damage = DefaultDamage;
            _selfCollider = GetComponent<Collider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(tag))
                //Physics.IgnoreCollision(collision.collider, _selfCollider);
                return;
            if (collision.gameObject.TryGetComponent(out Health objHealth)) CollisionAmmo(objHealth);
            else CollisionAmmo(null);
        }

        protected abstract void CollisionAmmo(Health objHealth);
    }
}