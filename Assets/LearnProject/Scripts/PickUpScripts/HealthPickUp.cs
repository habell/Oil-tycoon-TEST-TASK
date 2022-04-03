using Learning.Scripts.DamageSystem;
using Learning.Scripts.Other;
using UnityEngine;

public class HealthPickUp : PickupItem
{
    [SerializeField] private int _healthAmmount = 10;
    protected override void PickUp(GameObject owner)
    {
        if (owner.TryGetComponent(out Health health))
        {
            health.Heal(_healthAmmount);
        }
        else
        {
            Debug.LogError("this entity doesnt have Health component! Please refactoring this problem!");
            return;
        }
        gameObject.SetActive(false);
    }
}
