using System;
using UnityEngine;

namespace Core
{
    public class CharacterStateController : MonoBehaviour
    {
        private State _currentState = State.Idle;
        public State CurrentState => _currentState;

        public bool IsDead => _currentState == State.Died;

        public enum State
        {
            Idle,
            Move,
            Died,
        }

        public event Action<State> OnStateChanged;

        public void ChangeState(State newState)
        {
            _currentState = newState;
            OnStateChanged?.Invoke(newState);
        }
    }
}
