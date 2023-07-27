using System;

namespace Data
{
    [Serializable]
    public class Wallet
    {
        private int _money;

        public event Action<int> OnMoneyChanged;

        public int Money
        {
            get => _money;
            set
            {
                _money = value;

                OnMoneyChanged?.Invoke(_money);
            }
        }

        public void Clear()
        {
            Money = 0;
        }
    }
}
