using LearnProject.Scripts;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private GameObject _player;

    private void Awake()
    {
        _player = Game.Instance.PlayerPrefab;
        _player = Instantiate(_player, transform.position, transform.rotation);
        Game.Instance.PlayerSpawned(_player);
        Debug.Log("PlayerPrefab spawned!");
    }
}