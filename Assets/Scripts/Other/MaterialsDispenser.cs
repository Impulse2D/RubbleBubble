using System.Collections.Generic;
using UnityEngine;

public class MaterialsDispenser : MonoBehaviour
{
    [SerializeField] private Material _violetMaterial;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _yellowMaterial;

    private List<Material> _materialsColoredBalls;
    public List<Material> MaterialsColoredBalls => _materialsColoredBalls;

    public void Init()
    {
        _materialsColoredBalls = new List<Material>()
        {
            _violetMaterial,
            _greenMaterial,
            _yellowMaterial,
        };
    }

    public Material GetRandomMaterial()
    {
        float minIndexColor = 0f;
        float maxIndexColor = _materialsColoredBalls.Count;

        float randomMaterial = Random.Range(minIndexColor, maxIndexColor);

        return GetMaterial(randomMaterial);
    }

    private Material GetMaterial(float index)
    {
        return _materialsColoredBalls[(int)index];
    }
}