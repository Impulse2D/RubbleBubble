using System;
using UnityEngine;

namespace LayerSpheres
{
    public class SpawnerParentSphere : MonoBehaviour
    {
        [SerializeField] private SpawnPointFirstLayerSphere _spawnPointFirstLayerSphere;
        [SerializeField] private ParentSpheres _parentSpheres;

        private ParentSpheres _currentParentSpheres;

        public ParentSpheres CurrentParentSpheres => _currentParentSpheres;

        public event Action<ParentSpheres> Created;

        public void Init()
        {
            Create();

            Created?.Invoke(_currentParentSpheres);
        }

        private void Create()
        {
            _currentParentSpheres = Instantiate(_parentSpheres, _spawnPointFirstLayerSphere.transform.position, Quaternion.identity);
        }
    }
}
