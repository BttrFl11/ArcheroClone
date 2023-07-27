using Core;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Character Runtime Data")]
    public class CharacterRuntimeData : ScriptableObject
    {
        public float MoveSpeed;
        public float Health;
        public float MaxHealth;
        public float FireRate;
        public float DamagePerShot;
        public Projectile ProjectilePrefab;
        public float ProjectileMoveSpeed;

        public float TimeBtwShots => 1 / FireRate;
    }
}