using UnityEngine;

namespace LearnProject.Scripts
{
    public class AudioVusialiser : MonoBehaviour
    {
        public Transform[] VisualiserObjectArray;

        public AudioSource _source;
        void Start()
        {
            VisualiserObjectArray = GetComponentsInChildren<Transform>();
        }
        
        void Update()
        {
            var spec = _source.GetSpectrumData(64, 0, FFTWindow.Rectangular);
            //print($"spec1 : [{spec[1]}] spec2 : [{spec[2]}] spec3 : [{spec[3]}]");
            foreach (var obj in VisualiserObjectArray)
            {
                obj.transform.localScale = new Vector3(spec[1]+1, spec[2]+1, spec[3]+1);
            }
        }
    }
}