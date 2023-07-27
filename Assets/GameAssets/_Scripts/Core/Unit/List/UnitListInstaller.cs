using Zenject;

namespace Core
{
    public class UnitListInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UnitList>().AsSingle().NonLazy();
        }
    }
}
