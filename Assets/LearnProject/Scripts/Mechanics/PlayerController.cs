using Learning.Scripts.DamageSystem;
using UnityEngine;

namespace Learning.Scripts.Mechanics
{
    [RequireComponent(typeof(MineScript), typeof(ShootScript))]
    public class PlayerController : MonoBehaviour
    {
        private ShootScript _shootScript;
        private MineScript _mineScript;
        private Animator _animator;
        private static readonly int Shot = Animator.StringToHash("shot");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _shootScript = GetComponent<ShootScript>();
            _mineScript = GetComponent<MineScript>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _shootScript.Shot();
                _animator.SetTrigger(Shot);
            }
            if (Input.GetMouseButtonDown(1)) _mineScript.Place();
        }
    }
}
