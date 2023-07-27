namespace Core
{
    public interface ISceneLoader
    {
        void Load(int sceneIndex);
        void LoadNext();
        void LoadPrevious();
    }
}
