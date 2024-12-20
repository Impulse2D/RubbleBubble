using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    private const string Rotation = "_Rotation";

    private float _speed;

    private void Start()
    {
        _speed = 2f;
    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat(Rotation, Time.time * _speed);
    }
}

