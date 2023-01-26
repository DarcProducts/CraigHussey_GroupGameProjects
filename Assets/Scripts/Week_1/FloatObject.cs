using UnityEngine;

public class FloatObject : MonoBehaviour
{
    [SerializeField] Vector3 spherecastOffset;
    [SerializeField] float velocityDecreaseRate = .1f;
    [SerializeField] float maxDistance;
    [SerializeField] float pushbackForce;
    [SerializeField] LayerMask oceanLayer;
    Vector3 targetLocation;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > 0)
            rb.velocity = new(rb.velocity.x, rb.velocity.y - velocityDecreaseRate);
        if (Physics.Raycast(transform.position + spherecastOffset, Vector3.up, out RaycastHit hitInfo, Mathf.Infinity, oceanLayer))
        {
            targetLocation = hitInfo.point;
            if (Vector3.Distance(hitInfo.point, transform.position) > maxDistance)
                rb.AddForce(pushbackForce * Time.deltaTime * Vector3.up);
        }
    }

   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, targetLocation);
    }
}
