using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] float forceRotateSpeed;
    Vector3 rotateVector;
    [SerializeField] float maxRotateDegrees;
    Vector3 _originalRotation;

    private void Start()
    {
        _originalRotation = transform.rotation.eulerAngles;
        rotateVector.y = 1;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D))
        {
            float moveDirX = Input.GetAxis("Horizontal");
            transform.Rotate(forceRotateSpeed * Time.deltaTime * new Vector3(0, moveDirX, 0).normalized);
            return;
        }
        float currentAngle = transform.rotation.eulerAngles.y;
        if (currentAngle < _originalRotation.y - maxRotateDegrees)
            rotateVector.y = 1;
        if (currentAngle > _originalRotation.y + maxRotateDegrees)
            rotateVector.y = -1;
        transform.Rotate(rotateSpeed * Time.deltaTime * rotateVector.normalized);
    }
}
