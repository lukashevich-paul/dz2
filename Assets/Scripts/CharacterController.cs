using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _rotateSpeed = 3f;
    [SerializeField] private float _scaleSpeed = 2f;
    [SerializeField] private float _minScale = 0.2f;
    [SerializeField] private float _maxScale = 3f;

    private void Update()
    {
        Move();
        Rotate();
        Scale();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        float distance = direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);

        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime * Vector3.up);
    }

    private void Scale()
    {
        float rotation = Input.GetAxis(Horizontal);
        float newValue = rotation * _scaleSpeed * Time.deltaTime;

        if (transform.localScale.x <= _minScale && newValue < 0f)
        {
            newValue = 0f;
        }
        else if (transform.localScale.x >= _maxScale && newValue > 0f)
        {
            newValue = 0f;
        }

        transform.localScale += new Vector3(newValue, newValue, newValue);
    }
}
