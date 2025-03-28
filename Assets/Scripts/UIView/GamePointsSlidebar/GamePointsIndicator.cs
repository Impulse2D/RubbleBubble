using System;
using System.Collections;
using Points;
using UnityEngine;
using UnityEngine.UI;

namespace GamePointsSlidebar
{
    public class GamePointsIndicator : MonoBehaviour
    {
        [SerializeField] private GamePointsCounter _gamePointsCounter;
        [SerializeField] private Image Image;

        private float _currentValuePercentage;
        private Coroutine _coroutine;
        private float _minValueFillAmount;
        private float _maxValueFillAmount;
        private float _cuurentValueFillAmount;
        private float _valueTarget;
        private float _speedFillAmount;
        private float _delay;

        public event Action Filled;

        private void OnEnable()
        {
            ResetFillAmount();

            _gamePointsCounter.PointCounted += ShowFillAmount;
        }

        private void OnDisable()
        {
            _gamePointsCounter.PointCounted -= ShowFillAmount;
        }

        private void ShowFillAmount(float valuePoints)
        {
            CalculatePercentage(valuePoints);
            SetValueFillAmount(_currentValuePercentage);
        }

        private void ResetFillAmount()
        {
            _minValueFillAmount = 0f;
            Image.fillAmount = _minValueFillAmount;
        }

        private void CalculatePercentage(float valuePoints)
        {
            _currentValuePercentage = valuePoints / _gamePointsCounter.MaxQuantityGamePoints;
        }

        private void SetValueFillAmount(float valuePercentage)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ShiftSlowlyValueFillAmoun(valuePercentage));
        }

        private IEnumerator ShiftSlowlyValueFillAmoun(float valuePoints)
        {
            _maxValueFillAmount = 1f;
            _cuurentValueFillAmount = Image.fillAmount;
            _valueTarget = valuePoints;
            _speedFillAmount = 1f;
            _delay = 1f;

            for (float i = 0; i < _delay; i += _speedFillAmount * Time.deltaTime)
            {
                yield return null;

                Image.fillAmount = Mathf.Lerp(_cuurentValueFillAmount, _valueTarget, i);

                if (Image.fillAmount == _maxValueFillAmount)
                {
                    Filled?.Invoke();
                }
            }

            Image.fillAmount = _valueTarget;
        }
    }
}