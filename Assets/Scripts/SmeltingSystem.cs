using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SmeltingSystem : MonoBehaviour
{
    public static SmeltingSystem Instance { get; set; }

    public Button smeltButton;
    public Button exitButton;
    public GameObject oreSlot;
    public GameObject fuelSlot;

    public Furnace selectedFurnace;

    public GameObject smeltingPanel;
    public bool isUiOpen;
    public SmeltingData smeltingData;


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


   public void Update()
   {

    if (FuelAndOresAreValid())
    {
        smeltButton.interactable = true;
    }
    else smeltButton.interactable = false;


      if(Furnace.Instance.inFurnaceRange && Input.GetKeyDown(KeyCode.O))
    {
        OpenUI();
    }
   }

   private bool FuelAndOresAreValid()
   {
    InventoryItem fuel = fuelSlot.GetComponentInChildren<InventoryItem>();
    InventoryItem ore = oreSlot.GetComponentInChildren<InventoryItem>();

    if (fuel != null && ore != null)
    {
        if (smeltingData.validFuels.Contains(fuel.thisName) && smeltingData.validOres.Any(SmeltableOre => SmeltableOre.name == ore.thisName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    return false;
    }

    public void SmeltButtonPressed()
    {
        InventoryItem ore = oreSlot.GetComponentInChildren<InventoryItem>();
        Furnace.Instance.StartSmelting(ore);

         InventoryItem fuel = fuelSlot.GetComponentInChildren<InventoryItem>();
         Destroy(fuel.gameObject);
         Destroy(ore.gameObject);
         InventorySystem.Instance.ReCalculateList();
         CraftingSystem.Instance.RefreshNeededItems();
       
        // CloseUI();
    }

   public void OpenUI()
   {
    smeltingPanel.SetActive(true);
    InventorySystem.Instance. inventoryScreenUI.SetActive(true);
    CraftingSystem.Instance.craftingScreenUI.SetActive(false);
    CraftingSystem.Instance.toolsCatagoryScreenUI.SetActive(false);
    CraftingSystem.Instance.materialsCatagoryScreenUI.SetActive(false);
    CraftingSystem.Instance.materialsCatagoryScreen2UI.SetActive(false);
    isUiOpen = true;


Cursor.lockState = CursorLockMode.None;
Cursor.visible = true;

SelectionManager.Instance.DisableSelection();
SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false;
   }

   public void CloseUI()
   {
    smeltingPanel.SetActive(false);
      InventorySystem.Instance. inventoryScreenUI.SetActive(false);
    isUiOpen = false;
             InventorySystem.Instance.ReCalculateList();
         CraftingSystem.Instance.RefreshNeededItems();


Cursor.lockState = CursorLockMode.Locked;
Cursor.visible = false;

SelectionManager.Instance.EnableSelection();
SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
   }
}

