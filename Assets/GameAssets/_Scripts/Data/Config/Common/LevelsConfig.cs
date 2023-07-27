using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Levels Config")]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private List<LevelData> _levels;

        public IReadOnlyList<LevelData> Levels => _levels;
    }
}
