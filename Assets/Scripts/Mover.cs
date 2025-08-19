using UnityEngine;

public class Mover : MonoBehaviour
{
    public const int MainDirection = 1;
    public const int ReversDirection = -1;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _oneWayDistance = 3f;

    private float _distance;
    private int _direction;

    private void Start()
    {
        _distance = 0;
        _direction = MainDirection;
    }

    private void Update()
    {
        Vector3 position = transform.position;
        float move = _speed * Time.deltaTime * _direction;

        _distance += move;

        if (_oneWayDistance <= _distance || _distance <= -_oneWayDistance)
        {
            _direction *= ReversDirection;
        }

        position.z += move;
        transform.position = position;
    }
}
