using DG.Tweening;
using UnityEngine;

namespace Diamonds
{
    public class DiamondPlusScaleChanger : MonoBehaviour
    {
        private void OnEnable()
        {
            Vector3 defaultScale = Vector3.one;

            transform.localScale = defaultScale;

            IncreaseScale();
        }

        private void IncreaseScale()
        {
            Vector3 targetScale = new Vector3(0f, 0f, 0f);

            float duraction = 0.9f;

            transform.DOScale(targetScale, duraction);
        }
    }
}
