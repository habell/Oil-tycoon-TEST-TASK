using Learning.Scripts.DamageSystem;
using UnityEngine;

namespace Learning.Scripts.Mechanics
{
    [RequireComponent(typeof(ShootScript))]
    public class PlayerController : MonoBehaviour
    {
        private ShootScript _shootScript;
        private MineScript _mineScript;
        private void Awake()
        {
            _shootScript = (ShootScript)gameObject.GetComponent(typeof(ShootScript));
            _mineScript = (MineScript)gameObject.GetComponent(typeof(MineScript));
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) _shootScript.Shot();
            if (Input.GetMouseButtonDown(1)) _mineScript.Place();
        }
    }
}
