using System;
using System.Collections;
using UnityEngine;

namespace EffectsColoredBalls
{
    public class EffectColoredBall : MonoBehaviour
    {
        [SerializeField] private float _maxValueLifeTimeEffect;

        private Coroutine _coroutineCountLifeTime;

        public event Action<EffectColoredBall> Released;

        private void OnEnable()
        {
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
