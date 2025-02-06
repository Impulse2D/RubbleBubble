using UnityEngine;

public class TeachingsViewsCloser : MonoBehaviour
{
    [SerializeField] private ObjectsChangerService _objectsChangerService;
    [SerializeField] private AimingCancelTeachingView _aimingCancelTeachingView;
    [SerializeField] private FirstStageTeachingView _firstStageTeachingView;
    [SerializeField] private SecondStageTeachingView _secondStageTeachingView;
    [SerializeField] private ThirdStageTeachingView _thirdStageTeachingView;
    [SerializeField] private FourthStageTeachingView _fourthStageTeachingView;

    private void OnEnable()
    {
        _aimingCancelTeachingView.TeachingCompleted += HideAimingCancelTeachingView;
        _firstStageTeachingView.StageCompleted += HideFirstStageTeachingView;
        _secondStageTeachingView.StageCompleted += HideSecondStageTeachingView;
        _thirdStageTeachingView.StageCompleted += HideThirdStageTeachingView;
        _fourthStageTeachingView.StageCompleted += HideFourthStageTeachingView;
    }

    private void OnDisable()
    {
        _aimingCancelTeachingView.TeachingCompleted -= HideAimingCancelTeachingView;
        _firstStageTeachingView.StageCompleted -= HideFirstStageTeachingView;
        _secondStageTeachingView.StageCompleted -= HideSecondStageTeachingView;
        _thirdStageTeachingView.StageCompleted -= HideThirdStageTeachingView;
        _fourthStageTeachingView.StageCompleted -= HideFourthStageTeachingView;
    }

    private void HideAimingCancelTeachingView()
    {
        _objectsChangerService.DisableObject(_aimingCancelTeachingView.gameObject);
    }

    private void HideFirstStageTeachingView()
    {
        _objectsChangerService.DisableObject(_firstStageTeachingView.gameObject);
    }

    private void HideSecondStageTeachingView()
    {
        _objectsChangerService.DisableObject(_secondStageTeachingView.gameObject);
    }

    private void HideThirdStageTeachingView()
    {
        _objectsChangerService.DisableObject(_thirdStageTeachingView.gameObject);
    }

    private void HideFourthStageTeachingView()
    {
        _objectsChangerService.DisableObject(_fourthStageTeachingView.gameObject);
    }
}
