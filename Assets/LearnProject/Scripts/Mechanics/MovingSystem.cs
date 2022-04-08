using System.Collections;
using System.Timers;
using UnityEngine;

namespace Learning.Scripts.Mechanics
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovingSystem : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed = 1;
        [SerializeField] private float _jumpMax = 3;
        [SerializeField] private Vector3 _direction;
        private bool _jumpStop;
        private bool _run;
        private bool _walk;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private static readonly int Vertical = Animator.StringToHash("vertical");
        private static readonly int Run = Animator.StringToHash("run");
        private static readonly int Walk = Animator.StringToHash("walk");

        public void SetSpeed(float speed, float time = 0)
        {
            StartCoroutine(SpeedBoster(speed, time));
        }
        IEnumerator SpeedBoster(float speed, float boostTime)
        {
            var oldSpeed = _speed;
            _speed = speed;
            if (boostTime == 0) yield return null;
            yield return new WaitForSeconds(boostTime);
            _speed = oldSpeed;
            yield return null;
        }
        

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.freezeRotation = true;
        }
        private void Update()
        {

            var x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            if (_direction.z != 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    _run = true;
                    _walk = false;
                }
                else
                {
                    _run = false;
                    _walk = true;
                }
            }
            else
            {
                _run = false;
                _walk = false;
            }
            if (x != 0)
                transform.Rotate(0, x, 0);
            
            if (Input.GetKeyUp(KeyCode.Space)) _jumpStop = true;
            if (Input.GetKey(KeyCode.Space) && !_jumpStop)
            {
                _rigidbody.AddForce(Vector3.up * _jumpSpeed);
                if (_rigidbody.velocity.y > _jumpMax) 
                    _jumpStop = true;
            }
            else
            {
                if (_jumpStop && _rigidbody.velocity.y == 0)
                    _jumpStop = false;
            }
        }

        private void FixedUpdate()
        {
            _animator.SetFloat(Vertical, _direction.z);
            _animator.SetBool(Run, _run);
            _animator.SetBool(Walk, _walk);
            Vector3 moveSpeed;
            if(_run)
                moveSpeed = _direction * _speed * Time.fixedDeltaTime;
            else
                moveSpeed = _direction * (_speed/2) * Time.fixedDeltaTime;
            transform.Translate(moveSpeed);
        }
    }
}
