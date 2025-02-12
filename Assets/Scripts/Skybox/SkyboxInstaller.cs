using UnityEngine;
using System.Collections.Generic;

public class SkyboxInstaller : MonoBehaviour
{
    [SerializeField] private List<Material> _materialsSkyboxes;

    public void Init()
    {
        float minIndexMaterialsSkyboxes = 0f;
        float maxIndexMaterialsSkyboxes = _materialsSkyboxes.Count;

        float randomMaterial = Random.Range(minIndexMaterialsSkyboxes, maxIndexMaterialsSkyboxes);

        RenderSettings.skybox = _materialsSkyboxes[(int)randomMaterial];
    }
}
