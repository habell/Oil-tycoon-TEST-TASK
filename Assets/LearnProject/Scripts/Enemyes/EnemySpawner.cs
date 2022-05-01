using System;
using System.Collections.Generic;
using Learning.Scripts.Enemyes;
using Learning.Scripts.Mechanics;
using LearnProject.Scripts.UI;
using UnityEngine;

namespace LearnProject.Scripts.Enemyes
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private Enemy _spawnedObject;

        [SerializeField]
        private float _defaultTime = 30;

        [SerializeField]
        private Transform[] _waypoints;

        private float _timerCount;
        
        public static Action<int> EnemiesChanged;
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
                enemy.GetComponent<WaypointPatrol>().SetWaypoints(_waypoints);
                print("Enemy has spawned!");
                EnemiesChanged?.Invoke(1);
            }
            else
            {
                _timerCount -= Time.fixedDeltaTime;
            }
        }
    }
}