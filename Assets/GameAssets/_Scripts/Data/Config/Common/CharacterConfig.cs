using Core;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Character Config")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _idleTransitionTime;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _fireRate;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private float _projectileMoveSpeed;
        [SerializeField] private float _damagePerShot;

        public float MoveSpeed => _moveSpeed;
        public float MaxHealth => _maxHealth;
        public float FireRate => _fireRate;
        public float DamagePerShot => _damagePerShot;
        public float IdleTransitionTime => _idleTransitionTime;
        public float RotationSpeed => _rotationSpeed;
        public Projectile ProjectilePrefab => _projectilePrefab;
        public float ProjectileMoveSpeed => _projectileMoveSpeed;
    }
}
