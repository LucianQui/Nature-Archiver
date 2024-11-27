using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("NatureArchiver");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}

