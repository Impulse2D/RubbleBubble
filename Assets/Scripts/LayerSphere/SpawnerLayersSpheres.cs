using System;
using UnityEngine;

public class SpawnerLayersSpheres : Spawner<LayerSpherePool>
{
    [SerializeField] private SpawnPointFirstLayerSphere _pointPosition;
    [SerializeField] private ParentSpheres _parentSpheres;

    private int _maxQuantityInterlayers;
    private ParentSpheres _currentParentSpheres;

    public event Action<int> InterlayerInitialized;
    public event Action<LayerSphere> InterlayerReleased;
    public event Action<LayerSphere> ColoredballsLostedReporting;

    private void Start()
    {
        _currentParentSpheres = Instantiate(_parentSpheres, _pointPosition.transform.position, Quaternion.identity);

        _maxQuantityInterlayers = 2;

        int _maxQuantityInterlayersInitialized = 3;

        for (int i = 0; i < _maxQuantityInterlayersInitialized; i++)
        {
            ObjectsPool.Initialize();
        }

        InterlayerInitialized?.Invoke(_maxQuantityInterlayers);

        for (int i = 0; i < ObjectsPool.Objects.Count; i++)
        {
            ObjectsPool.Objects[i].transform.SetParent(_currentParentSpheres.transform, false);
            ObjectsPool.Objects[i].transform.position = _currentParentSpheres.transform.position;
        }

        for (int j = 0; j < _maxQuantityInterlayers; j++)
        {
            Create();
        }
    }

    private void Create()
    {
        LayerSphere sphereLayer = ObjectsPool.GetObject(_pointPosition.transform.position, Quaternion.identity);

        InterlayerReleased?.Invoke(sphereLayer);

        sphereLayer.ColoredBallsLosted += ReportColoredballsLosted;

        sphereLayer.Released += CreteNextLayerSphere;
    }

    private void ReportColoredballsLosted(LayerSphere sphereLayer)
    {
        sphereLayer.ColoredBallsLosted -= ReportColoredballsLosted;

        ColoredballsLostedReporting?.Invoke(sphereLayer);
    }

    private void CreteNextLayerSphere(LayerSphere layerSphere)
    {
        layerSphere.Released -= CreteNextLayerSphere;

        Create();
    }
}
