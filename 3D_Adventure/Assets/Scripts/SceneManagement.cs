using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public async void StartScene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        await Task.Delay(1000);
        SceneManager.LoadScene("MainMenu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void EndScene()
    {
        SceneManager.LoadScene("End Scene");
    }
    public async void Level1()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        await Task.Delay(1000);
        SceneManager.LoadScene("Game");
    }
    public async void Options()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        await Task.Delay(1000);
        SceneManager.LoadScene("Controls Scene");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public async void Quit()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        await Task.Delay(1000);
        Application.Quit();
    }
}
