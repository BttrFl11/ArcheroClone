using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private CharacterConfig _character;

        public CharacterConfig Character => _character;
    }
}