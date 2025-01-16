using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    private const string Rotation = "_Rotation";

    public void Init()
    {
        _speed = 2f;
    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat(Rotation, Time.time * _speed);
    }
}

