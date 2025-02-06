using System;
using UnityEngine;

public class FourthStageTeachingView : StageTeaching
{
    [SerializeField] private FirstCanvasFourthStageTeaching _firstCanvasFourthStageTeaching;
    [SerializeField] private SecondCanvasFourthStageTeaching _secondCanvasFourthStageTeaching;
    [SerializeField] private ThirdStageTeachingView _thirdStageTeachingView;

    private int _counterClicks;

    public event Action StageCompleted;

    private void OnEnable()
    {
        int namberId = 4;

        SetId(namberId);

        _thirdStageTeachingView.StageCompleted += Show;
        InputReader.ShootReleased += Hide;
    }

    private void OnDisable()
    {
        _thirdStageTeachingView.StageCompleted -= Show;
        InputReader.ShootReleased -= Hide;
    }

    private void Show()
    {
        ObjectsChangerService.EnableObject(_firstCanvasFourthStageTeaching.gameObject);
        ObjectsChangerService.EnableObject(_secondCanvasFourthStageTeaching.gameObject);
    }

    private void Hide()
    {
        int maxQuantyClicks = 1;

        if (StagesTeachingService.NumberStage == Id)
        {
            _counterClicks++;

            if (_counterClicks > maxQuantyClicks)
            {
                ObjectsChangerService.DisableObject(_firstCanvasFourthStageTeaching.gameObject);
                ObjectsChangerService.DisableObject(_secondCanvasFourthStageTeaching.gameObject);

                StagesTeachingService.IncreaseNumberStage();

                StageCompleted?.Invoke();
            }
        }
    }
}
