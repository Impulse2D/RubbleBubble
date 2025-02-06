using System;
using UnityEngine;

public class FirstStageTeachingView : StageTeaching
{
    [SerializeField] private DeviceTypeDetector _deviceTypeDetector;
    [SerializeField] private CanvasFirstStageTeachingMobile _canvasFirstStageTeachingMobile;
    [SerializeField] private CanvasFirstStageTeachingDesktop _canvasFirstStageTeachingDesktop;
    [SerializeField] private CanvasFirstStageArrow _canvasFirstStageArrow;
    [SerializeField] private LevelService _levelService;

    public event Action StageCompleted;

    private void OnEnable()
    {
        int namberId = 1;

        SetId(namberId);

        InputReader.AimingEnabled += Hide;
    }

    private void OnDisable()
    {
        InputReader.AimingEnabled -= Hide;
    }

    public void Init()
    {
        TryEnableTeaching();

        ShowArrow();
    }

    private void TryEnableTeaching()
    {
        if (_deviceTypeDetector.IsMobileDevice == true)
        {
            ShowMobileTeaching();
        }
        else
        {
            ShowDesktopTeaching();
        }
    }

    private void ShowMobileTeaching()
    {
        ObjectsChangerService.EnableObject(_canvasFirstStageTeachingMobile.gameObject);
    }

    private void ShowDesktopTeaching()
    {
        ObjectsChangerService.EnableObject(_canvasFirstStageTeachingDesktop.gameObject);
    }

    private void ShowArrow()
    {
        ObjectsChangerService.EnableObject(_canvasFirstStageArrow.gameObject);
    }

    private void Hide()
    {
        if (StagesTeachingService.NumberStage == Id)
        {
            ObjectsChangerService.DisableObject(_canvasFirstStageTeachingMobile.gameObject);
            ObjectsChangerService.DisableObject(_canvasFirstStageTeachingDesktop.gameObject);
            ObjectsChangerService.DisableObject(_canvasFirstStageArrow.gameObject);

            StagesTeachingService.IncreaseNumberStage();

            StageCompleted?.Invoke();
        }
    }
}
