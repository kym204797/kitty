using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public Canvas gameOverCanvas;
    public string sceneToLoad;
    
    void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (player == null || !player.activeInHierarchy)
        {
            gameOverCanvas.gameObject.SetActive(true);
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToLoad);
    }


    public void QuitGamne()
    {
        Application.Quit();
        Debug.Log("Salir...");
    }
}

