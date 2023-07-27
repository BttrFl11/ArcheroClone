using System;
using UI;
using UnityEngine;

namespace Core
{
    public class InputService_Mobile : IInputService
    {
        private CharacterMoveJoystick _moveJoystick;

        public event Action<Vector3> OnMove;

        public bool IsMobile => true;

        public InputService_Mobile(CharacterMoveJoystick moveJoystick)
        {
            _moveJoystick = moveJoystick;
        }

        public void Tick(float deltaTime) { }

        public void FixedTick()
        {
            HandleMove();
        }

        private void HandleMove()
        {
            if (_moveJoystick.Direction.magnitude < 0.1)
                return;

            OnMove?.Invoke(new Vector3(_moveJoystick.Direction.x, 0, _moveJoystick.Direction.y));
        }
    }
}