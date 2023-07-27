using System;
using UnityEngine;

namespace Core
{
    public abstract class UnitHealth : MonoBehaviour
    {
        /// <summary> arg1 - current health, arg2 - max health </summary>
        public Action<float, float> OnHealthChanged;
    }
}
