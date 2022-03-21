using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    [SerializeField] private GameObject _mine;
    [SerializeField] private Transform _mineSpawnPlace;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
    }
}
