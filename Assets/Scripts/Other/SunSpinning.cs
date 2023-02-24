using System;
using UnityEngine;

namespace Other
{
    public class SunSpinning : MonoBehaviour
    {
        private Transform _sunTransform;

        private float _rotate = 0;
        private void Awake() => _sunTransform = gameObject.transform;

        private void FixedUpdate()
        {
            _rotate += 0.3f;
            if (_rotate > 180)
            {
                _sunTransform.Rotate(180f, 0f, 0f);
                _rotate = 0;
            }
            else
                _sunTransform.Rotate(0.3f, 0f, 0f);
        }
    }
}