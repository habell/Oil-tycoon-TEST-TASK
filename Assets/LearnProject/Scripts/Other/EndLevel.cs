using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EndLevel : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            Debug.Log("Game or level is ended!");
            // TODO: Need to make next level load logic here
        }
    }
}
