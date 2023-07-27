using System;
using Zenject;

namespace Core
{
    public class EnemyCounter : IDisposable
    {
        private UnitList _unitList;
        private int _count;

        public int Count => _count;

        public event Action OnAllEnemiesDied;

        public EnemyCounter(UnitList unitList)
        {
            _unitList = unitList;

            _unitList.OnEnemyCountChanged += OnEnemyCountChanged;
        }

        public void Dispose()
        {
            _unitList.OnEnemyCountChanged -= OnEnemyCountChanged;
        }

        private void OnEnemyCountChanged(int count)
        {
            _count = count;

            if(count <= 0)
            {
                OnAllEnemiesDied?.Invoke();
            }
        }
    }
}
