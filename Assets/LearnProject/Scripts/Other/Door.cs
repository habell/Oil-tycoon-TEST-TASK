using UnityEngine;

namespace Learning.Scripts.Other
{
    [RequireComponent(typeof(AudioSource))]
    public class Door : MonoBehaviour
    {
        [SerializeField]
        private bool _doorStatus;

        public Button button1;
        public Button button2;
        private AudioSource _audioSource;
        private AudioClip _clip;
        private float _defYpos;


        private void Start()
        {
            _defYpos = transform.position.y;
            _audioSource = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            if (!_doorStatus && _defYpos < 0)
            {
                _defYpos += Time.fixedDeltaTime * 2;
                transform.position = new Vector3(transform.position.x, _defYpos, transform.position.z);
            }

            if (_doorStatus && _defYpos > -1f)
            {
                _defYpos -= Time.fixedDeltaTime * 2;
                transform.position = new Vector3(transform.position.x, _defYpos, transform.position.z);
            }
        }

        public void OpenDoor()
        {
            if (button1.ButtonStatus && button2.ButtonStatus) _doorStatus = !_doorStatus;
            _audioSource.clip = _clip;
            _audioSource.Play();
        }
    }
}