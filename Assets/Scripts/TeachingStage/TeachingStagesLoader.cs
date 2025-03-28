using AimingCancelTeaching;
using FirstStage;
using FourthStageViewTeaching;
using SecondStage;
using Services;
using Stage;
using UnityEngine;

namespace TeachingStage
{
    public class TeachingStagesLoader : MonoBehaviour
    {
        private const string CounterActivatedTeaching = nameof(CounterActivatedTeaching);

        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private LevelService _levelService;
        [SerializeField] private FirstStageTeachingView _firstStageTeachingView;
        [SerializeField] private SecondStageTeachingView _secondStageTeachingView;
        [SerializeField] private ThirdStageTeachingView _thirdStageTeachingView;
        [SerializeField] private FourthStageTeachingView _fourthStageTeachingView;
        [SerializeField] private AimingTeachingCancelingView _aimingCancelTeachingView;

        private int _maxNumberLevel;
        private int _maxQuantyCounterActivatedTeaching;

        public void Init()
        {
            TryLoadStagesTeaching();
            TryLoadAminigTeaching();
        }

        private void TryLoadStagesTeaching()
        {
            _maxNumberLevel = 1;

            if (_levelService.NumberLevel == _maxNumberLevel)
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
            _aimingCancelTeachingView.Init();

            if (_aimingCancelTeachingView.CounterTeaching < _maxQuantyCounterActivatedTeaching)
            {
                _objectsChangerService.EnableObject(_aimingCancelTeachingView.gameObject);
            }
        }
    }
}
