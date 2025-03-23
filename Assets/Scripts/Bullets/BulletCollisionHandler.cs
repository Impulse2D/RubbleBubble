using ColoredBalls;
using UnityEngine;

namespace Bullets
{
    public class BulletCollisionHandler : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;

        private void OnEnable()
        {
            _bullet.DisableCriticalCollision();

            _bullet.DisableIsOneColorCollision();

            _bullet.DisableIsBallCollision();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ColoredBall coloredBall))
            {
                _bullet.EnableIsBallCollision();

                if (coloredBall.Color == _bullet.Color)
                {
                    _bullet.EnableIsOneColorCollision();

                    coloredBall.FallDown();

                    coloredBall.EnableIsCollision();
                }

                if (coloredBall.Color != _bullet.Color)
                {
                    if (_bullet.IsMoved == true && _bullet.IsOneColorCollision == false)
                    {
                        _bullet.EnableCriticalCollision();

                        _bullet.DisableIsMoved();

                        Debug.Log("”дарилс€ об цветной шар не своего цвета -  онец игры");
                    }
                }

                _bullet.ReportCollisionDetected();
            }

            if (collision.gameObject.TryGetComponent(out ColoredBallsDisabler disablerColoredBalls))
            {
                _bullet.DisableIsBallCollision();

                if (_bullet.IsMoved == true && _bullet.IsOneColorCollision == false)
                {
                    _bullet.EnableCriticalCollision();

                    _bullet.DisableIsMoved();

                    Debug.Log("ударилс€ после выстрела, но не было столкновений - конец игры");
                }
                else if (_bullet.IsMoved == true && _bullet.IsOneColorCollision == true)
                {
                    Debug.Log("ударилс€ после выстрела, было столкновение с шаром своего цвета - игра продолжаетс€");
                }
                else if (_bullet.IsMoved == false)
                {
                    Debug.Log("ударилс€ после смены снар€да - игра продолжаетс€");
                }

                _bullet.ReportCollisionDetected();

                _bullet.ReportRelease();
            }
        }
    }
}