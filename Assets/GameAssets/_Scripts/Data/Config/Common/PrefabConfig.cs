using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Prefab Config")]
    public class PrefabConfig : ScriptableObject
    {
        [SerializeField] private GameObject _characterPrefab;

        public GameObject CharacterPrefab => _characterPrefab;
    }
}
