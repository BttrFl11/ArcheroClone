using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Player Runtime Data")]
    public class PlayerRuntimeData : ScriptableObject
    {
        [SerializeField] private CharacterRuntimeData _character;
        [SerializeField] private Wallet _wallet;

        public CharacterRuntimeData Character => _character;
        public Wallet Wallet => _wallet;

        private void OnEnable()
        {
            Clear();
        }

        private void OnDisable()
        {
            Clear();
        }

        private void Clear()
        {
            _wallet.Clear();
        }
    }
}
