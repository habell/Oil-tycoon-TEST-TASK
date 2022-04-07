using UnityEngine;
using UnityEngine.Serialization;

namespace Learning.Scripts.Other
{
    public class Button : MonoBehaviour
    {
        public Door Door;
        [FormerlySerializedAs("btnStatus")] public bool ButtonStatus;
        private float _timer = 5;
        private float _oldXpos;

        private void Start()
        {
            _oldXpos = transform.position.x;
        }
        //private void OnTriggerEnter(Collider other)
        //{
        //    ButtonStatus = true;
        //    Door.OpenDoor();
        //}

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Door.tag))
            {
                ButtonStatus = true;
                Door.OpenDoor();
            }
        }

        private void FixedUpdate()
        {
            if(ButtonStatus)
            {
                if (_timer <= 0)
                {
                    transform.position = new Vector3(_oldXpos, transform.position.y, transform.position.z);
                    _timer = 5;
                    ButtonStatus = false;
                }
                else
                {
                    _timer -= Time.fixedDeltaTime;
                    transform.position = new Vector3(transform.position.x + Time.fixedDeltaTime/10, transform.position.y, transform.position.z);
                }

            }
        }
    }
}
