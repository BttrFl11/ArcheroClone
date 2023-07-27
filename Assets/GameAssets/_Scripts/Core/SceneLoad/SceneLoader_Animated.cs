using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader_Animated : ISceneLoader
    {
        private LoadingScreen _loadingScreen;
        private ICoroutineHandler _coroutineHandler;

        private const float FINISH_PROGRESS = 0.9f;

        public SceneLoader_Animated(LoadingScreen loadingScreen, ICoroutineHandler coroutineRunner)
        {
            _loadingScreen = loadingScreen;
            _coroutineHandler = coroutineRunner;
        }

        private IEnumerator StartLoading(int sceneId)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

            _loadingScreen.Show();
            operation.allowSceneActivation = false;

            float waitTime = 0;

            while (operation.isDone == false)
            {
                _loadingScreen.SetProgressBarFillAmount(operation.progress);

                waitTime += Time.deltaTime;

                if (operation.progress >= FINISH_PROGRESS)
                {
                    break;
                }

                yield return null;
            }

            _loadingScreen.SetProgressBarFillAmount(1);

            operation.allowSceneActivation = true;
        }

        public void Load(int sceneId)
        {
            _coroutineHandler.StartCoroutine(StartLoading(sceneId));
        }

        public void LoadPrevious()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                return;

            _coroutineHandler.StartCoroutine(StartLoading(SceneManager.GetActiveScene().buildIndex - 1));
        }

        public void LoadNext()
        {
            _coroutineHandler.StartCoroutine(StartLoading(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
}