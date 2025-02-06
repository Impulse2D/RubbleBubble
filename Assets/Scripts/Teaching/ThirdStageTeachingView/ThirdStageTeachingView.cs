using System;
using UnityEngine;

public class ThirdStageTeachingView : StageTeaching
{
    [SerializeField] private FirstCanvasThirdStageTeaching _firstCanvasThirdStageTeaching;
    [SerializeField] private SecondCanvasThirdStageTeaching _secondCanvasThirdStageTeaching;
    [SerializeField] private SecondStageTeachingView _secondStageTeachingView;

    private int _counterClicks;

    public event Action StageCompleted;

    private void OnEnable()
    {
        int namberId = 3;

        SetId(namberId);

        _secondStageTeachingView.StageCompleted += Show;

        InputReader.ShootReleased += Hide;
    }

    private void OnDisable()
    {
        _secondStageTeachingView.StageCompleted -= Show;

        InputReader.ShootReleased -= Hide;
    }

    private void Show()
    {
        ObjectsChangerService.EnableObject(_firstCanvasThirdStageTeaching.gameObject);
        ObjectsChangerService.EnableObject(_secondCanvasThirdStageTeaching.gameObject);
    }

    private void Hide()
    {
        int maxQuantyClicks = 1;

        if (StagesTeachingService.NumberStage == Id)
        {
            _counterClicks++;

            if (_counterClicks > maxQuantyClicks)
            {
                ObjectsChangerService.DisableObject(_firstCanvasThirdStageTeaching.gameObject);
                ObjectsChangerService.DisableObject(_secondCanvasThirdStageTeaching.gameObject);

                StagesTeachingService.IncreaseNumberStage();

                StageCompleted?.Invoke();
            }
        }
    }
}
