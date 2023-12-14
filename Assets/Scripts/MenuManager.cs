using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject menuCanvas;
    public GameObject Canvas;
    public GameObject questCanvas;

    public bool isMenuOpen;

    public GameObject saveMenu;
    public GameObject ControlsMenu;

    public static MenuManager Instance { get; set; }

        private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isMenuOpen)
        {
            Canvas.SetActive(false);
            questCanvas.SetActive(false);
            menuCanvas.SetActive(true);

            isMenuOpen = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SelectionManager.Instance.DisableSelection();
            SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.P) && isMenuOpen)
        {
          Canvas.SetActive(true);
          questCanvas.SetActive(false);
          menuCanvas.SetActive(false);
          saveMenu.SetActive(false);
          ControlsMenu.SetActive(false);

         isMenuOpen = false;

        if(CraftingSystem.Instance.isOpen == false && InventorySystem.Instance.isOpen == false && SmeltingSystem.Instance.isUiOpen == false)
        {
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = false;
        }

           SelectionManager.Instance.EnableSelection();
            SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
        }
    }

    public void Resume()
    {
        Canvas.SetActive(true);
        questCanvas.SetActive(false);
          menuCanvas.SetActive(false);
          saveMenu.SetActive(false);
          ControlsMenu.SetActive(false);
                   isMenuOpen = false;

        if(CraftingSystem.Instance.isOpen == false && InventorySystem.Instance.isOpen == false && SmeltingSystem.Instance.isUiOpen == false)
        {
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = false;
        }

           SelectionManager.Instance.EnableSelection();
            SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
