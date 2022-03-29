using UnityEngine;

namespace Learning.Scripts.Other
{
    public class Door : MonoBehaviour
    {
        private float _defYpos;
        [SerializeField]
        private bool _doorStatus;
        public Button button1;
        public Button button2;
        private AudioSource AS;
        private AudioClip clip;

    
        void Start()
        {
            _defYpos = transform.position.y;
            AS = GetComponent<AudioSource>();
        }
        public void OpenDoor()
        {
            if (button1.ButtonStatus && button2.ButtonStatus) _doorStatus = !_doorStatus;
            AS.clip = clip;
            AS.Play();
        }

        private void FixedUpdate()
        {
            if(!_doorStatus && _defYpos < 0)
            {
                _defYpos += Time.deltaTime;
                transform.position = new Vector3(transform.position.x, _defYpos, transform.position.z);
            }
            if (_doorStatus && _defYpos > -1)
            {
                _defYpos -= Time.deltaTime;
                transform.position = new Vector3(transform.position.x, _defYpos, transform.position.z);
            }
        }
    }
}
