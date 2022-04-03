using UnityEngine;

namespace Learning.Scripts.Other
{
    public abstract class PickupItem : MonoBehaviour
    {
        [SerializeField] protected string[] _collisionTags;
        protected abstract void PickUp(GameObject owner);

        private void OnTriggerEnter(Collider other)
        {
            if (_collisionTags.Length > 0)
            {
                foreach (var _tag in _collisionTags)
                {
                    if (other.CompareTag(_tag))
                    {
                        PickUp(other.gameObject);
                        break;
                    }
                }
            }
        }
    }
}
