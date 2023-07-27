using Data;
using System;
using UnityEngine;
using Zenject;

namespace Core
{
    public class CharacterSpawner : MonoBehaviour
    {
        private GameConfig _gameConfig;
        private UnitFactory _unitFactory;
        private UnitList _unitList;

        public event Action OnCharacterSpawned;

        [Inject]
        private void Construct(GameConfig gameConfig, UnitFactory unitFactory, UnitList unitList)
        {
            _gameConfig = gameConfig;
            _unitFactory = unitFactory;
            _unitList = unitList;
        }

        private void Awake()
        {
            SpawnCharacter();
        }

        private void SpawnCharacter()
        {
            var character = _unitFactory.CreatePrefab(_gameConfig.Prefabs.CharacterPrefab.gameObject);
            _unitList.SetCharacter(character.transform);

            OnCharacterSpawned?.Invoke();
        }
    }
}