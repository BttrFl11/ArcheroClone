using Data;
using Zenject;

namespace Core
{
    public class CharacterHealth : UnitHealth, IDamageable
    {
        [Inject] private CharacterDataController _dataController;

        private CharacterRuntimeData Data => _dataController.RuntimeData;

        private void Awake()
        {
            Data.Health = Data.MaxHealth;

            OnHealthChanged?.Invoke(Data.Health, Data.MaxHealth);
        }

        public void TakeDamage(float damage)
        {
            Data.Health -= damage;
    
            OnHealthChanged?.Invoke(Data.Health, Data.MaxHealth);

            if(Data.Health <= 0) 
            {
                Destroy(gameObject);
            }
        }
    }
}
