using Data;
using UnityEngine;
using Zenject;

namespace Core
{
    public class CharacterAttack : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;

        [Inject] private CharacterStateController _stateController;
        [Inject] private UnitList _unitList;
        [Inject] private CharacterDataController _dataController;
        [Inject] private TimeManager _timeManager;

        private float _attackTimer;
        private Transform _target;
        private Vector3 _targetDirection;

        private void FixedUpdate()
        {
            if (_timeManager.IsPaused) return;

            if (_stateController.CurrentState != CharacterStateController.State.Idle)
            {
                _attackTimer = _dataController.RuntimeData.TimeBtwShots;
                return;
            }

            LookAtTarget();

            _attackTimer -= Time.fixedDeltaTime;

            if(_attackTimer <= 0 && _target != null) 
            {
                Attack();
            }
        }

        private void LookAtTarget()
        {
            _target = GetNearestTarget();
            if (_target == null)
                return;

            _targetDirection = (_target.position - transform.position).normalized;
            var lookRotation = Quaternion.LookRotation(_targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _dataController.Config.RotationSpeed * Time.fixedDeltaTime);
        }

        private Transform GetNearestTarget()
        {
            Transform target = null;

            foreach (var enemy in _unitList.Enemies)
            {
                if (target == null)
                {
                    target = enemy.transform;
                }
                else if(Vector3.Distance(transform.position, target.position) >
                    Vector3.Distance(transform.position, enemy.transform.position))
                {
                    target = enemy.transform;
                }
            }

            return target;
        }

        private void Attack()
        {
            _attackTimer = _dataController.RuntimeData.TimeBtwShots;

            var projectile = Instantiate(_dataController.RuntimeData.ProjectilePrefab, _firePoint.position, _firePoint.rotation);
            projectile.Init(_dataController.RuntimeData);
        }
    }
}
