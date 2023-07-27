using UI;
using UnityEngine;
using Zenject;

namespace Core
{
    public class JoystickInstaller : MonoInstaller
    {
        [SerializeField] private CharacterMoveJoystick _moveJoystick;

        public override void InstallBindings()
        {
            Container.Bind<CharacterMoveJoystick>().FromInstance(_moveJoystick).AsSingle().NonLazy();
        }
    }
}
