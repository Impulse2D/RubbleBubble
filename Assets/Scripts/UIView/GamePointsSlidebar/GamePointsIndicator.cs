using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePointsIndicator : MonoBehaviour
{
    [SerializeField] private GamePointsCounter _gamePointsCounter;
    [SerializeField] private Image Image;

    private float _currentValuePercentage;
    private Coroutine _coroutine;

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
        float minValueFillAmount = 0f;

        Image.fillAmount = minValueFillAmount;
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
        float maxValueFillAmount = 1f;
        float cuurentValueFillAmount = Image.fillAmount;
        float valueTarget = valuePoints;
        float speedFillAmount = 1f;
        float delay = 1f;

        for (float i = 0; i < delay; i += speedFillAmount * Time.deltaTime)
        {
            yield return null;

            Image.fillAmount = Mathf.Lerp(cuurentValueFillAmount, valueTarget, i);

            if (Image.fillAmount == maxValueFillAmount)
            {
                Filled?.Invoke();
            }
        }

        Image.fillAmount = valueTarget;
    }
}

