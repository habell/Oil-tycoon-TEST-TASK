namespace LearnProject.Scripts.Interfaces
{
    public interface ILevelManager
    {
        string CurrentLevel { get; }
        void LoadScene(string name);
        void LoadScene(int id);
        int GetSceneId();
        void ReloadScene(string name);
        void UnLoadScene(string name);
    }
}