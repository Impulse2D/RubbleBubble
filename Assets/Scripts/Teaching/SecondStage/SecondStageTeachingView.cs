using System;
using UnityEngine;

public class SecondStageTeachingView : StageTeaching
{
    [SerializeField] private FirstStageTeachingView _firstStageTeachingView;
    [SerializeField] private CanvasSecondStageTeachingArrow _canvasSecondStageTeachingArrow;

    public event Action StageCompleted;

    private void OnEnable()
    {
        int namberId = 2;

        SetId(namberId);

        _firstStageTeachingView.StageCompleted += Show;
        InputReader.ShootReleased += Hide;
    }

    private void OnDisable()
    {
        _firstStageTeachingView.StageCompleted -= Show;
        InputReader.ShootReleased -= Hide;
    }

    private void Show()
    {
        ObjectsChangerService.EnableObject(_canvasSecondStageTeachingArrow.gameObject);
    }

    private void Hide()
    {
        if (StagesTeachingService.NumberStage == Id)
        {
            ObjectsChangerService.DisableObject(_canvasSecondStageTeachingArrow.gameObject);

            StagesTeachingService.IncreaseNumberStage();

            StageCompleted?.Invoke();
        }
    }
}
