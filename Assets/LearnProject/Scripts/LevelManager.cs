using System.Collections.Generic;
using LearnProject.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LearnProject.Scripts
{
    public class LevelManager : ILevelManager
    {
        public string CurrentLevel { get; private set; }

        private string[] Scenes =
        {
            "Main",
            "Level_1",
            "Level_2",
            "Level_3",
            "Level_4",
        };

        public void LoadScene(string name)
        {
            if (name == CurrentLevel)
            {
                ReloadScene(name);
                return;
            }

            CurrentLevel = name;
            Debug.Log(CurrentLevel);
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        }

        public void LoadScene(int id)
        {
            if (id < Scenes.Length)
            {
                if(id > 1)
                    UnLoadScene(Scenes[id-1]);
                SceneManager.LoadSceneAsync(Scenes[id], LoadSceneMode.Additive);
                CurrentLevel = Scenes[id];
            }
        }

        public int GetSceneId()
        {
            for (int i = 0; i < Scenes.Length; i++)
            {
                if (CurrentLevel == Scenes[i])
                {
                    return i;
                }
            }
            return 0;
        }
        
        public void ReloadScene(string name)
        {
            SceneManager.UnloadSceneAsync(name, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        }

        public void UnLoadScene(string name)
        {
            SceneManager.UnloadSceneAsync(name, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        }
    }
}