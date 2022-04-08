using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _startPosition;
    private void Awake()
    {
        Instantiate(_player, _startPosition.position, _startPosition.rotation);
        Debug.Log("Player spawned!");
    }
}
