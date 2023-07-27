using Zenject;

namespace Core
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindService();
            Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle().NonLazy();
        }

        private void BindService()
        {
            if (GameConst.IS_MOBILE)
#pragma warning disable CS0162
                Container.Bind<IInputService>().To<InputService_Mobile>().AsSingle().NonLazy();
#pragma warning restore CS0162
            else
                Container.Bind<IInputService>().To<InputService_PC>().AsSingle().NonLazy();
        }
    }
}
