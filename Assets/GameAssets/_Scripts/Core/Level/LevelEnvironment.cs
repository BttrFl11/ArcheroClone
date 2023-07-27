using Data;
using UnityEditor.AI;
using UnityEngine;
using Zenject;

namespace Core
{
    public class LevelEnvironment : MonoBehaviour
    {
        private GameObject _level;

        [Inject] private UnitFactory _unitFactory;

        public void LoadLevel(LevelData levelData)
        {
            if (_level != null)
                Destroy(_level.gameObject);

            _level = _unitFactory.CreatePrefab(levelData.LevelPrefab);

            NavMeshBuilder.BuildNavMeshAsync();
        }
    }
}
