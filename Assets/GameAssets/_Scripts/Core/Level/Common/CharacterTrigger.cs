using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class CharacterTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onEnter;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out CharacterMovement character))
            {
                _onEnter.Invoke();
            }
        }
    }
}
