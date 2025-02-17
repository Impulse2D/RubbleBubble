using System;
using ColoredBalls;
using UnityEngine;

namespace EffectsColoredBalls
{
    public class SpawnerEffectsColoredBalls : Spawner<EffectsColoredBallsPool>
    {
        [SerializeField] private SpawnerColoredBalls _spawnerColoredBalls;

        public event Action<EffectColoredBall> EffectReleased;

        private void OnEnable()
        {
            _spawnerColoredBalls.ColoredSphereInitialized += Initialize;
            _spawnerColoredBalls.ColoredSphereReleased += Create;
        }

        private void OnDisable()
        {
            _spawnerColoredBalls.ColoredSphereInitialized -= Initialize;
            _spawnerColoredBalls.ColoredSphereReleased -= Create;
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
}
