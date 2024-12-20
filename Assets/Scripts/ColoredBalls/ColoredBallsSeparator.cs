using UnityEngine;

public class ColoredBallsSeparator : MonoBehaviour
{
    [SerializeField] private SpawnPointFirstLayerSphere _spawnPointFirstLayerSphere;
    [SerializeField] private SpawnerColoredBalls _spawnerColoredSpheres;

    private float _radius = 100f;
    private float _delayColoredSpheres;

    private void OnEnable()
    {
        ResetDelayColoredSpheres();

        _spawnerColoredSpheres.ColoredSphereCollisionDetected += TearOffMonochromeColoredSpheres;
    }

    private void OnDisable()
    {
        _spawnerColoredSpheres.ColoredSphereCollisionDetected -= TearOffMonochromeColoredSpheres;
    }

    private void TearOffMonochromeColoredSpheres(ColoredBall currentColoredSphere)
    {
        float increaserDelayColoredSpheres = 0.008f;

        ResetDelayColoredSpheres();

        Collider[] overlappedColliders = Physics.OverlapSphere(_spawnPointFirstLayerSphere.transform.position, _radius);

        for (int j = 0; j < overlappedColliders.Length; j++)
        {
            if (overlappedColliders[j].TryGetComponent(out ColoredBall coloredBall))
            {
                if (coloredBall.Color == currentColoredSphere.Color)
                {
                    IncreaseDelayColoredSpheres(increaserDelayColoredSpheres);

                    if (coloredBall.LayerSphere.Identifier >= currentColoredSphere.LayerSphere.Identifier)
                    {
                        coloredBall.SetDelayCoroutine(_delayColoredSpheres);

                        coloredBall.TryFallDown();
                    }
                }
            }
        }
    }

    private void ResetDelayColoredSpheres()
    {
        float minValuedelayColoredSpheres = 0f;

        _delayColoredSpheres = minValuedelayColoredSpheres;
    }

    private void IncreaseDelayColoredSpheres(float increaserDelayColoredSpheres)
    {
        _delayColoredSpheres += increaserDelayColoredSpheres;
    }
}

