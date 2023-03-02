using UnityEngine;

namespace Infrastructure.AssetManagment
{
    public class AssetProvider : IAssets
    {
        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(GameObject guiParent, string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, guiParent.transform);
        }
    }
}