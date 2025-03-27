using System;
using System.Collections;
using UnityEngine;

namespace EffectsColoredBalls
{
    public class EffectColoredBall : MonoBehaviour
    {
        private Coroutine _coroutineCountLifeTime;
        private float _maxValueLifeTimeEffect;

        public event Action<EffectColoredBall> Released;

        private void OnEnable()
        {
            _maxValueLifeTimeEffect = 3f;

            if (_coroutineCountLifeTime != null)
            {
                StopCoroutine(_coroutineCountLifeTime);
            }

            StartCoroutine(CountLifeTime(_maxValueLifeTimeEffect));
        }

        private IEnumerator CountLifeTime(float time)
        {
            WaitForSeconds timeWait = new WaitForSeconds(time);

            yield return timeWait;

            Released?.Invoke(this);
        }
    }
}
