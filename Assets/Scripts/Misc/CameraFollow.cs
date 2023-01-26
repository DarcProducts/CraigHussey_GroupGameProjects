using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] AnimationCurve easing;

    private void FixedUpdate()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = Vector3.Lerp(currentPos, target.position, easing.Evaluate(Time.deltaTime));
        transform.position = targetPos;
        Quaternion currentRot = transform.rotation;
        Quaternion targetRot = Quaternion.Lerp(currentRot, target.rotation, easing.Evaluate(Time.deltaTime));
        transform.rotation = targetRot;
    }
}
