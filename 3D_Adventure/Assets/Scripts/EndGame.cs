using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject WinCanvas;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("win");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            WinCanvas.SetActive(true);
            Time.timeScale = 0f;
            Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        }
    }
}
