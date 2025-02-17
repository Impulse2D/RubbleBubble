using Localization;
using MainScene;
using Services;
using Skybox;
using SoundsPlayers;
using UnityEngine;

namespace EntryPoints
{
    public class EntryPointMainScene : MonoBehaviour
    {
        [SerializeField] private LanguageDefinition _languageDefinition;
        [SerializeField] private SkyboxInstaller _skyboxInstaller;
        [SerializeField] private LevelService _levelService;
        [SerializeField] private MainSceneBackgroundMusicPlayer _mainSceneBackgroundMusicPlayer;
        [SerializeField] private SoundsCustomizer _soundsCustomizer;
        [SerializeField] private MenuOpener _menuOpener;

        private void Start()
        {
            _languageDefinition.Init();
            _skyboxInstaller.Init();
            _levelService.Init();
            _soundsCustomizer.Init();
            _mainSceneBackgroundMusicPlayer.Init();
            _menuOpener.Init();
        }
    }
}
