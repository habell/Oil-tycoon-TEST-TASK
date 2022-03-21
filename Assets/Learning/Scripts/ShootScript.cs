using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private GameObject _mine;
    [SerializeField] private Transform _mineSpawnPlace;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(_mine, _mineSpawnPlace.position + new Vector3(0, 1, 0), _mineSpawnPlace.rotation);
            bullet.GetComponent<Bullet>()._plVector = gameObject.transform.forward;
        }
    }
}
