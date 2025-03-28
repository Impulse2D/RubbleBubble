using System.Collections.Generic;
using UnityEngine;

public class MaterialsDispenser : MonoBehaviour
{
    [SerializeField] private Material _violetMaterial;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _yellowMaterial;
    [SerializeField] private float _minIndexColor = 0f;

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
        float randomMaterial = Random.Range(_minIndexColor, _materialsColoredBalls.Count);

        return GetMaterial(randomMaterial);
    }

    private Material GetMaterial(float index)
    {
        return _materialsColoredBalls[(int)index];
    }
}