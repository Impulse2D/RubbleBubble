using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private LevelService _levelService;
    [SerializeField] private PauseService _pauseService;
    [SerializeField] private LifeService _lifeService;
    [SerializeField] private LevelsBackgroundMusicPlayer _backgroundMusicPlayer;
    [SerializeField] private LeaderBoardService _leaderBoardService;
    [SerializeField] private GamePointsCounter _gamePointsCounter;
    [SerializeField] private SkyboxInstaller _skyboxInstaller;
    [SerializeField] private SoundsCustomizer _soundsCustomizer;
    [SerializeField] private MaterialsDispenser _materialsDispenser;
    [SerializeField] private LayersSphereScaleIncreaser _layersSphereScaleIncreaser;
    [SerializeField] private SpawnerColoredBalls _spawnerColoredBalls;
    [SerializeField] private SpawnerParentSphere _spawnerParentSpheres;
    [SerializeField] private Gunner _gunner;
    [SerializeField] private TrajectoryVisualizer _trajectoryVisualizer;
    [SerializeField] private BulletsReloader _bulletsReloader;
    [SerializeField] private DeviceTypeDetector _deviceTypeDetector;
    [SerializeField] private StagesTeachingService _stagesTeachingService;
    [SerializeField] private TeachingStagesLoader _teachingStagesLoader;

    private void Start()
    {
        _deviceTypeDetector.Init();
        _levelService.Init();
        _pauseService.Init();
        _lifeService.Init();
        _backgroundMusicPlayer.Init();
        _leaderBoardService.Init();
        _skyboxInstaller.Init();
        _soundsCustomizer.Init();
        _gamePointsCounter.Init();
        _materialsDispenser.Init();
        _layersSphereScaleIncreaser.Init();
        _spawnerColoredBalls.Init();
        _spawnerParentSpheres.Init();
        _gunner.Init();
        _trajectoryVisualizer.Init();
        _bulletsReloader.Init();
        _stagesTeachingService.Init();
        _teachingStagesLoader.Init();
    }
}
