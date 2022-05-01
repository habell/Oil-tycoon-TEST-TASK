using UnityEngine;
using UnityEngine.Serialization;

namespace Learning.Scripts.DamageSystem
{
    public class MineFactory : MonoBehaviour
    {
        [FormerlySerializedAs("_mine")]
        [SerializeField]
        private Mine _minePrefab;

        public void Place()
        {
            InstantiateMine();
        }

        private void InstantiateMine()
        {
            var minePosition = transform;
            var mine = Instantiate(_minePrefab, minePosition.position, minePosition.rotation);
            mine.tag = tag;
        }
    }
}