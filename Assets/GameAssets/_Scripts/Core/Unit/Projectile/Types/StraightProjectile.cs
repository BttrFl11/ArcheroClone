using UnityEngine;

namespace Core
{
    public class StraightProjectile : Projectile
    {
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(transform.forward * Data.ProjectileMoveSpeed * Time.fixedDeltaTime, Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(Data.DamagePerShot);
            }

            Destroy(gameObject);
        }
    }
}
