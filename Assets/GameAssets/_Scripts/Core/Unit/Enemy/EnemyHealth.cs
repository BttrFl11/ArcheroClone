using Data;
using Zenject;

namespace Core
{
    public class EnemyHealth : UnitHealth, IDamageable
    {
        [Inject] private EnemyDataController _dataController;

        private float _health;

        private EnemyConfig Config => _dataController.Config;

        private void OnEnable()
        {
            _health = Config.MaxHealth;

            OnHealthChanged?.Invoke(_health, Config.MaxHealth);
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;

            OnHealthChanged?.Invoke(_health, Config.MaxHealth);

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
