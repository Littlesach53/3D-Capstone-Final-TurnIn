using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{

    private Button button;
    private TextMeshProUGUI buttonText;

    public GameObject alertUI;
    Button yesBTN;
    Button noBTN;

    public int slotNumber;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonText = transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();

        yesBTN = alertUI.transform.Find("YesButton").GetComponent<Button>();
        noBTN = alertUI.transform.Find("NoButton").GetComponent<Button>();

    }
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => {
            if (MainMenuSaveManager.Instance.IsSlotEmpty(slotNumber))
            {
              SaveGameConfirmed();
            }
            else
            {
               DisplayOverrideWarning();
            }
        });
    }

public void Update()
{
    if (MainMenuSaveManager.Instance.IsSlotEmpty(slotNumber))
    {
        buttonText.text = "Empty";
    }
    else
    {
        buttonText.text = PlayerPrefs.GetString("Slot" + slotNumber + "Description");
    }
}

public void DisplayOverrideWarning()
{
    alertUI.SetActive(true);

    yesBTN.onClick.AddListener(()=> 
    {
        SaveGameConfirmed();
        alertUI.SetActive(false);
    });

    noBTN.onClick.AddListener(()=> 
    {
     alertUI.SetActive(false);
    });
}

public void SaveGameConfirmed()
{
    MainMenuSaveManager.Instance.SaveGame(slotNumber);


    DateTime dt = DateTime.Now;
    string time = dt.ToString("yyyy-MM-dd HH:mm");

    string description = "Saved Game " + slotNumber + " | " + time;

    buttonText.text = description;

    PlayerPrefs.SetString("Slot" + slotNumber + "Description", description);

     MainMenuSaveManager.Instance.DeselectButton();
}
}
