using System;
using UnityEngine;

namespace Core
{
    public interface IInputService
    {
        /// <summary> Returns normalized move direction </summary>
        event Action<Vector3> OnMove;

        bool IsMobile { get; }

        void Tick(float deltaTime);
        void FixedTick();
    }
}
