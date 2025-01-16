using System;
using UnityEngine;

public class GamePointsCounter : MonoBehaviour
{
    [SerializeField] private GamePointsHandler _gamePointsHandler;

    [SerializeField] private float _maxQuantityGamePoints;
    private float _currentQuantityGamePoints;

    public event Action<float> PointCounted;
    public event Action MaxResultAchieved;

    public float MaxQuantityGamePoints => _maxQuantityGamePoints;

    public void Init()
    {
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
        float minQuantityGamePoints = 0f;

        _currentQuantityGamePoints = minQuantityGamePoints;
    }
}
