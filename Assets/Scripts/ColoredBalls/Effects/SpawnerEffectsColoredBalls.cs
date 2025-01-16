using System;
using UnityEngine;

public class SpawnerEffectsColoredBalls : Spawner<EffectsColoredBallsPool>
{
    [SerializeField] private SpawnerColoredBalls _spawnerColoredSpheres;

    public event Action<EffectColoredBall> EffectReleased;

    private void OnEnable()
    {
        _spawnerColoredSpheres.ColoredSphereInitialized += Initialize;
        _spawnerColoredSpheres.ColoredSphereReleased += Create;
    }

    private void OnDisable()
    {
        _spawnerColoredSpheres.ColoredSphereInitialized -= Initialize;
        _spawnerColoredSpheres.ColoredSphereReleased -= Create;
    }

    private void Initialize(int maxQuantityEffects)
    {
        for (int i = 0; i < maxQuantityEffects; i++)
        {
            ObjectsPool.Initialize();
        }
    }

    private void Create(ColoredBall coloredBall)
    {
        EffectColoredBall newEffectColoredSphere = ObjectsPool.GetObject(coloredBall.transform.position, Quaternion.identity);

        newEffectColoredSphere.transform.localScale = coloredBall.transform.localScale;

        newEffectColoredSphere.Released += ReportColoredSphereDeactivated;
    }

    private void ReportColoredSphereDeactivated(EffectColoredBall effectColoredBall)
    {
        effectColoredBall.Released -= ReportColoredSphereDeactivated;

        EffectReleased?.Invoke(effectColoredBall);
    }
}
