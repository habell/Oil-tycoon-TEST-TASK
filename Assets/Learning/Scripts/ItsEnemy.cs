using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItsEnemy : MonoBehaviour
{
    [SerializeField]
    public Text EnemyDeaths;
    [SerializeField]
    private int health;

    public void Start()
    {
        EnemyDeaths = GameObject.Find("EnemyDeath").GetComponent<Text>();
    }
    public int Health {
        get { return health; }
        set
        {
            print("health: "+health);
            print("value: "+value);
            health += value;
            if (health <= 0) Die();
        }
    }



    /// <summary>
    /// Use Hurt(damage)
    /// </summary>
    /// <param name="damage"></param>
    public void Hurt(int damage)
    {
        print($"Oh no, i don't wanna die! I'm taking {damage} damage in my face((");
        Health = -damage;
    }
    void Die()
    {
        EnemyDeaths.text = (int.Parse(EnemyDeaths.text) + 1).ToString();
        Destroy(gameObject);
    }
}
