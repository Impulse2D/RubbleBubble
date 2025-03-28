using System;
using UnityEngine;

namespace Services
{
    public class PauseService : MonoBehaviour
    {
        private float _minValueTime = 0f;
        private float _maxValueTime = 1f;

        public event Action FocusNotDetected;
        public event Action FocusOnPauseNotDetected;
        public event Action PauseEnabled;
        public event Action PauseDisabled;

        private void OnApplicationFocus(bool focus)
        {
            if (focus == false && IsPause() == false)
            {
                FocusNotDetected?.Invoke();
            }
            else if (focus == false)
            {
                FocusOnPauseNotDetected?.Invoke();
            }
        }

        public void Init()
        {
            if (IsPause() == true)
            {
                DisablePause();
                ReportDisablePause();
            }
        }

        public void EnablePause()
        {
            ÑhangeTime(_minValueTime);
            ReportEnabledPause();
        }

        public void DisablePause()
        {
            ÑhangeTime(_maxValueTime);
            ReportDisablePause();
        }

        private void ÑhangeTime(float valueTime)
        {
            Time.timeScale = valueTime;
        }

        private bool IsPause()
        {
            return Time.timeScale < _maxValueTime;
        }

        private void ReportEnabledPause()
        {
            PauseEnabled?.Invoke();
        }

        private void ReportDisablePause()
        {
            PauseDisabled?.Invoke();
        }
    }
}
