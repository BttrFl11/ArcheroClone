using UnityEngine;
using Zenject;

namespace Core
{
    public class InputProvider : ITickable, IFixedTickable
    {
        private IInputService _inputService;
        private TimeManager _timeManager;

        public IInputService InputService => _inputService;

        public InputProvider(IInputService inputService, TimeManager timeManager)
        {
            _inputService = inputService;
            _timeManager = timeManager;
        }

        public void Tick()
        {
            if (_timeManager.IsPaused) return;

            _inputService.Tick(Time.deltaTime);
        }

        public void FixedTick()
        {
            if (_timeManager.IsPaused) return;

            _inputService.FixedTick();
        }
    }
}