using System.Collections.Generic;
using Learning.Scripts.Other;
using LearnProject.Scripts.Interfaces;
using LearnProject.Scripts.UI;
using UnityEngine;

namespace LearnProject.Scripts
{
    public class UIService : IUIService
    {
        private readonly Dictionary<UIViev, View> _views;

        public UIService(UIPreset uiPreset)
        {
            _views = new Dictionary<UIViev, View>();

            var uiRoot = Object.Instantiate(uiPreset.UIRoot);

            foreach (var view in uiPreset.Views)
            {
                var prefab = Object.Instantiate(view.Prefab, uiRoot.transform);
                prefab.Hide();
                _views.Add(view.UIViev, prefab);
            }
        }

        public void Show(UIViev viev)
        {
            if (_views.ContainsKey(viev)) _views[viev].Show();
        }

        public void Hide(UIViev viev)
        {
            if (_views.ContainsKey(viev)) _views[viev].Hide();
        }
    }
}