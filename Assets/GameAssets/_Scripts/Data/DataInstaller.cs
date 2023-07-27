using UnityEngine;
using Zenject;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Data Manager")]
    public class DataInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private PlayerRuntimeData _playerRuntimeData;
        [SerializeField] private GameConfig _gameConfig;

        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle().NonLazy();
            Container.Bind<PlayerRuntimeData>().FromInstance(_playerRuntimeData).AsSingle().NonLazy();
            Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle().NonLazy();

            Container.Bind<PlayerDataManager>().AsSingle().NonLazy();
        }
    }
}
