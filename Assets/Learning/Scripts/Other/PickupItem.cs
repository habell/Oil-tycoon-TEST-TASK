using Learning.Scripts.DamageSystem;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Learning.Scripts.Other
{
    public class PickupItem : MonoBehaviour
    {
        [SerializeField] private string _type;
        [SerializeField] private int _amount;
        [SerializeField] private string[] _CollisionTags;

        private void OnTriggerEnter(Collider other)
        {
            if (_CollisionTags.Length > 0)
            {
                foreach (var _tag in _CollisionTags)
                {
                    if (other.CompareTag(_tag))
                    {
                        PickUp(_type, other.gameObject);
                        break;
                    }
                }
            }
        }

        private void PickUp(string type, GameObject owner)
        {
            type = type.ToLower();
            switch (type)
            {
                case "health":
                    if (owner.TryGetComponent(out Health health))
                    {
                        health.Heal(_amount);
                    }
                    else
                    {
                        Debug.LogError("this entity doesnt have Health component! Please refactoring this problem!");
                    }
                    break;
                case "armor":
                    break;
                default:
                    print("Undefind type");
                    break;
            }
        
            gameObject.SetActive(false);
        }
    }
}
