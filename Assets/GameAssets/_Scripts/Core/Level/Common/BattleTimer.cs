using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Core
{
    public class BattleTimer : IDisposable
    {
        private LevelManager _levelManager;
        private ICoroutineHandler _coroutineHandler;
        private TimeManager _timeManager;

        public event Action<int> OnTimerUpdate;
        public event Action OnTimerEnd;

        public BattleTimer(LevelManager levelManager, ICoroutineHandler coroutineHandler, TimeManager timeManager)
        {
            _levelManager = levelManager;
            _coroutineHandler = coroutineHandler;
            _timeManager = timeManager;
            _levelManager.OnLevelLoaded += OnLevelLoaded;
        }

        public void Dispose()
        {
            _levelManager.OnLevelLoaded -= OnLevelLoaded;
        }

        private void OnLevelLoaded()
        {
            _coroutineHandler.StartCoroutine(StartTimer());
        }

        private IEnumerator StartTimer()
        {
            for (int i = 3; i > 0; i--)
            {
                OnTimerUpdate?.Invoke(i);

                yield return new WaitForSecondsRealtime(1);
            }

            _timeManager.IsPaused = false;

            OnTimerEnd?.Invoke();
        }
    }
}
