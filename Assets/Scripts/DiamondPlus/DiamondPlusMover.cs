using DG.Tweening;
using System;
using UnityEngine;

namespace Diamonds
{
    public class DiamondPlusMover : MonoBehaviour
    {
        public event Action<DiamondPlusMover> DiamondReleased;

        public void Move(Vector3 targetPosition)
        {
            float duractionMoving = 2f;

            transform.DOMove(targetPosition, duractionMoving).onComplete = ReportReleased;
        }

        private void ReportReleased()
        {
            DiamondReleased?.Invoke(this);
        }
    }
}