using System;
using UI;
using UnityEngine;
using Input = UnityEngine.Input;

namespace Core
{
    [Serializable]
    public class InputService_PC : IInputService
    {
        private CharacterMoveJoystick _moveJoystick;

        public event Action<Vector3> OnMove;

        private Vector3 _moveDirection;

        public bool IsMobile => false;

        public InputService_PC(CharacterMoveJoystick moveJoystick)
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
            _moveDirection = new Vector3(Input.GetAxisRaw(GameConst.HORIZONTAL_AXIS), 0, Input.GetAxisRaw(GameConst.VERTICAL_AXIS)).normalized;
            if (_moveDirection.magnitude > 0)
            {
                OnMove?.Invoke(_moveDirection);
            }
            else if(_moveJoystick.Direction.magnitude > 0.1)
            {
                OnMove?.Invoke(new Vector3(_moveJoystick.Direction.x, 0, _moveJoystick.Direction.y));
            }
        }
    }
}
