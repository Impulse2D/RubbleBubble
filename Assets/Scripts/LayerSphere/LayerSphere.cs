using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSphere : MonoBehaviour
{
    private List<ColoredBall> _coloredBalls;
    private Coroutine _coroutine;
    private float _identifier;
    private float _speedIncreaseScale;

    public event Action<LayerSphere> ColoredBallsLosted;
    public event Action<LayerSphere> Released;

    public float Identifier => _identifier;
    public List<ColoredBall> ColoredBalls => _coloredBalls;

    private void OnEnable()
    {
        float startScaleX = 0.7f;
        float startScaleY = 0.7f;
        float startScaleZ = 0.7f;

        _coloredBalls = new List<ColoredBall>();

        Vector3 defaultScale = new Vector3(startScaleX, startScaleY, startScaleZ);

        SetDefaultScale(defaultScale);

        _identifier = 0f;
        _speedIncreaseScale = 1f;
    }

    public void IncreaseIdentifier()
    {
        _identifier++;
    }

    public void AddColoredBall(ColoredBall coloredBall)
    {
        _coloredBalls.Add(coloredBall);
    }

    public void RemoveColoredBall(ColoredBall coloredBall)
    {
        float minQuantityColoredBalls = 0f;

        _coloredBalls.Remove(coloredBall);

        if (_coloredBalls.Count == minQuantityColoredBalls)
        {
            ColoredBallsLosted?.Invoke(this);
        }
    }

    public void IncreaseScale(Vector3 targetScale)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ReachTargetScale(targetScale));
    }

    public void ReportReleased()
    {
        Released?.Invoke(this);
    }

    private IEnumerator ReachTargetScale(Vector3 targetScale)
    {
        while (transform.localScale != targetScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, _speedIncreaseScale * Time.deltaTime);

            yield return null;
        }
    }

    private void SetDefaultScale(Vector3 scale)
    {
        transform.localScale = scale;
    }
}
