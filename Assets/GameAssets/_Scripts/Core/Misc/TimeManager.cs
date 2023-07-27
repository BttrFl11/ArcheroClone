using System;
using UnityEngine;

namespace Core
{
    public class TimeManager
    {
        private bool _isPaused = false;
        public bool IsPaused
        { 
            get => _isPaused; set
            {
                _isPaused = value;

                Time.timeScale = _isPaused ? 0 : 1;

                OnPausedChanged?.Invoke(_isPaused);
            }
        }

        public event Action<bool> OnPausedChanged;
    }
}
