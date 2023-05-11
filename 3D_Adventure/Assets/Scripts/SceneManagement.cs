using System.Threading.Tasks;
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
    public async void Level1()
    {
        await Task.Delay(2500);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Greyboxing Scene");
    }
    public async void Options()
    {
        await Task.Delay(2500);
        SceneManager.LoadScene("Controls Scene");
    }
    public async void Quit()
    {
        await Task.Delay(2500);
        Application.Quit();
    }
}
