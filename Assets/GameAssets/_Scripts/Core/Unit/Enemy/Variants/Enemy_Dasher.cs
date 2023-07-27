using Data;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Enemy_Dasher : Enemy
    {
        [Inject] private EnemyDataController _dataController;
        [Inject] private UnitList _unitList;
        [Inject] private TimeManager _timeManager;

        private Coroutine _attackRoutine;
        private Rigidbody _rigidbody;
        private State _state;
        private float _currentDashTime;
        private float _dashTimer;

        private EnemyConfig Config => _dataController.Config;

        public enum State
        {
            Idle,
            Chase,
            Dash
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _dashTimer = Config.ImmovableTime;
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

            _dashTimer -= Time.fixedDeltaTime;

            if (_dashTimer <= 0 && _state != State.Dash)
                Dash();
        }

        private void Dash()
        {
            _state = State.Dash;

            StartCoroutine(StartDash());
        }

        private IEnumerator StartDash()
        {
            yield return new WaitForSeconds(Config.ImmovableTime);

            Vector3 direction = (_unitList.Character.position - transform.position).normalized * Config.DashDistance;

            while (true)
            {
                if (_currentDashTime < Config.DashTime)
                {
                    _currentDashTime += Time.fixedDeltaTime;
                    _rigidbody.MovePosition(_rigidbody.position + Time.fixedDeltaTime * Config.MoveSpeed * direction);

                    yield return new WaitForFixedUpdate();
                }
                else
                {
                    _state = State.Chase;
                    _dashTimer = Config.DashWaitTime;
                    _currentDashTime = 0;
                    break;
                }
            }

            yield return null;
        }

        private void Chase()
        {
            Vector3 direction = (_unitList.Character.position - transform.position).normalized;
            _rigidbody.MovePosition(_rigidbody.position + Time.fixedDeltaTime * Config.MoveSpeed * direction);
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
            if (other.TryGetComponent(out CharacterHealth character))
            {
                StopCoroutine(_attackRoutine);
            }
        }
    }
}
