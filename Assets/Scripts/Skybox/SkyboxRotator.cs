using UnityEngine;

namespace Skybox
{
    public class SkyboxRotator : MonoBehaviour
    {
        private const string Rotation = "_Rotation";
        private float _speed = 2;

        private void Update()
        {
            RenderSettings.skybox.SetFloat(Rotation, Time.time * _speed);
        }
    }
}