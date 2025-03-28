using System;
using System.Collections.Generic;
using System.Linq;
using LayerSpheres;
using UnityEngine;

namespace ColoredBalls
{
    public class ColoredBallsSeparator : MonoBehaviour
    {
        [SerializeField] private SpawnPointFirstLayerSphere _spawnPointFirstLayerSphere;
        [SerializeField] private SpawnerColoredBalls _spawnerColoredSpheres;
        [SerializeField] private float _radius;
        [SerializeField] private float _minValuedelayColoredSpheres;

        private float _delayColoredSpheres;
        private float _increaserDelayColoredSpheres;

        public event Action AttemptedTearOffEnabled;

        private void OnEnable()
        {
            _spawnerColoredSpheres.ColoredBallCollisionDetected += TryTearOffMonochromeColoredSpheres;
        }

        private void OnDisable()
        {
            _spawnerColoredSpheres.ColoredBallCollisionDetected -= TryTearOffMonochromeColoredSpheres;
        }

        private void TryTearOffMonochromeColoredSpheres(ColoredBall currentColoredSphere)
        {
            _increaserDelayColoredSpheres = 0.004f;

            Vector3 positionCurrentColoredSphere = currentColoredSphere.transform.position;

            ResetDelayColoredSpheres();

            AttemptedTearOffEnabled?.Invoke();

            Collider[] overlappedColliders = Physics.OverlapSphere(_spawnPointFirstLayerSphere.transform.position, _radius);

            TryTearOffMonochromeColoredCurrentSphere(overlappedColliders, currentColoredSphere, positionCurrentColoredSphere);
            TryTearOffMonochromeColoredNextSphere(overlappedColliders, currentColoredSphere);
        }

        private void TryTearOffMonochromeColoredCurrentSphere(Collider[] collidersShperes, ColoredBall sphere, Vector3 positionCurrentColoredSphere)
        {
            Dictionary<ColoredBall, float> coloredSpheres = new Dictionary<ColoredBall, float>();

            for (int i = 0; i < collidersShperes.Length; i++)
            {
                if ((collidersShperes[i].TryGetComponent(out ColoredBall coloredSphere) &&
                     coloredSphere.Color == sphere.Color) == false) continue;

                float currentDistance = Vector3.Distance(positionCurrentColoredSphere, coloredSphere.transform.position);

                if (coloredSphere.LayerSphere.Identifier != sphere.LayerSphere.Identifier) continue;

                coloredSpheres.Add(coloredSphere, currentDistance);
            }

            var sortedDictionary = coloredSpheres.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var coloredSphere in sortedDictionary)
            {
                IncreaseDelayColoredSpheres(_increaserDelayColoredSpheres);
                TearOffColoredSphere(coloredSphere.Key);
            }
        }

        private void TryTearOffMonochromeColoredNextSphere(Collider[] collidersShperes, ColoredBall sphere)
        {
            for (int i = 0; i < collidersShperes.Length; i++)
            {
                if ((collidersShperes[i].TryGetComponent(out ColoredBall coloredBall) &&
                    coloredBall.Color == sphere.Color) == false) continue;

                IncreaseDelayColoredSpheres(_increaserDelayColoredSpheres);

                if ((coloredBall.LayerSphere.Identifier > sphere.LayerSphere.Identifier) == false) continue;

                TearOffColoredSphere(coloredBall);
            }
        }

        private void ResetDelayColoredSpheres()
        {
            _delayColoredSpheres = _minValuedelayColoredSpheres;
        }

        private void IncreaseDelayColoredSpheres(float increaserDelayColoredSpheres)
        {
            _delayColoredSpheres += increaserDelayColoredSpheres;
        }

        private void TearOffColoredSphere(ColoredBall coloredSphere)
        {
            coloredSphere.TryFallDown(_delayColoredSpheres);
        }
    }
}