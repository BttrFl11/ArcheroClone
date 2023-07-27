using System;
using UnityEngine;
using Zenject;

namespace Core
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyDataController _dataController;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private EnemyHealth _enemyHealth;

        public override void InstallBindings()
        {
            BindComponents();
        }

        private void BindComponents()
        {
            Container.BindInstance(_dataController).AsSingle();
            Container.BindInstance(_enemy).AsSingle();
            Container.Bind<UnitHealth>().To<EnemyHealth>().FromInstance(_enemyHealth).AsSingle();
        }
    }
}
