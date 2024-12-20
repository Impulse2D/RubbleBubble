using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEffectsColoredBalls : Spawner<EffectsColoredBallsPool>
{
    [SerializeField] private SpawnerColoredBalls _spawnerColoredSpheres;

    private List<EffectColoredBall> _effectsColoredSpheres;

    public event Action<EffectColoredBall> EffectReleased;

    private void Start()
    {
        _effectsColoredSpheres = new List<EffectColoredBall>();
    }

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

        _effectsColoredSpheres.Add(newEffectColoredSphere);

        coloredBall.Deactivated += ReportColoredSphereDeactivated;
    }

    private void ReportColoredSphereDeactivated(ColoredBall coloredBall)
    {
        EffectColoredBall currentEffectColoredSphere = _effectsColoredSpheres[_effectsColoredSpheres.Count - 1];

        coloredBall.Deactivated -= ReportColoredSphereDeactivated;

        if (_effectsColoredSpheres != null)
        {
            EffectReleased?.Invoke(currentEffectColoredSphere);

            _effectsColoredSpheres.Remove(currentEffectColoredSphere);
        }
    }
}
