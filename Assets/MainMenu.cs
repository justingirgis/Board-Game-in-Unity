using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void playGame()
    {
        //SceneManager.LoadScene(SceneManager.getActiveScene().buildIndex + 1);
        Debug.Log("GAME STARTING");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
        //Application.Quit;
    }

    public void optionMenu()
    {
        Debug.Log("GAME STARTING");
        SceneManager.LoadScene(2);
    }


}
