using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        Debug.Log("It works!");
        SceneManager.LoadScene("More_Magic");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
