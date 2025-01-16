using System;
using UnityEngine;

public class SpawnerDiamondsPlus : Spawner<DiamondPlusPool>
{
    [SerializeField] private SpawnPointDiamondPlus _spawnPointDiamondPlus;
    [SerializeField] private TargetPointDiamondPlus _targetPointDiamondPlus;
    [SerializeField] private GamePointsHandler _gamePointsHandler;

    public event Action<DiamondPlusMover> DiamondPlusReleased;

    private void OnEnable()
    {
        _gamePointsHandler.CollisionDetected += Create;
    }

    private void OnDisable()
    {
        _gamePointsHandler.CollisionDetected -= Create;
    }

    private void Create()
    {
        DiamondPlusMover diamondPlus = ObjectsPool.GetObject(_spawnPointDiamondPlus.transform.position, Quaternion.identity);

        diamondPlus.Move(_targetPointDiamondPlus.transform.position);

        diamondPlus.Released += ReportDiamondPlusReleased;
    }

    private void ReportDiamondPlusReleased(DiamondPlusMover diamondPlus)
    {
        diamondPlus.Released -= ReportDiamondPlusReleased;

        DiamondPlusReleased?.Invoke(diamondPlus);
    }
}
