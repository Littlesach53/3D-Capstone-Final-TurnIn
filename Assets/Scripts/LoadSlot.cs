using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSlot : MonoBehaviour
{

    public Button button;
    public TextMeshProUGUI buttonText;

    public int slotNumber;

    private void Awake()
    {
     button = GetComponent<Button>();
     buttonText = transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(()=> 
        {
        if (MainMenuSaveManager.Instance.IsSlotEmpty(slotNumber) == false)
        {
            MainMenuSaveManager.Instance.StartLoadedGame(slotNumber);
              MainMenuSaveManager.Instance.DeselectButton();
        }
        else
        {
            
        }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenuSaveManager.Instance.IsSlotEmpty(slotNumber))
        {
            buttonText.text = "";
        }
        else
        {
            buttonText.text = PlayerPrefs.GetString("Slot" + slotNumber + "Description");
        }
    }
}
