using Core;
using System;
using UnityEngine;
using Zenject;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _pauseButton;

        [Inject] private TimeManager _timeManager;
        [Inject] private BattleTimer _battleTimer;

        private void OnEnable()
        {
            _battleTimer.OnTimerUpdate += HidePauseButton;
            _battleTimer.OnTimerEnd += ShowPauseButton;
        }

        private void OnDisable()
        {
            _battleTimer.OnTimerUpdate -= HidePauseButton;
            _battleTimer.OnTimerEnd -= ShowPauseButton;
        }

        private void HidePauseButton(int _)
        {
            _pauseButton.SetActive(false);
        }

        private void ShowPauseButton()
        {
            _pauseButton.SetActive(true);
        }

        public void PauseClick()
        {
            _panel.SetActive(true);

            _timeManager.IsPaused = true;
        }

        public void CloseClick()
        {
            _panel.SetActive(false);

            _timeManager.IsPaused = false;
        }
    }
}
