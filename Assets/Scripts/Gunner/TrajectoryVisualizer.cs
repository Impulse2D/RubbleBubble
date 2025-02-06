using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class TrajectoryVisualizer : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    public void Init()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        float divider = 2;
        float timeMultiplier = 0.1f;
        float minQuantityPoints = 0f;
        int indexPoint = 1;
        int quantityPoints = 40;
        int quantityDeductibleIndexesRenderingRestrictions = 3;
        int minIndexRenderingRestrictions = 2;
        float radius = 0.03f;


        Vector3[] points = new Vector3[quantityPoints];

        _lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * timeMultiplier;

            points[i] = origin + speed * time + Physics.gravity * time * time / divider;

            if (i > minIndexRenderingRestrictions)
            {
                RaycastHit raycastHit;

                Vector3 direction = points[points.Length - quantityDeductibleIndexesRenderingRestrictions] - points[i - quantityDeductibleIndexesRenderingRestrictions];

                if (Physics.SphereCast(points[i - quantityDeductibleIndexesRenderingRestrictions], radius, direction, out raycastHit))
                {
                    if (raycastHit.collider.gameObject.TryGetComponent(out GameplayParticipator gameplayParticipator))
                    {
                        SetPositionCount(i, indexPoint);

                        break;
                    }
                    else
                    {
                        if (points[i].y < minQuantityPoints)
                        {
                            SetPositionCount(i, indexPoint);

                            break;
                        }
                    }
                }
            }
        }

        _lineRenderer.SetPositions(points);
    }

    public void EnableLinear()
    {
        _lineRenderer.gameObject.SetActive(true);
    }

    public void DisableLinear()
    {
        _lineRenderer.gameObject.SetActive(false);
    }

    public void SetColor(Color color)
    {
        _lineRenderer.startColor = color;
    }

    private void SetPositionCount(int index, int indexPoint)
    {
        _lineRenderer.positionCount = index + indexPoint;
    }
}
