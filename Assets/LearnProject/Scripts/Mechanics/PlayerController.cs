using Learning.Scripts.DamageSystem;
using UnityEngine;

namespace Learning.Scripts.Mechanics
{
    [RequireComponent(typeof(ShootScript))]
    [RequireComponent(typeof(MineScript))]
    public class PlayerController : MonoBehaviour
    {
        private ShootScript _shootScript;
        private MineScript _mineScript;
        private void Awake()
        {
            _shootScript = GetComponent<ShootScript>();
            _mineScript = GetComponent<MineScript>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) _shootScript.Shot();
            if (Input.GetMouseButtonDown(1)) _mineScript.Place();
        }
    }
}
