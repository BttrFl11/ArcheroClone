using Data;
using UnityEngine;
using Zenject;

namespace Core
{
    public class CharacterDataController : MonoBehaviour
    {
        private CharacterConfig _characterConfig;
        private CharacterRuntimeData _characterRuntimeData;

        public CharacterConfig Config => _characterConfig;
        public CharacterRuntimeData RuntimeData => _characterRuntimeData;

        [Inject]
        private void Construct(PlayerConfig playerConfig, PlayerRuntimeData playerRuntime)
        {
            _characterConfig = playerConfig.Character;
            _characterRuntimeData = playerRuntime.Character;

            _characterRuntimeData.MoveSpeed = _characterConfig.MoveSpeed;
            _characterRuntimeData.MaxHealth = _characterConfig.MaxHealth;
            _characterRuntimeData.FireRate = _characterConfig.FireRate;
            _characterRuntimeData.DamagePerShot = _characterConfig.DamagePerShot;
            _characterRuntimeData.ProjectileMoveSpeed = _characterConfig.ProjectileMoveSpeed;
            _characterRuntimeData.ProjectilePrefab = _characterConfig.ProjectilePrefab;
        }
    }
}
