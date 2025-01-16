using UnityEngine;

public class SkyboxInstaller : MonoBehaviour
{
    [SerializeField] private Material _skybox;

    public void Init()
    {
        RenderSettings.skybox = _skybox;
    }
}
