using UnityEngine;

public class DestroyBelowWorld : MonoBehaviour
{
    [SerializeField] float maxYValue;

    private void FixedUpdate()
    {
        if (transform.position.y < maxYValue)
            Destroy(gameObject);
    }
}
