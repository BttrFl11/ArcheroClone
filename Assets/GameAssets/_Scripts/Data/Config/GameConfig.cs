using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private PrefabConfig _prefabConfig;
        [SerializeField] private LevelsConfig _levelsConfig;

        public PrefabConfig Prefabs => _prefabConfig;
        public LevelsConfig LevelsConfig => _levelsConfig;
    }
}
