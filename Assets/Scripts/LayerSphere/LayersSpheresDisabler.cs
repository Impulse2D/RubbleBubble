using UnityEngine;

public class LayersSpheresDisabler : MonoBehaviour
{
    [SerializeField] private LayerSpherePool _interlayerSpherePool;
    [SerializeField] private SpawnPointFirstLayerSphere _spawnPointFirstInterlayer;
    [SerializeField] private SpawnerLayersSpheres _spawnerLayersSpheres;

    private void OnEnable()
    {
        _spawnerLayersSpheres.ColoredballsLostedReporting += RemoveInterlayers;
    }

    private void OnDisable()
    {
        _spawnerLayersSpheres.ColoredballsLostedReporting -= RemoveInterlayers;
    }

    private void RemoveInterlayers(LayerSphere layerSphere)
    {
        _interlayerSpherePool.ReturnObject(layerSphere);

        layerSphere.ReportReleased();
    }
}
