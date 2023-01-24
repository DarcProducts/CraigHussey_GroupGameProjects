using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class Ocean : MonoBehaviour
{
    [SerializeField] CreateOcean createOcean;
    [SerializeField] Vector3 offset; 
    MeshRenderer meshRenderer;
    Mesh mesh;

    public GameObject boat;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        mesh = createOcean.CreateOceanMesh();
    }

    void FixedUpdate()
    {
        float wavelength = meshRenderer.material.GetFloat("_Wavelength");
        float waveHeight = meshRenderer.material.GetFloat("_WaveHeight");
        float speed = meshRenderer.material.GetFloat("_Speed");
        float time = Time.time;
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            float x = vertices[i].x * wavelength + speed * time;
            float y = vertices[i].y * wavelength + speed * time;
            vertices[i].y += waveHeight * Mathf.Sin(x + y);
        }
        //mesh.vertices = vertices;

        // Create a native array to store the vertices
        NativeArray<Vector3> nativeVertices = new(vertices, Allocator.Persistent);
        // Create a native array to store the closest vertex index
        NativeArray<int> closestVertices = new(1, Allocator.Persistent);
        // Create a native array to store the closest vertex distance
        NativeArray<float> closestDistances = new(1, Allocator.Persistent);
        closestDistances[0] = float.MaxValue;

        // Get the boat's position
        Vector3 boatPos = boat.transform.position;

        // Create a new job to find the closest vertex
        ClosestVertexJob closestVertexJob = new()
        {
            boatPos = boatPos,
            vertices = nativeVertices,
            closestDistances = closestDistances,
            closestVertices = closestVertices
        };

        // Schedule and complete the job
        JobHandle jobHandle = closestVertexJob.Schedule();
        jobHandle.Complete();

        // Check if a closest vertex was found
        if (closestVertices[0] != -1)
        {
            // Get the closest vertex position
            Vector3 closestVertexPos = vertices[closestVertices[0]];
            // Set the boat's position to the closest vertex position
            boat.transform.position = closestVertexPos + offset;
        }

        // Release the memory
        nativeVertices.Dispose();
        closestVertices.Dispose();
        closestDistances.Dispose();
    }
}

public struct ClosestVertexJob : IJob
{
    public Vector3 boatPos;
    public NativeArray<Vector3> vertices;
    public NativeArray<int> closestVertices;
    public NativeArray<float> closestDistances;

    public void Execute()
    {
        // loop through all ocean vertices
        for (int i = 0; i < vertices.Length; i++)
        {
            // calculate the distance between the vertex and the boat
            float dist = Vector3.Distance(vertices[i], boatPos);
            // check if this is the closest vertex
            if (dist < closestDistances[0])
            {
                closestDistances[0] = dist;
                closestVertices[0] = i;
            }
        }
    }
}
