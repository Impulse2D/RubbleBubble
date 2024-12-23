using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    private int _quantity�ollisions;
    private int _minquantity�ollisions;

    private void OnEnable()
    {
        _minquantity�ollisions = 0;

        _quantity�ollisions = _minquantity�ollisions;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ColoredBall coloredBall))
        {
            if (coloredBall.Color == _bullet.Color)
            {
                if (_quantity�ollisions == _minquantity�ollisions)
                {
                    coloredBall.FallDown();

                    coloredBall.EnableIsCollision();

                    _minquantity�ollisions++;
                }
            }

            if (coloredBall.Color != _bullet.Color)
            {
                if (_quantity�ollisions == _minquantity�ollisions)
                {
                    Debug.Log("�������� �� ������� ��� �� ������ ����� - ����� ����");
                }
            }
        }

        if (collision.gameObject.TryGetComponent(out ColoredBallsDisabler disablerColoredBalls))
        {
            if (_bullet.IsMoved == true && _quantity�ollisions == _minquantity�ollisions)
            {
                Debug.Log("�������� ����� ��������, �� �� ���� ������������ - ����� ����");
            }
            else if (_bullet.IsMoved == true && _quantity�ollisions != _minquantity�ollisions)
            {
                Debug.Log("�������� ����� ��������, ���� ������������ � ����� ������ ����� - ���� ������������");
            }
            else if(_bullet.IsMoved == false)
            {
                Debug.Log("�������� ����� ����� ������� - ���� ������������");
            }

            _bullet.ReportRelease();
        }
    }
}
