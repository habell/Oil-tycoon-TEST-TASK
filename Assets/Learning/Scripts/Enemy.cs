using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private WaypointPatrol _waypointPatrol;
    
    [SerializeField] private Text _enemyDeathsText;

    [SerializeField] private int _maxHealth;

    private int _health;

    public int Health
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
            if (_health <= 0) Die();
        }
    }

    public WaypointPatrol WaypointPatrol => _waypointPatrol;

    private void Awake()
    {
        _health = _maxHealth;
    }

    /// <summary>
    ///     Use Hurt(damage)
    /// </summary>
    /// <param name="damage"></param>
    public void Hurt(int damage)
    {
        print($"Oh no, i don't wanna die! I'm taking {damage} damage in my face((");
        Health -= damage;
    }

    private void Die()
    {
        _enemyDeathsText.text = (int.Parse(_enemyDeathsText.text) + 1).ToString();
        Destroy(gameObject);
    }
}