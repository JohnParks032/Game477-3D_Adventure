using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
   public void StartScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void EndScene()
    {
        SceneManager.LoadScene("End Scene");
    }
    public void Level1()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Greyboxing Scene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
