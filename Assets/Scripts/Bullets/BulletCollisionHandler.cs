using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    private bool _isOneColorCollision;

    public bool IsOneColorCollision => _isOneColorCollision;

    private void OnEnable()
    {
        _bullet.DisableCriticalCollision();

        DisableIsOneColorCollision();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ColoredBall coloredBall))
        {
            if (coloredBall.Color == _bullet.Color)
            {
                if (_isOneColorCollision == false)
                {
                    EnableIsOneColorCollision();

                    coloredBall.FallDown();

                    coloredBall.EnableIsCollision();
                }
            }

            if (coloredBall.Color != _bullet.Color)
            {
                if (_bullet.IsMoved == true && _isOneColorCollision == false)
                {
                    _bullet.EnableCriticalCollision();

                    _bullet.ReportCriticalCollisionDetected();

                    _bullet.DisableIsMoved();

                    Debug.Log("”дарилс€ об цветной шар не своего цвета -  онец игры");
                }
            }
        }

        if (collision.gameObject.TryGetComponent(out ColoredBallsDisabler disablerColoredBalls))
        {
            if (_bullet.IsMoved == true && _isOneColorCollision == false)
            {
                _bullet.EnableCriticalCollision();

                _bullet.ReportCriticalCollisionDetected();

                _bullet.DisableIsMoved();

                Debug.Log("ударилс€ после выстрела, но не было столкновений - конец игры");
            }
            else if (_bullet.IsMoved == true && _isOneColorCollision == true)
            {
                _bullet.ReportCriticalCollisionDetected();

                Debug.Log("ударилс€ после выстрела, было столкновение с шаром своего цвета - игра продолжаетс€");
            }
            else if (_bullet.IsMoved == false)
            {
                _bullet.ReportCriticalCollisionDetected();

                Debug.Log("ударилс€ после смены снар€да - игра продолжаетс€");
            }

            _bullet.ReportRelease();
        }
    }

    private void EnableIsOneColorCollision()
    {
        _isOneColorCollision = true;
    }

    private void DisableIsOneColorCollision()
    {
        _isOneColorCollision = false;
    }
}
