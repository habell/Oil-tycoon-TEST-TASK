using UnityEngine;

namespace Learning.Scripts.DamageSystem
{
    public class MineScript : MonoBehaviour
    {
        [SerializeField] private Mine _mine;
        [SerializeField] private Transform _mineSpawnPlace;
        
        public void Place() // I would like to use a delegate here, but I don't know enough about them yet
        {
            if (!_mine)
            {
                Debug.LogError("Not have _mine object! Mine type! MineScript.cs, please fix it!");
                _mine = (Mine)FindObjectOfType(typeof(Mine)); // it is not good! Please, fix it if you have this error
                return;
            }
            if (!_mineSpawnPlace) _mineSpawnPlace = transform; 
            InstantiateMine();
        }

        private void InstantiateMine()
        {
            var mine = Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
            mine.tag = tag;
        }
    }
}
