using Data;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Core
{
    public class LevelManager : IDisposable
    {
        private LevelsConfig _levelConfig;
        private LevelEnvironment _levelEnvironment;
        private CharacterSpawner _characterSpawner;
        private EnemyCounter _enemyCounter;
        private ISceneLoader _sceneLoader;
        private TimeManager _timeManager;

        private int _levelId;

        public event Action OnLevelCompleted;
        public event Action OnLevelLoaded;

        public LevelManager(GameConfig gameConfig,
            LevelEnvironment levelEnvironment,
            CharacterSpawner characterSpawner,
            EnemyCounter enemyCounter,
            ISceneLoader sceneLoader,
            TimeManager timeManager)
        {
            _levelConfig = gameConfig.LevelsConfig;
            _levelEnvironment = levelEnvironment;
            _characterSpawner = characterSpawner;
            _enemyCounter = enemyCounter;
            _sceneLoader = sceneLoader;
            _timeManager = timeManager;

            _levelId = 0;

            _characterSpawner.OnCharacterSpawned += LoadLevel;
            _enemyCounter.OnAllEnemiesDied += CompleteLevel;
        }

        public void Dispose()
        {
            _characterSpawner.OnCharacterSpawned -= LoadLevel;
            _enemyCounter.OnAllEnemiesDied -= CompleteLevel;
        }

        public void CompleteLevel()
        {
            _levelId++;

            OnLevelCompleted?.Invoke();
        }

        public void LoadLevel()
        {
            if (_levelId >= _levelConfig.Levels.Count)
            {
                _sceneLoader.LoadNext();
                return;
            }

            _levelEnvironment.LoadLevel(_levelConfig.Levels[_levelId]);

            if (_enemyCounter.Count <= 0)
            {
                CompleteLevel();
            }
            else
            {
                OnLevelLoaded?.Invoke();

                _timeManager.IsPaused = true;
            }
        }
    }
}