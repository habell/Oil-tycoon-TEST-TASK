using UnityEngine;

namespace Learning.Scripts.Mechanics
{
    public class MovingSystem : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed = 1;
        [SerializeField] private float _jumpMax = 100;
        [SerializeField] private Vector3 _direction;
        private float _yDefault;
        private bool _jumpStop;

        void Start()
        {
            _yDefault = _direction.y;
        }
        void Update()
        {
            var x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            if (x != 0)
                transform.Rotate(0, x, 0);

            // логика прыжка
            if (Input.GetKeyUp(KeyCode.Space)) _jumpStop = true;
            if (Input.GetKey(KeyCode.Space) && !_jumpStop)
            {
                gameObject.transform.position += new Vector3(0, Time.deltaTime * _jumpSpeed, 0);
                if (gameObject.transform.position.y >= _jumpMax) _jumpStop = true;
            }
            else
            {
                if (_yDefault < gameObject.transform.position.y)
                {
                    gameObject.transform.position -= new Vector3(0, Time.deltaTime * _jumpSpeed, 0);
                    if (gameObject.transform.position.y <= _yDefault) _jumpStop = false;
                }
            }
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }

        private void FixedUpdate()
        {
            Vector3 moveSpeed = _direction * _speed * Time.fixedDeltaTime;
            transform.Translate(moveSpeed);
        }
    }
}
