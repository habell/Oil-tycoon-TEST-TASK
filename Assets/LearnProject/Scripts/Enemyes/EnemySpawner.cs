using Learning.Scripts.Mechanics;
using UnityEngine;

namespace Learning.Scripts.Enemyes
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _spawnedObject;
        [SerializeField] private float _defaultTime = 30;
        [SerializeField] private Transform[] _waypoints;

        private float _timerCount;

        private void Start()
        {
            _timerCount = _defaultTime;
        }

        private void FixedUpdate()
        {
            if (_timerCount <= 0)
            {
                _timerCount = _defaultTime;
                var cachedTransform = transform;
                var enemy = Instantiate(_spawnedObject, cachedTransform.position, cachedTransform.rotation);
                enemy.GetComponent<WaypointPatrol>().waypoints = _waypoints;
                EnemyLeftTo.UpdateEnemyCount(false);
                //enemy.WaypointPatrol.waypoints = _waypoints;
                print("Enemy has spawned!");
            }
            else
            {
                _timerCount -= Time.fixedDeltaTime;
            }
        }
    }
}