using Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class BattleTimerUI : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Text _timerText;

        [Inject] private BattleTimer _battleTimer;

        private void OnEnable()
        {
            _battleTimer.OnTimerEnd += OnTimeEnd;
            _battleTimer.OnTimerUpdate += OnTimeUpdate;
        }

        private void OnDisable()
        {
            _battleTimer.OnTimerEnd -= OnTimeEnd;
            _battleTimer.OnTimerUpdate -= OnTimeUpdate;
        }

        private void OnTimeUpdate(int time)
        {
            _panel.SetActive(true);

            _timerText.text = time.ToString();
        }

        private void OnTimeEnd()
        {
            _panel.SetActive(false);
        }
    }
}
