using System;
using TMPro;
using UnityEngine;

namespace Services
{
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
            int minQuantitylives = 0;

            _quantitylives--;

            if (_quantitylives <= minQuantitylives)
            {
                _quantitylives = 0;

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
