using Data;
using UnityEngine;

namespace Core
{
    public class EnemyDataController : MonoBehaviour
    {
        [SerializeField] private EnemyConfig _config;

        public EnemyConfig Config  => _config;
    }
}
