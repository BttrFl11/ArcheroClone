using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingPanel;
        [SerializeField] private Image _progressBar;
        [SerializeField] private Text _progressBarText;

        public void SetProgressBarFillAmount(float amount)
        {
            _progressBar.fillAmount = amount;
            _progressBarText.text = $"{amount * 100:0} %";
        }

        public void Show()
        {
            _loadingPanel.SetActive(true);
        }

        public void Hide()
        {
            _loadingPanel.SetActive(false);
        }
    }
}