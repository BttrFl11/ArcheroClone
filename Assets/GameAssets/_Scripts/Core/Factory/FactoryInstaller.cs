using Zenject;

namespace Core
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UnitFactory>().AsSingle();
        }
    }
}
