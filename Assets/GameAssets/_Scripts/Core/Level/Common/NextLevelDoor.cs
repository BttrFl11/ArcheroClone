using UnityEngine;
using Zenject;

namespace Core
{
    public class NextLevelDoor : MonoBehaviour
    {
        [SerializeField] private GameObject _trigger;
        [SerializeField] private GameObject _blocker;

        private LevelManager _levelManager;

        [Inject]
        private void Construct(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        private void OnEnable()
        {
            _levelManager.OnLevelCompleted += Open;
        }

        private void OnDisable()
        {
            _levelManager.OnLevelCompleted -= Open;
        }

        private void Open()
        {
            _trigger.SetActive(true);
            _blocker.SetActive(false);
        }

        public void OnDoorEnter()
        {
            _levelManager.LoadLevel();
        }
    }
}