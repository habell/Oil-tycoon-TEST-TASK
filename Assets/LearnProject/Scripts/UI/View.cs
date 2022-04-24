using UnityEngine;

namespace LearnProject.Scripts
{
    [RequireComponent(typeof(Canvas))]
    public abstract class View : MonoBehaviour
    {
        public abstract void Show();
        public abstract void Hide();
    }
}