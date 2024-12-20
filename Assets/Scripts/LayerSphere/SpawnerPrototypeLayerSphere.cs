using UnityEngine;

public class SpawnerPrototypeLayerSphere : MonoBehaviour
{
    [SerializeField] private SpawnPointPrototypeLayerSphere _spawnPointPrototypeInterLayer;
    [SerializeField] private PrototypeLayerSphere _prototypeInterLayer;

    public PrototypeLayerSphere GetCreatedInterLayer()
    {
        return Instantiate(_prototypeInterLayer, _spawnPointPrototypeInterLayer.transform.position, Quaternion.identity);
    }
}
