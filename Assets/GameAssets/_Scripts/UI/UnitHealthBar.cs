using Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class UnitHealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBarImage;
        [SerializeField] private Text _healthValueText;

        private UnitHealth _unitHealth;

        [Inject]
        private void Construct(UnitHealth unitHealth)
        {
            _unitHealth = unitHealth;

            _unitHealth.OnHealthChanged += UpdateUI;
        }

        private void OnDestroy()
        {
            _unitHealth.OnHealthChanged -= UpdateUI;
        }

        private void UpdateUI(float currentHealth, float maxHealth)
        {
            _healthBarImage.fillAmount = currentHealth / maxHealth;
            _healthValueText.text = currentHealth.ToString("0");
        }
    }
}
