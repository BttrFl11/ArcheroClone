using UnityEngine;
using Zenject;

namespace Core
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private CharacterDataController _characterData;
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private CharacterStateController _characterStateController;
        [SerializeField] private CharacterHealth _characterHealth;

        public override void InstallBindings()
        {
            BindComponents();
        }

        private void BindComponents()
        {
            Container.BindInstance(_characterData).AsSingle();
            Container.BindInstance(_rigidbody).AsSingle();
            Container.BindInstance(_characterMovement).AsSingle();
            Container.BindInstance(_characterStateController).AsSingle();
            Container.Bind<UnitHealth>().To<CharacterHealth>().FromInstance(_characterHealth).AsSingle();
        }
    }
}