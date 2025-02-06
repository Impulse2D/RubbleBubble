using UnityEngine;

public class TeachingStagesLoader : MonoBehaviour
{
    private const string CounterActivatedTeaching = nameof(CounterActivatedTeaching);

    [SerializeField] private ObjectsChangerService _objectsChangerService;
    [SerializeField] private LevelService _levelService;
    [SerializeField] private FirstStageTeachingView _firstStageTeachingView;
    [SerializeField] private SecondStageTeachingView _secondStageTeachingView;
    [SerializeField] private ThirdStageTeachingView _thirdStageTeachingView;
    [SerializeField] private FourthStageTeachingView _fourthStageTeachingView;
    [SerializeField] private AimingCancelTeachingView _aimingCancelTeachingView;

    public void Init()
    {
        TryLoadStagesTeaching();

        TryLoadAminigTeaching();
    }

    private void TryLoadStagesTeaching()
    {
        int maxNumberLevel = 1;

        if (_levelService.NumberLevel == maxNumberLevel)
        {
            _objectsChangerService.EnableObject(_firstStageTeachingView.gameObject);
            _objectsChangerService.EnableObject(_secondStageTeachingView.gameObject);
            _objectsChangerService.EnableObject(_thirdStageTeachingView.gameObject);
            _objectsChangerService.EnableObject(_fourthStageTeachingView.gameObject);

            _firstStageTeachingView.Init();
        }
    }

    private void TryLoadAminigTeaching()
    {
        int maxQuantyCounterActivatedTeaching = 1;

        _aimingCancelTeachingView.Init();

        if (_aimingCancelTeachingView.CounterTeaching < maxQuantyCounterActivatedTeaching)
        {
            _objectsChangerService.EnableObject(_aimingCancelTeachingView.gameObject);
        }
    }
}
