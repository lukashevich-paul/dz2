using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _minScale = 0.5f;
    [SerializeField] private float _maxScale = 2f;
    [SerializeField] private float _scaleSpeed = 2.5f;

    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = _maxScale;
    }

    private void Update()
    {
        Vector3 scale = transform.localScale;

        if (scale.x > _maxScale || scale.x < _minScale)
        {
            _currentSpeed *= -1;
        }

        float newValue = _currentSpeed * Time.deltaTime;
        transform.localScale += Vector3.one * newValue;
    }
}
