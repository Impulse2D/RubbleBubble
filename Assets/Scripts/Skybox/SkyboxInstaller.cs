using UnityEngine;

public class SkyboxInstaller : MonoBehaviour
{
    [SerializeField] private Material _skybox;

    private void Start()
    {
        RenderSettings.skybox = _skybox;
    }
}
