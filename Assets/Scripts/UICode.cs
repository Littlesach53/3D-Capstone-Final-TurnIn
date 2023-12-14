using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UICode : MonoBehaviour
{

    public void BackToMainMenu()
    {
        Debug.Log("going");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitToDesktop()
    {
         Debug.Log("Quiting Game");
        Application.Quit();
    }
}
