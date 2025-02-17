using System;
using System.Collections;
using UnityEngine;

namespace EffectsColoredBalls
{
    public class EffectColoredBall : MonoBehaviour
    {
        private Coroutine _coroutine;
        private float _maxValueLifeTime;

        public event Action<EffectColoredBall> Released;

        private void OnEnable()
        {
            _maxValueLifeTime = 3f;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            StartCoroutine(CoutLifeTime(_maxValueLifeTime));
        }

        private IEnumerator CoutLifeTime(float time)
        {
            WaitForSeconds timeWait = new WaitForSeconds(time);

            yield return timeWait;

            Released?.Invoke(this);
        }
    }
}
