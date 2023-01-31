using UnityEngine;

public sealed class GravityModifier : MonoBehaviour
{
    [SerializeField] float gravityScale;
    [SerializeField] float modifiedGravityScale;
    Rigidbody _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_rigid.velocity == Vector3.zero) return;
        Vector3 velocity = _rigid.velocity;
        if (velocity.y < 0)
            velocity.y -= modifiedGravityScale * Time.deltaTime;
        else
            velocity.y -= gravityScale * Time.deltaTime;
        _rigid.velocity = velocity;
    }
}
