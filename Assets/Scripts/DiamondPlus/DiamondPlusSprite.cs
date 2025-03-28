using UnityEngine;
using UnityEngine.UI;

namespace Diamonds
{
    public class DiamondPlusSprite : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Color _transparent—olor;
        [SerializeField] private Color _defaultColor;

        public Image Image => _image;
        public Color Color => _transparent—olor;

        private void OnEnable()
        {
            _image.color = _defaultColor;
        }
    }
}
