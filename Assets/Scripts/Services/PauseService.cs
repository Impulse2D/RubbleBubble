using System;
using UnityEngine;

public class PauseService : ObjectsChanger
{
    [SerializeField] private TrajectoryVisualizer _trajectoryVisualizer;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CanvasMainUI _canvasMainUI;
    [SerializeField] private CanvasReloadBullets _canvasReloadBullets;

    private float _minValueTime = 0f;
    private float _maxValueTime = 1f;

    public event Action FocusNotDetected;

    public float MaxValueTime => _maxValueTime;

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false && IsPause() == false)
        {
            FocusNotDetected?.Invoke();
        }
    }

    public void Init()
    {
        if (IsPause() == true)
        {
            ÑhangeTime(_maxValueTime);
        }
    }

    public void EnablePause()
    {
        DisableObject(_trajectoryVisualizer.gameObject);
        DisableObject(_canvasReloadBullets.gameObject);
        DisableObject(_canvasMainUI.gameObject);
        DisableObject(_inputReader.gameObject);

        ÑhangeTime(_minValueTime);
    }

    public void DisablePause()
    {
        EnabledObject(_canvasReloadBullets.gameObject);
        EnabledObject(_canvasMainUI.gameObject);
        EnabledObject(_inputReader.gameObject);

        ÑhangeTime(_maxValueTime);
    }

    private void ÑhangeTime(float valueTime)
    {
        Time.timeScale = valueTime;
    }

    private bool IsPause()
    {
        return Time.timeScale < _maxValueTime;
    }
}
