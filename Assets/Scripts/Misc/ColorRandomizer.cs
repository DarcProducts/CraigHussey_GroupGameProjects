using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    void OnEnable()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(Random.Range(.2f, 1f), Random.Range(.2f, 1f), Random.Range(.2f, 1f));
    }
}
