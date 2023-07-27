using UnityEngine;
using Zenject;

namespace Core
{
    public class LoadSceneInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreen _loadingScreen;

        public override void InstallBindings()
        {
            Container.Bind<LoadingScreen>().FromInstance(_loadingScreen).AsSingle().NonLazy();
            Container.Bind<ISceneLoader>().To<SceneLoader_Animated>().AsSingle().NonLazy();
        }
    }
}
