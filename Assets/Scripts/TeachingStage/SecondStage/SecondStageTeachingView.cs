using System;
using FirstStage;
using TeachingStage;
using UnityEngine;

namespace SecondStage
{
    public class SecondStageTeachingView : StageTeaching
    {
        [SerializeField] private FirstStageTeachingView _firstStageTeachingView;
        [SerializeField] private CanvasSecondStageTeachingArrow _canvasSecondStageTeachingArrow;
        [SerializeField] private int _numberTeachingId;

        public event Action StageCompleted;

        private void OnEnable()
        {
            _numberTeachingId = 2;

            SetId(_numberTeachingId);

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
}
