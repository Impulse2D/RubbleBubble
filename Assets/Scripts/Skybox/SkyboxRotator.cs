using UnityEngine;

namespace Skybox
{
    public class SkyboxRotator : MonoBehaviour
    {
        private float _speed = 2;
        private const string Rotation = "_Rotation";

        private void Update()
        {
            RenderSettings.skybox.SetFloat(Rotation, Time.time * _speed);
        }
    }
}

