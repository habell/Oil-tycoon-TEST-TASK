using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.AssetManagment
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(GameObject guiParent, string path);
    }
}