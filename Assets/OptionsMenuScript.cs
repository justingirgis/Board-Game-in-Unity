using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuScript : MonoBehaviour
{

    public string Url;

    public void OpenUserManual()
    {
        Debug.Log("Opening User Manual");
        Application.OpenURL(Url);
    }

    public void backToMainMenu()
    {
        Debug.Log("Going back to main menu");
        SceneManager.LoadScene(0);
    }
}
