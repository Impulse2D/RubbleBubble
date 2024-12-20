using UnityEngine;

public class EffectsColoredBallsDisabler : MonoBehaviour
{
    [SerializeField] private EffectsColoredBallsPool _effectsColoredSpheresPool;
    [SerializeField] private SpawnerEffectsColoredBalls _spawnerEffectsColoredSpheres;

    private void OnEnable()
    {
        _spawnerEffectsColoredSpheres.EffectReleased += Remove;
    }

    private void OnDisable()
    {
        _spawnerEffectsColoredSpheres.EffectReleased -= Remove;
    }

    private void Remove(EffectColoredBall effectColoredBall)
    {
        _effectsColoredSpheresPool.ReturnObject(effectColoredBall);
    }
}
