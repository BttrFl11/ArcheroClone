using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Player Runtime Data")]
    public class PlayerRuntimeData : ScriptableObject
    {
        [SerializeField] private CharacterRuntimeData _character;

        private int _money;
        public event Action<int> OnMoneyChanged;

        public CharacterRuntimeData Character => _character;
        public int Money
        {
            get => _money;
            set
            {
                _money = value;
                
                OnMoneyChanged?.Invoke(_money);
            }
        }

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
            _money = 0;
        }
    }
}
