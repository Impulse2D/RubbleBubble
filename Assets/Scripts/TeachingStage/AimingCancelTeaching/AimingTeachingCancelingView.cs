using System;
using AimingCanceling;
using Services;
using TeachingStage;
using UnityEngine;
using YG;

namespace AimingCancelTeaching
{
    public class AimingTeachingCancelingView : MonoBehaviour
    {
        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private CanvasAimingTeachingMobile _canvasAimingTeachingMobile;
        [SerializeField] private CanvasAimingTeachingDesktop _canvasAimingTeachingDesktop;
        [SerializeField] private CanvasActiveAimingTeachingMobile _canvasActiveAimingTeachingMobile;
        [SerializeField] private CanvasActiveAimingTeachingDesktop _canvasActiveAimingTeachingDesktop;
        [SerializeField] private AimingCancelersViewsChanger _aimingCancelersViewsChanger;
        [SerializeField] private DeviceTypeDetector _deviceTypeDetector;
        [SerializeField] private LevelService _levelService;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] int _minValueNumberLevel = 1;
        [SerializeField] int _minQuantyActivatedTeachings = 0;

        private int _counterActivatedTeaching;
        private int _maxQuantyActivatedTeachings = 1;
        private bool _enableAimingCancelActivePanel;

        public event Action TeachingCompleted;

        public int CounterTeaching => _counterActivatedTeaching;

        private void OnEnable()
        {
            _aimingCancelersViewsChanger.ButtonShowed += TryEnableAimingCancelArmTeaching;
            _aimingCancelersViewsChanger.PanelShowed += TryEnableAimingCancelActivePanel;
            _aimingCancelersViewsChanger.PanelShowed += HideIndicatorsTeaching;
            _aimingCancelersViewsChanger.PanelCanceled += HideIndicatorsTeaching;
            _aimingCancelersViewsChanger.PanelCanceled += HideIndicatorsActivePanel;

            _inputReader.AimingCanceled += IncreaseResetCounterActivatedTeaching;
        }

        private void OnDisable()
        {
            _aimingCancelersViewsChanger.ButtonShowed -= TryEnableAimingCancelArmTeaching;
            _aimingCancelersViewsChanger.PanelShowed -= TryEnableAimingCancelActivePanel;
            _aimingCancelersViewsChanger.PanelShowed -= HideIndicatorsTeaching;
            _aimingCancelersViewsChanger.PanelCanceled -= HideIndicatorsActivePanel;
            _aimingCancelersViewsChanger.PanelCanceled -= HideIndicatorsTeaching;

            _inputReader.AimingCanceled -= IncreaseResetCounterActivatedTeaching;
        }

        public void Init()
        {
            _counterActivatedTeaching = YandexGame.savesData.counterActivatedTeaching;

            _enableAimingCancelActivePanel = false;

            TryResetCounterActivatedTeaching();
        }

        private void IncreaseResetCounterActivatedTeaching()
        {
            _counterActivatedTeaching = _maxQuantyActivatedTeachings;

            SetSavedCounterActivatedTeaching(_counterActivatedTeaching);

            TeachingCompleted?.Invoke();
        }

        private void TryResetCounterActivatedTeaching()
        {
            if (_levelService.NumberLevel == _minValueNumberLevel)
            {
                _counterActivatedTeaching = _minQuantyActivatedTeachings;

                SetSavedCounterActivatedTeaching(_counterActivatedTeaching);
            }
        }

        private void SetSavedCounterActivatedTeaching(int counterActivatedTeaching)
        {
            YandexGame.savesData.counterActivatedTeaching = counterActivatedTeaching;
        }

        private void TryEnableAimingCancelArmTeaching()
        {
            if ((IsMaxQuantyActivatedTeaching() == true && _enableAimingCancelActivePanel == false) == false)
                return;

            if (IsMobileDevice() == true)
            {
                ShowArm();
            }
            else
            {
                ShowMouse();
            }
        }

        private void TryEnableAimingCancelActivePanel()
        {
            SetIsEnableAimingCancelActivePanel(true);

            if (IsMaxQuantyActivatedTeaching() == false)
                return;

            if (IsMobileDevice() == true)
            {
                ShowCanvasActivePanelMobile();
            }
            else
            {
                ShowCanvasActivePanelDesktop();
            }
        }

        private void ShowArm()
        {
            _objectsChangerService.EnableObject(_canvasAimingTeachingMobile.gameObject);
        }

        private void ShowMouse()
        {
            _objectsChangerService.EnableObject(_canvasAimingTeachingDesktop.gameObject);
        }

        private void ShowCanvasActivePanelMobile()
        {
            _objectsChangerService.EnableObject(_canvasActiveAimingTeachingMobile.gameObject);
        }

        private void ShowCanvasActivePanelDesktop()
        {
            _objectsChangerService.EnableObject(_canvasActiveAimingTeachingDesktop.gameObject);
        }

        private void HideIndicatorsTeaching()
        {
            _objectsChangerService.DisableObject(_canvasAimingTeachingMobile.gameObject);
            _objectsChangerService.DisableObject(_canvasAimingTeachingDesktop.gameObject);
        }

        private void HideIndicatorsActivePanel()
        {
            _objectsChangerService.DisableObject(_canvasActiveAimingTeachingMobile.gameObject);
            _objectsChangerService.DisableObject(_canvasActiveAimingTeachingDesktop.gameObject);

            SetIsEnableAimingCancelActivePanel(false);
        }

        private bool IsMaxQuantyActivatedTeaching()
        {
            return _counterActivatedTeaching < _maxQuantyActivatedTeachings;
        }

        private bool IsMobileDevice()
        {
            return _deviceTypeDetector.IsMobileDevice;
        }

        private void SetIsEnableAimingCancelActivePanel(bool isEnableAimingCancelActivePanel)
        {
            _enableAimingCancelActivePanel = isEnableAimingCancelActivePanel;
        }
    }
}