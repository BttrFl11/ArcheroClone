using Core;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName ="SO/Level Data")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private GameObject _levelPrefab;

        public GameObject LevelPrefab => _levelPrefab;
    }
}
