using Learning.Scripts.Mechanics;
using Learning.Scripts.Other;
using UnityEngine;

public class MoveBoosterPickUp : PickupItem
{
    [SerializeField]
    private bool _addOrOverride; // TODO: Need to make this variable

    [SerializeField]
    private float _newMoveSpeed;

    [SerializeField]
    private float _boostTime;

    protected override void PickUp(GameObject owner)
    {
        if (owner.TryGetComponent(out MovingSystem movingSystem))
        {
            movingSystem.SetSpeed(_newMoveSpeed, _boostTime);
        }
        else
        {
            Debug.LogError("this entity doesnt have InventorySystem component! Please refactoring this problem!");
            return;
        }

        gameObject.SetActive(false);
    }
}