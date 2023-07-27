using Data;
using System;
using UnityEngine;
using Zenject;

namespace Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private CharacterStateController _stateController;
        private CharacterDataController _dataController;
        private IInputService _inputService;

        private float _lastTimeMove;
        private Vector3 _moveDirection = Vector3.forward;

        [Inject]
        private void Construct(CharacterStateController stateController,
            Rigidbody rigidbody,
            CharacterDataController dataController,
            IInputService inputService)
        {
            _inputService = inputService;
            _stateController = stateController;
            _rigidbody = rigidbody;
            _dataController = dataController;
        }

        private void OnEnable()
        {
            _inputService.OnMove += Move;
        }

        private void OnDisable()
        {
            _inputService.OnMove -= Move;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = Vector3.zero;

            _lastTimeMove += Time.fixedDeltaTime;

            if (_lastTimeMove > _dataController.Config.IdleTransitionTime)
                _stateController.ChangeState(CharacterStateController.State.Idle);
        }

        private void Move(Vector3 direction)
        {
            if (_stateController.IsDead) return;

            if (_stateController.CurrentState == CharacterStateController.State.Idle)
                _stateController.ChangeState(CharacterStateController.State.Move);

            _moveDirection = direction;
            _rigidbody.MovePosition(_rigidbody.position + direction * _dataController.RuntimeData.MoveSpeed * Time.fixedDeltaTime);

            _lastTimeMove = 0;

            UpdateRotation();
        }

        private void UpdateRotation()
        {
            var lookRotation = Quaternion.LookRotation(_moveDirection);
            transform.rotation = Quaternion.AngleAxis(lookRotation.eulerAngles.y, Vector3.up);
        }
    }
}
