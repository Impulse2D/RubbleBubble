using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private LevelService _levelService;
    [SerializeField] private PauseService _pauseService;
    [SerializeField] private LifeService _lifeService;
    [SerializeField] private AdFullscreenOpener _adFullscreenOpener;
    [SerializeField] private LeaderBoardService _leaderBoardService;
    [SerializeField] private GamePointsCounter _gamePointsCounter;
    [SerializeField] private SkyboxInstaller _skyboxInstaller;
    [SerializeField] private SkyboxRotator _skyboxRotator;
    [SerializeField] private MaterialsDispenser _materialsDispenser;
    [SerializeField] private LayersSphereScaleIncreaser _layersSphereScaleIncreaser;
    [SerializeField] private SpawnerColoredBalls _spawnerColoredBalls;
    [SerializeField] private SpawnerParentSphere _spawnerParentSpheres;
    [SerializeField] private Gunner _gunner;
    [SerializeField] private TrajectoryVisualizer _trajectoryVisualizer;
    [SerializeField] private BulletsReloader _bulletsReloader;

    private void Start()
    {
        _levelService.Init();
        _pauseService.Init();
        _lifeService.Init();
        _adFullscreenOpener.Init();
        _leaderBoardService.Init();
        _skyboxInstaller.Init();
        _skyboxRotator.Init();
        _gamePointsCounter.Init();
        _materialsDispenser.Init();
        _layersSphereScaleIncreaser.Init();
        _spawnerColoredBalls.Init();
        _spawnerParentSpheres.Init();
        _gunner.Init();
        _trajectoryVisualizer.Init();
        _bulletsReloader.Init();
    }
}
