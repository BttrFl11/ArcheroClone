using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class UnitList
    {
        private Transform _character;
        private List<Enemy> _enemeis = new List<Enemy>();

        public event Action<int> OnEnemyCountChanged;

        public Transform Character => _character;
        public IReadOnlyList<Enemy> Enemies => _enemeis;

        public void SetCharacter(Transform character)
        {
            if (_character != null)
                Debug.LogError($"The scene {SceneManager.GetActiveScene().name} contains several Characters!");

            _character = character;
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemeis.Add(enemy);

            OnEnemyCountChanged?.Invoke(_enemeis.Count);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            _enemeis.Remove(enemy);

            OnEnemyCountChanged?.Invoke(_enemeis.Count);
        }
    }
}
