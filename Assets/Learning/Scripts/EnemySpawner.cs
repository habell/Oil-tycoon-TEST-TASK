using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnedObject;
    [SerializeField] private float DefaultTime = 30;
    public Transform[] waypoints;
    private float timerCount; 
    // Start is called before the first frame update
    void Start()
    {
        timerCount = DefaultTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerCount <= 0)
        {
            timerCount = DefaultTime;
            GameObject enemy = Instantiate(_spawnedObject, gameObject.transform.position, gameObject.transform.rotation);
            enemy.GetComponent<WaypointPatrol>().waypoints = waypoints;
            print("Enemy has spawned!");
        }
        else
            timerCount -= Time.fixedDeltaTime;
    }
}
