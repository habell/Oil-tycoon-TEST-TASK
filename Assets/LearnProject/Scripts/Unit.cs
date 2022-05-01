using LearnProject.Scripts.Interfaces;
using UnityEngine;

namespace LearnProject.Scripts
{
    public abstract class Unit : MonoBehaviour, IUnit
    {
        public IWeapon Weapon;

        public void Attack()
        {
            Weapon.PerfomShot();
        }
    }
}