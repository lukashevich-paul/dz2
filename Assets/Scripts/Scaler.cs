using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _minScale = 0.5f;
    [SerializeField] private float _maxScale = 2f;
    [SerializeField] private float _scaleSpeed = 2.5f;

    private float _targetScale;

    private void Start()
    {
        _targetScale = _maxScale;
    }

    private void Update()
    {
        Vector3 scale = transform.localScale;

        if (scale.x > _maxScale)
        {
            _targetScale = -_scaleSpeed;
        }
        else if (scale.x < _minScale)
        {
            _targetScale = _scaleSpeed;
        }

        float newValue = _targetScale * Time.deltaTime;
        Scale(newValue);
    }

    private void Scale(float value)
    {
        float newValue = _targetScale * Time.deltaTime;
        transform.localScale += new Vector3(value, value, value);
    }
}
