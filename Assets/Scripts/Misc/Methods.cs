using UnityEngine;

public class Methods : MonoBehaviour
{
    public void QuitApp() => Application.Quit();

    public void LoadLevel(int index) => UnityEngine.SceneManagement.SceneManager.LoadScene(index);

    public void LoadLevel(string name) => UnityEngine.SceneManagement.SceneManager.LoadScene(name);
}
