using System.Collections.Generic;
using UnityEngine;

namespace LearnProject.Scripts.UI
{
    [CreateAssetMenu(fileName = "UIPreset", menuName = "UI/UIPreset", order = 0)]
    public class UIPreset : ScriptableObject
    {
        [SerializeField]
        private Canvas _uiRoot;

        [SerializeField]
        private List<ViewPresetData> _views;

        public Canvas UIRoot => _uiRoot;

        public List<ViewPresetData> Views => _views;
    }
}