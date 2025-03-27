using UnityEngine;

namespace Gun
{
    [RequireComponent(typeof(LineRenderer))]

    public class TrajectoryVisualizer : MonoBehaviour
    {
        private LineRenderer _lineRendererTrajectory;

        public void Init()
        {
            _lineRendererTrajectory = GetComponent<LineRenderer>();
        }

        public void ShowTrajectory(Vector3 origin, Vector3 speed)
        {
            float divider = 2;
            float timeMultiplier = 0.1f;
            int indexPointTrajectory = 1;
            int quantityPointsTrajectory = 40;
            int quantityDeductibleIndexesRenderingRestrictions = 3;
            int minIndexRenderingRestrictions = 2;
            float radius = 0.03f;


            Vector3[] points = new Vector3[quantityPointsTrajectory];

            _lineRendererTrajectory.positionCount = points.Length;

            for (int i = 0; i < points.Length; i++)
            {
                float time = i * timeMultiplier;

                points[i] = origin + speed * time + Physics.gravity * time * time / divider;

                if (i > minIndexRenderingRestrictions)
                {
                    RaycastHit raycastHit;

                    Vector3 direction = points[points.Length - quantityDeductibleIndexesRenderingRestrictions] - 
                        points[i - quantityDeductibleIndexesRenderingRestrictions];

                    if (Physics.SphereCast(points[i - quantityDeductibleIndexesRenderingRestrictions], radius, direction, out raycastHit)
                        && IsComponentGameplayParticipator(raycastHit) == true)
                    {
                        SetPositionCount(i, indexPointTrajectory);

                        break;
                    }
                }
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
