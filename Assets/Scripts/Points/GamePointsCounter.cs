using System;
using UnityEngine;

namespace Points
{
    public class GamePointsCounter : MonoBehaviour
    {
        [SerializeField] private GamePointsHandler _gamePointsHandler;
        [SerializeField] private float _maxQuantityGamePoints;
        [SerializeField] private float _minQuantityGamePoints = 0f;
        [SerializeField] private int _minRandomQuantityGamePoints = 300;
        [SerializeField] private int _maxRandomQuantityGamePoints = 1000;

        private float _currentQuantityGamePoints;

        public event Action<float> PointCounted;
        public event Action MaxResultAchieved;

        public float MaxQuantityGamePoints => _maxQuantityGamePoints;

        public void Init()
        {
            CalculateMaxQuantityGamePoints();
            ResetCurrentQuantityGamePoints();
        }

        private void OnEnable()
        {
            _gamePointsHandler.CollisionDetected += Count;
        }

        private void OnDisable()
        {
            _gamePointsHandler.CollisionDetected -= Count;
        }

        private void Count()
        {
            _currentQuantityGamePoints++;

            PointCounted?.Invoke(_currentQuantityGamePoints);

            TryReportMaxResultAchieved();
        }

        private void TryReportMaxResultAchieved()
        {
            if (_currentQuantityGamePoints == _maxQuantityGamePoints)
            {
                MaxResultAchieved?.Invoke();
            }
        }

        private void ResetCurrentQuantityGamePoints()
        {
            _currentQuantityGamePoints = _minQuantityGamePoints;
        }

        private void CalculateMaxQuantityGamePoints()
        {
            int randomQuantityGamePoints = UnityEngine.Random.Range(_minRandomQuantityGamePoints, _maxRandomQuantityGamePoints);
            _maxQuantityGamePoints = randomQuantityGamePoints;
        }
    }
}