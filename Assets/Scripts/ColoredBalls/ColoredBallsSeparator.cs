using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColoredBallsSeparator : MonoBehaviour
{
    [SerializeField] private SpawnPointFirstLayerSphere _spawnPointFirstLayerSphere;
    [SerializeField] private SpawnerColoredBalls _spawnerColoredSpheres;

    private float _radius = 100f;
    private float _delayColoredSpheres;
    private float _increaserDelayColoredSpheres;

    private void OnEnable()
    {
        _spawnerColoredSpheres.ColoredSphereCollisionDetected += TryTearOffMonochromeColoredSpheres;
    }

    private void OnDisable()
    {
        _spawnerColoredSpheres.ColoredSphereCollisionDetected -= TryTearOffMonochromeColoredSpheres;
    }

    private void TryTearOffMonochromeColoredSpheres(ColoredBall currentColoredSphere)
    {
        _increaserDelayColoredSpheres = 0.004f;

        Vector3 positionCurrentColoredSphere = currentColoredSphere.transform.position;

        ResetDelayColoredSpheres();

        Collider[] overlappedColliders = Physics.OverlapSphere(_spawnPointFirstLayerSphere.transform.position, _radius);

        TryTearOffMonochromeColoredCurrentSphere(overlappedColliders, currentColoredSphere, positionCurrentColoredSphere);

        TryTearOffMonochromeColoredNextSphere(overlappedColliders, currentColoredSphere);
    }

    private void TryTearOffMonochromeColoredCurrentSphere(Collider[] collidersShperes,  ColoredBall sphere, Vector3 positionCurrentColoredSphere)
    {
        Dictionary<ColoredBall, float> coloredSpheres = new Dictionary<ColoredBall, float>();

        for (int i = 0; i < collidersShperes.Length; i++)
        {
            if (collidersShperes[i].TryGetComponent(out ColoredBall coloredSphere))
            {
                if (coloredSphere.Color == sphere.Color)
                {
                    float currentDistance = Vector3.Distance(positionCurrentColoredSphere, coloredSphere.transform.position);

                    if (coloredSphere.LayerSphere.Identifier == sphere.LayerSphere.Identifier)
                    {
                        coloredSpheres.Add(coloredSphere, currentDistance);
                    }
                }
            }
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
            if (collidersShperes[i].TryGetComponent(out ColoredBall coloredBall))
            {
                if (coloredBall.Color == sphere.Color)
                {
                    IncreaseDelayColoredSpheres(_increaserDelayColoredSpheres);

                    if (coloredBall.LayerSphere.Identifier > sphere.LayerSphere.Identifier)
                    {
                        TearOffColoredSphere(coloredBall);
                    }
                }
            }
        }
    }

    private void ResetDelayColoredSpheres()
    {
        float minValuedelayColoredSpheres = 0.002f;

        _delayColoredSpheres = minValuedelayColoredSpheres;
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

