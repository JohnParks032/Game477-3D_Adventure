using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
   public void StartScene()
    {
        SceneManager.LoadScene("Start Scene");
    }
    public void EndScene()
    {
        SceneManager.LoadScene("End Scene");
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level 1 Greybox");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
