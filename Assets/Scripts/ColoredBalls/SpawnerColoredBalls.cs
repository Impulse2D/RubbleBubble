using System;
using UnityEngine;

public class SpawnerColoredBalls : Spawner<ColoredBallsPool>
{
    [SerializeField] private SpawnerLayersSpheres _spawnerLayersSpheres;
    [SerializeField] private MaterialsDispenser _materialsDispenser;
    [SerializeField] private SpawnerPrototypeLayerSphere _spawnerPrototypeLayerSphere;

    private PrototypeLayerSphere _prototypeLayerSphere;
    private Material _currentMaterial;
    private int _maxQuantitySectors;
    private int _quantityPointsSector;

    public event Action<int> ColoredSphereInitialized;
    public event Action<ColoredBall> ColoredSphereCollisionDetected;
    public event Action<ColoredBall> ColoredSphereReleased;


    private void Start()
    {
        _prototypeLayerSphere = _spawnerPrototypeLayerSphere.GetCreatedInterLayer();

        _maxQuantitySectors = 3;

        _quantityPointsSector = _prototypeLayerSphere.SpawnPointsPositionsColoredBalls.Length / _maxQuantitySectors;
    }

    private void OnEnable()
    {
        _spawnerLayersSpheres.InterlayerInitialized += Initialize;
        _spawnerLayersSpheres.InterlayerReleased += Create;
    }

    private void OnDisable()
    {
        _spawnerLayersSpheres.InterlayerInitialized -= Initialize;
        _spawnerLayersSpheres.InterlayerReleased -= Create;
    }

    private void Initialize(int maxQuantityInterlayers)
    {
        int maxQuantityColoredSpheres = _quantityPointsSector * maxQuantityInterlayers;


        for (int i = 0; i < maxQuantityColoredSpheres; i++)
        {   
            ObjectsPool.Initialize();
        }

        ColoredSphereInitialized?.Invoke(maxQuantityColoredSpheres);
    }

    private void Create(LayerSphere layerSphere)
    {
        Vector3 defaultScaleColoredSphere = new Vector3(0.15f, 0.15f, 0.15f);

        int indexPointColoredSphere = 0;

        for (int i = 0; i < _maxQuantitySectors; i++)
        {
            _currentMaterial = _materialsDispenser.GetRandomMaterial();

            for (int j = 0; j < _quantityPointsSector; j++)
            {
                ColoredBall coloredSphere = ObjectsPool.GetObject(_prototypeLayerSphere.SpawnPointsPositionsColoredBalls[indexPointColoredSphere], Quaternion.identity);

                SetMaterial(coloredSphere, _currentMaterial);

                SetParent(coloredSphere, layerSphere.transform);

                AddSphere(coloredSphere, layerSphere);

                SetDefaultLocalScale(coloredSphere, defaultScaleColoredSphere);

                coloredSphere.SetLayerSphere(layerSphere);

                coloredSphere.CollisionDetected += ReportCollisionDetectedColoredSphere;

                coloredSphere.Released += ReportReleasedColoredSphere;

                ++indexPointColoredSphere;
            }
        }
    }

    private void ReportCollisionDetectedColoredSphere(ColoredBall coloredSphere)
    {
        coloredSphere.CollisionDetected -= ReportCollisionDetectedColoredSphere;

        ColoredSphereCollisionDetected?.Invoke(coloredSphere);
    }

    private void ReportReleasedColoredSphere(ColoredBall coloredSphere)
    {
        coloredSphere.Released -= ReportReleasedColoredSphere;

        ColoredSphereReleased?.Invoke(coloredSphere);
    }

    private void AddSphere(ColoredBall coloredSphere, LayerSphere layerSphere)
    {
        layerSphere.AddColoredBall(coloredSphere);
    }

    private void SetMaterial(ColoredBall coloredSphere, Material material)
    {
        coloredSphere.SetMaterial(material);
    }

    private void SetParent(ColoredBall coloredSphere, Transform parent)
    {
        coloredSphere.transform.SetParent(parent, false);
    }

    private void SetDefaultLocalScale(ColoredBall coloredSphere, Vector3 scale)
    {
        coloredSphere.transform.localScale = scale;
    }
}
