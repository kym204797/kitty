using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    //public GameObject pausemenu;

    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        //pausemenu.SetActive(true);  
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void PauseGame()
    {
        //pausemenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }



    public void ResumeGame()
    {
        //pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu principal");
    }


    public void QuitGamne()
    {
        Application.Quit();
        Debug.Log("Salir...");
    }
}
