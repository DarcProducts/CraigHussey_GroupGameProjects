using UnityEngine;

public class MeshColliderSetter : MonoBehaviour
{
    public CreateOcean CreateOcean;
    public MeshCollider meshCollider;

    private void Start()
    {
        meshCollider.sharedMesh = CreateOcean.CreateOceanMesh();
    }
}
