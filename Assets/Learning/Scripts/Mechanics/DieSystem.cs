using UnityEngine;
using UnityEngine.UI;

namespace Learning.Scripts.Mechanics
{
    public class DieSystem : MonoBehaviour
    {
        [SerializeField] private Text _enemyCounter;

        private void Start()
        {
            _enemyCounter = (Text)GameObject.FindGameObjectWithTag("EnemyCounter").GetComponent(typeof(Text));
        }

        protected void Die(string type)
        {
            switch (type)
            {
                case "Enemy":
                    if(_enemyCounter != null) _enemyCounter.text = (int.Parse(_enemyCounter.text) + 1).ToString(); 
                    DefaultDie();
                    break;
                default:
                    DefaultDie();
                    break;
            }
        }

        private void DefaultDie()
        {
            Destroy(gameObject);
        }
    }
}
