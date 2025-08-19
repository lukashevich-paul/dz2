using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public const int MainDirection = 1;
    public const int ReversDirection = -1;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _oneWayDistance = 3f;

    private int _direction;
    private Vector3 _startPosition;

    private void Start()
    {
        _direction = MainDirection;
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (_oneWayDistance > 0f)
        {
            if (_oneWayDistance + _startPosition.z <= transform.position.z || transform.position.z <= -(_oneWayDistance + _startPosition.z))
            {
                _direction *= ReversDirection;
            }
        }

        transform.Translate(Vector3.forward * _speed * _direction * Time.deltaTime);
    }
}
