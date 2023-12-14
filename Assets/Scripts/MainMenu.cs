using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

  public Button loadgameBTN;

 
    public void NewGame()
    {
      SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
     Debug.Log("Quiting Game");
     Application.Quit();
    }
}
