using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    private int _quantityСollisions;
    private int _minquantityСollisions;

    private void OnEnable()
    {
        _minquantityСollisions = 0;

        _quantityСollisions = _minquantityСollisions;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ColoredBall coloredBall))
        {
            if (coloredBall.Color == _bullet.Color)
            {
                if (_quantityСollisions == _minquantityСollisions)
                {
                    coloredBall.FallDown();

                    coloredBall.EnableIsCollision();

                    _minquantityСollisions++;
                }
            }

            if (coloredBall.Color != _bullet.Color)
            {
                if (_quantityСollisions == _minquantityСollisions)
                {
                    Debug.Log("Ударился об цветной шар не своего цвета - Конец игры");
                }
            }
        }

        if (collision.gameObject.TryGetComponent(out ColoredBallsDisabler disablerColoredBalls))
        {
            if (_bullet.IsMoved == true && _quantityСollisions == _minquantityСollisions)
            {
                Debug.Log("ударился после выстрела, но не было столкновений - конец игры");
            }
            else if (_bullet.IsMoved == true && _quantityСollisions != _minquantityСollisions)
            {
                Debug.Log("ударился после выстрела, было столкновение с шаром своего цвета - игра продолжается");
            }
            else if(_bullet.IsMoved == false)
            {
                Debug.Log("ударился после смены снаряда - игра продолжается");
            }

            _bullet.ReportRelease();
        }
    }
}
