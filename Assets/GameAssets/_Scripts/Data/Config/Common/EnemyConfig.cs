using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Enemy Config")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private int _moneyForKill;
        [SerializeField] private float _contactDamage;
        [SerializeField] private float _contactWaitTime;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _dashDistance;
        [SerializeField] private float _dashTime;
        [SerializeField] private float _dashWaitTime;
        [SerializeField] private float _immovableTime;
        [SerializeField] private float _projectileDamage;
        [SerializeField] private float _fireRate;
        [SerializeField] private GameObject _projectilePrefab;

        public float MaxHealth => _maxHealth;
        public float ContactDamage => _contactDamage;
        public float MoveSpeed => _moveSpeed;
        public float DashDistance => _dashDistance;
        public float ImmovableTime => _immovableTime;
        public float ProjectileDamage => _projectileDamage;
        public float FireRate => _fireRate;
        public float ContactWaitTime => _contactWaitTime;
        public GameObject ProjectilePrefab => _projectilePrefab;
        public float DashTime => _dashTime;
        public float DashWaitTime => _dashWaitTime;
        public int MoneyForKill => _moneyForKill;
    }
}