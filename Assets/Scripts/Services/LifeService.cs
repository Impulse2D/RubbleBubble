using System;
using TMPro;
using UnityEngine;

public class LifeService : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textLives;

    private int _quantitylives;

    public event Action LivesExhausted;

    public void Init()
    {
        ResetQuantitylives();
    }

    public void TryReduceQuantitylives()
    {
        int _minQuantitylives = 0;

        _quantitylives--;

        if (_quantitylives > _minQuantitylives)
        {
            SetQuantitylives(_textLives);
        }
        
        if(_quantitylives <= _minQuantitylives)
        {
            LivesExhausted?.Invoke();

            ResetQuantitylives();
        }
    }

    public void ResetQuantitylives()
    {
        _quantitylives = 3;

        SetQuantitylives(_textLives);
    }

    private void SetQuantitylives(TextMeshProUGUI textLives)
    {
        textLives.text = _quantitylives.ToString();
    }
}
