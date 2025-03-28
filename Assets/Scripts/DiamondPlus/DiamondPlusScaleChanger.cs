using DG.Tweening;
using UnityEngine;

namespace Diamonds
{
    public class DiamondPlusScaleChanger : MonoBehaviour
    {
        [SerializeField] private Vector3 _targetScaleDiamond;
        [SerializeField] private float _duractionDiamond;

        private void OnEnable()
        {
            Vector3 defaultScaleDiamond = Vector3.one;
            transform.localScale = defaultScaleDiamond;

            IncreaseScaleDiamond();
        }

        private void IncreaseScaleDiamond()
        {
            transform.DOScale(_targetScaleDiamond, _duractionDiamond);
        }
    }
}
