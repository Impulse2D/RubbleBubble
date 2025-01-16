using UnityEngine;

public class EntryPointMainScene : MonoBehaviour
{
    [SerializeField] private SkyboxInstaller _skyboxInstaller;
    [SerializeField] private LevelService _levelService;

    private void Start()
    {
        _skyboxInstaller.Init();
        _levelService.Init();
    }
}
