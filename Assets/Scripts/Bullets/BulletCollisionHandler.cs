using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ColoredBall coloredBall))
        {
            if (coloredBall.Color == _bullet.Color)
            {
                coloredBall.EnableIsCollision();

                _bullet.ReportRelease();
            }
            else
            {
                _bullet.ReportRelease();

                Debug.Log("Это событие для Game Over");
            }
        }

        if (collision.gameObject.TryGetComponent(out ColoredBallsDisabler disablerColoredBalls))
        {
            _bullet.ReportRelease();

            if (_bullet.IsMoved == true)
            {
                Debug.Log("Это событие для Game Over");
            }
        }
    }
}
