using UnityEngine;
using Zenject;

namespace Core
{
    public class UnitFactory
    {
        private DiContainer _diContainer;

        public UnitFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public GameObject CreatePrefab(GameObject prefab)
        {
            return _diContainer.InstantiatePrefab(prefab);
        }
    }
}