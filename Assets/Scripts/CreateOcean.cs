using UnityEngine;

public sealed class CreateOcean : MonoBehaviour
{
    const int WIDTH = 200;
    const int LENGTH = 200;
    const float SCALE = 5;

    private void Start()
    {
        CreateOceanMesh();
    }

    public Mesh CreateOceanMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new();

        Vector3[] vertices = new Vector3[WIDTH * LENGTH];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[(WIDTH - 1) * (LENGTH - 1) * 6];

        for (int z = 0; z < LENGTH; z++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                int i = z * WIDTH + x;
                Vector3 vertex = new Vector3(x - WIDTH / 2, 0, z - LENGTH / 2) * SCALE;
                vertices[i] = vertex;
                uv[i] = new Vector2((float)x / (WIDTH - 1), (float)z / (LENGTH - 1));
            }
        }

        int t = 0;
        for (int z = 0; z < LENGTH - 1; z++)
        {
            for (int x = 0; x < WIDTH - 1; x++)
            {
                int i = z * WIDTH + x;
                triangles[t] = i;
                triangles[t + 1] = i + WIDTH;
                triangles[t + 2] = i + 1;
                triangles[t + 3] = i + 1;
                triangles[t + 4] = i + WIDTH;
                triangles[t + 5] = i + WIDTH + 1;
                t += 6;
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
        return mesh;
    }
}
