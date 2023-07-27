using Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class PlayerMoneyUI : MonoBehaviour
    {
        [SerializeField] private Text _moneyText;

        [Inject] private PlayerRuntimeData _playerData;

        private void OnEnable()
        {
            _playerData.OnMoneyChanged += UpdateUI;

            UpdateUI(_playerData.Money);
        }

        private void OnDisable()
        {
            _playerData.OnMoneyChanged -= UpdateUI;
        }

        private void UpdateUI(int money)
        {
            _moneyText.text = money.ToString();
        }
    }
}