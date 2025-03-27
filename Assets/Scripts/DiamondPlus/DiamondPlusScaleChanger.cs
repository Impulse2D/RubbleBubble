using DG.Tweening;
using UnityEngine;

namespace Diamonds
{
    public class DiamondPlusScaleChanger : MonoBehaviour
    {
        private void OnEnable()
        {
            Vector3 defaultScaleDiamond = Vector3.one;

            transform.localScale = defaultScaleDiamond;

            IncreaseScaleDiamond();
        }

        private void IncreaseScaleDiamond()
        {
            Vector3 targetScaleDiamond = new Vector3(0f, 0f, 0f);

            float duractionDiamond = 0.9f;

            transform.DOScale(targetScaleDiamond, duractionDiamond);
        }
    }
}
