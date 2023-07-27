using Data;
using UnityEngine;

namespace Core
{
    public abstract class Projectile : MonoBehaviour
    {
        private CharacterRuntimeData _data;
        protected CharacterRuntimeData Data => _data;

        public void Init(CharacterRuntimeData config) 
        {
            _data = config;
        }
    }
}
