using Core;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller, ICoroutineHandler
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineHandler>().FromInstance(this).AsSingle().NonLazy();
            Container.Bind<TimeManager>().AsSingle().NonLazy();
        }
    }
}
