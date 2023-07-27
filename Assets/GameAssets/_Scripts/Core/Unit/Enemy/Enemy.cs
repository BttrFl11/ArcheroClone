using Data;
using UnityEngine;
using Zenject;

namespace Core
{
    public abstract class Enemy : MonoBehaviour
    {
        [Inject] private UnitList _unitList;
        [Inject] private PlayerDataManager _playerDataManager;
        [Inject] private EnemyDataController _enemyDataController;

        protected virtual void OnEnable()
        {
            _unitList.AddEnemy(this);
        }

        protected virtual void OnDisable()
        { 
            _unitList.RemoveEnemy(this);

            _playerDataManager.AddMoney(_enemyDataController.Config.MoneyForKill);
        }
    }
}
