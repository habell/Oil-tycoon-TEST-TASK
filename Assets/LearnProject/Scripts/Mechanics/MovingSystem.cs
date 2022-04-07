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
        private Rigidbody _rigidbody;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.freezeRotation = true;
        }
        void Update()
        {
            var x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
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
            Vector3 moveSpeed = _direction * _speed * Time.fixedDeltaTime;
            transform.Translate(moveSpeed);
        }
    }
}
