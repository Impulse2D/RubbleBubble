using ColoredBalls;
using UnityEngine;

public class LayerMaskResidentSpherDisabler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ColoredBall coloredBall))
        {
            coloredBall.DisableLayerMaskResidentSphere();
        }
    }
}
