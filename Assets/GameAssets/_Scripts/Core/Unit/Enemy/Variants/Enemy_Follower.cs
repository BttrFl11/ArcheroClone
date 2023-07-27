using Data;
using UnityEngine.AI;
using Zenject;
using UnityEngine;
using System;
using System.Collections;

namespace Core
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy_Follower : Enemy
    {
        [Inject] private EnemyDataController _dataController;
        [Inject] private UnitList _unitList;
        [Inject] private TimeManager _timeManager;

        private NavMeshAgent _navAgent;
        private State _state;
        private Coroutine _attackRoutine;
        private Rigidbody _rigidbody;

        private EnemyConfig Config => _dataController.Config;

        public enum State
        {
            Idle,
            Chase,
        }

        private void Awake()
        {
            _navAgent = GetComponent<NavMeshAgent>();
            _rigidbody = GetComponent<Rigidbody>();

            _navAgent.speed = Config.MoveSpeed;
        }

        private void Start()
        {
            StartCoroutine(WaitLevelStart());
        }

        private IEnumerator WaitLevelStart()
        {
            _state = State.Idle;

            yield return new WaitForSeconds(Config.ImmovableTime);

            _state = State.Chase;
        }

        private void FixedUpdate()
        {
            if (_timeManager.IsPaused) return;

            _rigidbody.velocity = Vector3.zero;

            if (_unitList.Character == null) return;

            if (_state == State.Chase)
                Chase();
        }

        private void Chase()
        {
            _navAgent.SetDestination(_unitList.Character.position);
        }

        private IEnumerator StartAttacking(CharacterHealth character)
        {
            while (true)
            {
                if (character == null)
                    break;

                character.TakeDamage(Config.ContactDamage);

                yield return new WaitForSeconds(Config.ContactWaitTime);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterHealth character))
            {
                _attackRoutine = StartCoroutine(StartAttacking(character));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out CharacterHealth character))
            {
                StopCoroutine(_attackRoutine);
            }
        }
    }
}
