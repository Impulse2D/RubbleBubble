using System;
using TMPro;
using UnityEngine;

namespace Services
{
    public class LifeService : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textLives;
        [SerializeField] private int _minQuantitylives = 0;

        private int _quantitylives;

        public event Action LivesExhausted;

        public void Init()
        {
            ResetQuantitylives();
        }

        public void TryReduceQuantitylives()
        {
            _quantitylives--;

            if (_quantitylives <= _minQuantitylives)
            {
                _quantitylives = _minQuantitylives;

                SetQuantitylives(_textLives);

                LivesExhausted?.Invoke();
            }
            else
            {
                SetQuantitylives(_textLives);
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
}
