using LearnProject.Scripts;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EndLevel : MonoBehaviour
{
    [SerializeField]
    private string _playerTag = "PlayerPrefab";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            gameObject.SetActive(false);
            Debug.Log("Game or level is ended!");
            Game game = Game.Instance;
            game.LevelManager.LoadScene(game.LevelManager.GetSceneId() + 1);
        }
    }
}