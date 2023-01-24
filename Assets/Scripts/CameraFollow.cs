using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [Range(0f, 1f), SerializeField] float easing;

    private void FixedUpdate()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = Vector3.Lerp(currentPos, target.position, easing);
        transform.position = targetPos;
        Quaternion currentRot = transform.rotation;
        Quaternion targetRot = Quaternion.Lerp(currentRot, target.rotation, easing);
        transform.rotation = targetRot;
    }
}
