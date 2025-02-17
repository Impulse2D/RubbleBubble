using UnityEngine;
using DG.Tweening;
using System;

namespace Diamonds
{
    public class DiamondPlusMover : MonoBehaviour
    {
        public event Action<DiamondPlusMover> Released;

        public void Move(Vector3 targetPosition)
        {
            float duraction = 2f;

            transform.DOMove(targetPosition, duraction).onComplete = ReportReleased;
        }

        private void ReportReleased()
        {
            Released?.Invoke(this);
        }
    }
}
