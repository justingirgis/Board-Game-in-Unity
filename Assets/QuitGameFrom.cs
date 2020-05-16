using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGameFrom : MonoBehaviour
{

    public void backToMainMenu()
    {
        //SceneManager.LoadScene(SceneManager.getActiveScene().buildIndex + 1);
        Debug.Log("QUITTING GAME");
        SceneManager.LoadScene(0);
    }

    public void ButtonToOptionMenu()
    {
        Debug.Log("GOING TO OPTIONS");
        SceneManager.LoadScene(2);
    }
}
