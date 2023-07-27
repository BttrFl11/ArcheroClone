using Core;
using UnityEngine;
using Zenject;

namespace UI 
{
    public class LoadSceneAction : MonoBehaviour
    {
        [Inject] private ISceneLoader _sceneLoader;

        public void LoadMainMenu()
        {
            _sceneLoader.Load(GameConst.MAIN_MENU_ID);
        }

        public void LoadNext()
        {
            _sceneLoader.LoadNext();
        }

        public void LoadPrevious()
        {
            _sceneLoader.LoadPrevious();
        }

        public void LoadScene(int id)
        {
            _sceneLoader.Load(id);
        }
    }
}