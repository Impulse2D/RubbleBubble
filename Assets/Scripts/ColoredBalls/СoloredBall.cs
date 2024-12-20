using System;
using System.Collections;
using UnityEngine;

public class ColoredBall : Ball
{
    private LayerSphere _currentLayerSphere;
    private bool _isCollision;
    private Coroutine _coroutine;
    private float _delayCoroutine;

    public event Action<ColoredBall> CollisionDetected;
    public event Action<ColoredBall> Released;
    public event Action<ColoredBall> Deactivated;

    public LayerSphere LayerSphere => _currentLayerSphere;
    public bool IsCollision => _isCollision;

    private void OnDisable()
    {
        _isCollision = false;

        Deactivated?.Invoke(this);
    }

    public void TryFallDown()
    {
        if (_currentLayerSphere != null)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(FallDown(_delayCoroutine));
        }
    }

    public void SetDelayCoroutine(float delay)
    {
        _delayCoroutine = delay;
    }

    public void SetLayerSphere(LayerSphere layerSphere)
    {
        _currentLayerSphere = layerSphere;
    }

    public void EnableIsCollision()
    {
        _isCollision = true;

        CollisionDetected?.Invoke(this);
    }

    private IEnumerator FallDown(float delay)
    {
        WaitForSeconds timeWait = new WaitForSeconds(delay);

        yield return timeWait;

        transform.SetParent(null);

        DisableKinematic();

        _currentLayerSphere.RemoveColoredBall(this);

        Released?.Invoke(this);

        ResetDelayCoroutine();
    }

    private void ResetDelayCoroutine()
    {
        float minValueDelayCoroutine = 0f;

        _delayCoroutine = minValueDelayCoroutine;
    }
}
