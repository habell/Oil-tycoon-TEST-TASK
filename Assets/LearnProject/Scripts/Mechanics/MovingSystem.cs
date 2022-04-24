using System.Collections;
using LearnProject.Scripts.Interfaces;
using UnityEngine;

namespace Learning.Scripts.Mechanics
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovingSystem : MonoBehaviour, IMove
    {
        private static readonly int Vertical = Animator.StringToHash("vertical");
        private static readonly int Run = Animator.StringToHash("run");
        private static readonly int Walk = Animator.StringToHash("walk");

        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _jumpSpeed = 1;

        [SerializeField]
        private float _jumpMax = 3;

        [SerializeField]
        private Vector3 _direction;

        private Animator _animator;

        private bool _jumpStop;

        private Rigidbody _rigidbody;
        private bool _run;

        private Coroutine _speedCoroutine;
        private bool _walk;

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
            if (_run)
                moveSpeed = _direction * _speed * Time.fixedDeltaTime;
            else
                moveSpeed = _direction * (_speed / 2) * Time.fixedDeltaTime;
            transform.Translate(moveSpeed);
        }

        public void SetSpeed(float speed, float time = 0)
        {
            if (_speedCoroutine != null) StopCoroutine(_speedCoroutine);
            _speedCoroutine = StartCoroutine(SpeedBooster(speed, time));
        }

        private IEnumerator SpeedBooster(float speed, float time)
        {
            if (time <= 0f)
            {
                _speed = speed;
            }
            else
            {
                var oldSpeed = _speed;
                _speed = speed;
                yield return new WaitForSeconds(time);
                _speed = oldSpeed;
            }
        }
    }
}