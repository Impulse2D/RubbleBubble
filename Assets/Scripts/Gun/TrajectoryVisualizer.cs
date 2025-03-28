using UnityEngine;

namespace Gun
{
    [RequireComponent(typeof(LineRenderer))]

    public class TrajectoryVisualizer : MonoBehaviour
    {
        [SerializeField] private float _divider = 2;
        [SerializeField] private float _timeMultiplier = 0.1f;
        [SerializeField] private int _indexPointTrajectory = 1;
        [SerializeField] private int _quantityPointsTrajectory = 40;
        [SerializeField] private int _quantityDeductibleIndexesRenderingRestrictions = 3;
        [SerializeField] private int _minIndexRenderingRestrictions = 2;
        [SerializeField] private float _radius = 0.03f;

        private LineRenderer _lineRendererTrajectory;

        public void Init()
        {
            _lineRendererTrajectory = GetComponent<LineRenderer>();
        }

        public void ShowTrajectory(Vector3 origin, Vector3 speed)
        {
            Vector3[] points = new Vector3[_quantityPointsTrajectory];

            _lineRendererTrajectory.positionCount = points.Length;

            for (int i = 0; i < points.Length; i++)
            {
                float time = i * _timeMultiplier;

                points[i] = origin + speed * time + Physics.gravity * time * time / _divider;

                if ((i > _minIndexRenderingRestrictions) == false) continue;

                RaycastHit raycastHit;

                Vector3 direction = points[points.Length - _quantityDeductibleIndexesRenderingRestrictions] -
                    points[i - _quantityDeductibleIndexesRenderingRestrictions];

                if (Physics.SphereCast(points[i - _quantityDeductibleIndexesRenderingRestrictions], _radius, direction, out raycastHit)
                    && IsComponentGameplayParticipator(raycastHit) == false) continue;

                SetPositionCount(i, _indexPointTrajectory);

                break;
            }

            _lineRendererTrajectory.SetPositions(points);
        }


        public void EnableLinear()
        {
            _lineRendererTrajectory.gameObject.SetActive(true);
        }

        public void DisableLinear()
        {
            _lineRendererTrajectory.gameObject.SetActive(false);
        }

        public void SetColor(Color color)
        {
            _lineRendererTrajectory.startColor = color;
        }

        private void SetPositionCount(int index, int indexPoint)
        {
            _lineRendererTrajectory.positionCount = index + indexPoint;
        }

        private bool IsComponentGameplayParticipator(RaycastHit raycastHit)
        {
            return raycastHit.collider.gameObject.TryGetComponent(out GameplayParticipator gameplayParticipator);
        }
    }
}
