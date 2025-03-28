using System.Collections.Generic;
using UnityEngine;

namespace Skybox
{
    public class SkyboxInstaller : MonoBehaviour
    {
        [SerializeField] private List<Material> _materialsSkyboxes;
        [SerializeField] private float _minIndexMaterialsSkyboxes = 0f;

        private float _maxIndexMaterialsSkyboxes;

        public void Init()
        {
            _maxIndexMaterialsSkyboxes = _materialsSkyboxes.Count;

            float randomMaterial = Random.Range(_minIndexMaterialsSkyboxes, _maxIndexMaterialsSkyboxes);

            RenderSettings.skybox = _materialsSkyboxes[(int)randomMaterial];
        }
    }
}
