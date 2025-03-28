using System;
using SecondStage;
using TeachingStage;
using UnityEngine;

namespace Stage
{
    public class ThirdStageTeachingView : StageTeaching
    {
        [SerializeField] private FirstCanvasThirdStageTeaching _firstCanvasThirdStageTeaching;
        [SerializeField] private SecondCanvasThirdStageTeaching _secondCanvasThirdStageTeaching;
        [SerializeField] private SecondStageTeachingView _secondStageTeachingView;
        [SerializeField] private int _numberTeachingId;

        private int _counterClicks;

        public event Action StageCompleted;

        private void OnEnable()
        {
            _numberTeachingId = 3;
            SetId(_numberTeachingId);

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

            if (StagesTeachingService.NumberStage != Id)
                return;

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