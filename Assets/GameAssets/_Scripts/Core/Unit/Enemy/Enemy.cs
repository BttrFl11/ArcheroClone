using Data;
using UnityEngine;
using Zenject;

namespace Core
{
    public abstract class Enemy : MonoBehaviour
    {
        [Inject] private UnitList _unitList;
        [Inject] private PlayerRuntimeData _playerRuntimeData;
        [Inject] private EnemyDataController _enemyDataController;

        protected virtual void OnEnable()
        {
            _unitList.AddEnemy(this);
        }

        protected virtual void OnDisable()
        { 
            _unitList.RemoveEnemy(this);

            _playerRuntimeData.Wallet.Money += _enemyDataController.Config.MoneyForKill;
        }
    }
}
