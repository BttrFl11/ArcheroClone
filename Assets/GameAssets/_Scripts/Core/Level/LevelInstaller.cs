using UnityEngine;
using Zenject;

namespace Core
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelEnvironment _levelEnvironment;
        [SerializeField] private CharacterSpawner _characterSpawner;

        public override void InstallBindings()
        {
            Container.Bind<CharacterSpawner>().FromInstance(_characterSpawner).AsSingle();
            Container.Bind<LevelEnvironment>().FromInstance(_levelEnvironment).AsSingle();

            Container.Bind<EnemyCounter>().AsSingle().NonLazy();
            Container.Bind<LevelManager>().AsSingle().NonLazy();
            Container.Bind<BattleTimer>().AsSingle().NonLazy();
        }
    }
}
