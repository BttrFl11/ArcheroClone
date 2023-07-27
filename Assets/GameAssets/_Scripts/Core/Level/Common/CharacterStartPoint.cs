using UnityEngine;
using Zenject;

namespace Core
{
    public class CharacterStartPoint : MonoBehaviour
    {
        private LevelManager _levelManager;
        private UnitList _unitList;

        [Inject]
        private void Construct(LevelManager levelManager, UnitList unitList)
        {
            _levelManager = levelManager;
            _unitList = unitList;
        }

        private void OnEnable()
        {
            _levelManager.OnLevelLoaded += TranslateCharacter;
        }

        private void OnDisable()
        {
            _levelManager.OnLevelLoaded -= TranslateCharacter;
        }

        private void TranslateCharacter()
        {
            _unitList.Character.position = transform.position;
        }
    }
}
