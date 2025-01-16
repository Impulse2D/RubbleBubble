using UnityEngine;
using UnityEngine.UI;

public class DiamondPlusSprite : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _transparent—olor;

    public Image Image => _image;
    public Color Color => _transparent—olor;

    private void OnEnable()
    {
        Color defaultColor = new Color(255f, 255f, 255f, 255f);

        _image.color = defaultColor;
    }
}
