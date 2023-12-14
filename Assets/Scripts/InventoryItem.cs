using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
 
public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    // public static InventoryItem Instance { get; set; }
       public bool isTrashable;
 
    // --- Item Info UI --- //
    private GameObject itemInfoUI;

        private TextMeshProUGUI itemInfoUI_itemName;
    private TextMeshProUGUI itemInfoUI_itemDescription;
    private TextMeshProUGUI itemInfoUI_itemFunctionality;
     public string thisName, thisDescription, thisFunctionality;

       private GameObject itemPendingConsumption;
    public bool isConsumable;
 
    public float healthEffect;
    public float caloriesEffect;
    public float hydrationEffect;

    public bool isEquippable;

public bool isUsable;
public GameObject itemPendingToBeUsed;
    private GameObject itemPendingEquipping;
    public bool isInsideQuickSlot;
    public bool isSelected;

    
      private void Start()
    {
        itemInfoUI = InventorySystem.Instance.ItemInfoUI;
        itemInfoUI_itemName = itemInfoUI.transform.Find("itemName").GetComponent<TextMeshProUGUI>();
        itemInfoUI_itemDescription = itemInfoUI.transform.Find("itemDescription").GetComponent<TextMeshProUGUI>();
        itemInfoUI_itemFunctionality = itemInfoUI.transform.Find("itemFunctionality").GetComponent<TextMeshProUGUI>();
    }
    
     void Update()
 {
    if (isSelected)
    {
        gameObject.GetComponent<DragandDrop>().enabled = false;
    }
    else 
    {
        gameObject.GetComponent<DragandDrop>().enabled = true;
    }
 }

    public void OnPointerEnter(PointerEventData eventData)
    {
        itemInfoUI.SetActive(true);
        itemInfoUI_itemName.text = thisName;
        itemInfoUI_itemDescription.text = thisDescription;
        itemInfoUI_itemFunctionality.text = thisFunctionality;
    }

       // Triggered when the mouse exits the area of the item that has this script.
    public void OnPointerExit(PointerEventData eventData)
    {
        itemInfoUI.SetActive(false);
    }

      // Triggered when the mouse is clicked over the item that has this script.
    public void OnPointerDown(PointerEventData eventData)
    {
        //Right Mouse Button Click on
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (isConsumable)
            {
                // Setting this specific gameobject to be the item we want to destroy later
                itemPendingConsumption = gameObject;
                consumingFunction(healthEffect, caloriesEffect, hydrationEffect);
            }

                if (isEquippable && isInsideQuickSlot == false && EquipSystem.Instance.CheckIfFull() == false)
        {
               EquipSystem.Instance.AddToQuickSlots(gameObject);
               isInsideQuickSlot = true;
        }

        if (isUsable)
        {
           gameObject.SetActive(false);
            UseItem();
        }
        }
    }

            // Triggered when the mouse button is released over the item that has this script.
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (isConsumable && itemPendingConsumption == gameObject)
            {
                DestroyImmediate(gameObject);
                InventorySystem.Instance.ReCalculateList();
                CraftingSystem.Instance.RefreshNeededItems();
            }

            if (isUsable && itemPendingToBeUsed == gameObject)
            {
                DestroyImmediate(gameObject);
                InventorySystem.Instance.ReCalculateList();
                CraftingSystem.Instance.RefreshNeededItems();
            }
        }
    }

         public void UseItem()
    {
        itemInfoUI.SetActive(false);

       InventorySystem.Instance.isOpen = false;
       InventorySystem.Instance.inventoryScreenUI.SetActive(false);

       CraftingSystem.Instance.isOpen = false;
       CraftingSystem.Instance.craftingScreenUI.SetActive(false);
       CraftingSystem.Instance.toolsCatagoryScreenUI.SetActive(false);
       CraftingSystem.Instance.materialsCatagoryScreenUI.SetActive(false);
       CraftingSystem.Instance.materialsCatagoryScreen2UI.SetActive(false);
       CraftingSystem.Instance.weaponsCatagoryScreenUI.SetActive(false);

       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;

       SelectionManager.Instance.EnableSelection();
       SelectionManager.Instance.enabled = true;
       
        ItemInfo itemInfo = gameObject.GetComponent<ItemInfo>();

         if (itemInfo != null)
    {
        string itemType = itemInfo.itemType;

        switch (itemType)
        {
            case "StorageBoxSmall":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("StorageBoxSmallModel");
                break;
            case "StorageBoxMedium":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("StorageBoxMediumModel");
                break;
            case "StorageBoxLarge":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("StorageBoxLargeModel");
                break;
                 case "CampFire":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("CampFireModel");
                break;
                case "Chair":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("ChairModel");
                break;
                case "ChairType2":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("ChairType2Model");
                break;
                case "Lamp":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("LampModel");
                break;
                case "LampType2":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("LampType2Model");
                break;
                case "LampType3":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("LampType3Model");
                break;
                case "Table":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("TableModel");
                break;
                     case "TableType2":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("TableType2Model");
                break;
                     case "TableType3":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("TableType3Model");
                break;
                case "NightStand":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("NightStandModel");
                break;
                case "NightStandType2":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("NightStandType2Model");
                break;
                case "Bed":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("BedModel");
                break;
                case "BedType2":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("BedType2Model");
                break;
                case "BookShelf":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("BookShelfModel");
                break;
                case "BookShelfType2":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("BookShelfType2Model");
                break;
                case "Couch":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("CouchModel");
                break;
                case "CouchType2":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("CouchType2Model");
                break;
                case "Fridge":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("FridgeModel");
                break;
                case "Sink":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("SinkModel");
                break;
                case "Washer":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("WasherModel");
                break;
                case "TV":
            PlacementSystem.Instance.inventoryItemToDestory = gameObject;
                PlacementSystem.Instance.ActivatePlacementMode("TVModel");
                break;
            default:
                break;
        }

       }
 
    }
 
    private void consumingFunction(float healthEffect, float caloriesEffect, float hydrationEffect)
    {
        itemInfoUI.SetActive(false);
 
        healthEffectCalculation(healthEffect);
 
        caloriesEffectCalculation(caloriesEffect);
 
        hydrationEffectCalculation(hydrationEffect);
 
    }

    
 
    private static void healthEffectCalculation(float healthEffect)
    {
        // --- Health --- //
 
        float healthBeforeConsumption = PlayerState.Instance.currentHealth;
        float maxHealth = PlayerState.Instance.maxHealth;
 
        if (healthEffect != 0)
        {
            if ((healthBeforeConsumption + healthEffect) > maxHealth)
            {
                PlayerState.Instance.setHealth(maxHealth);
            }
            else
            {
                PlayerState.Instance.setHealth(healthBeforeConsumption + healthEffect);
            }
        }
    }
 
 
    private static void caloriesEffectCalculation(float caloriesEffect)
    {
        // --- Calories --- //
 
        float caloriesBeforeConsumption = PlayerState.Instance.currentCalories;
        float maxCalories = PlayerState.Instance.maxCalories;
 
        if (caloriesEffect != 0)
        {
            if ((caloriesBeforeConsumption + caloriesEffect) > maxCalories)
            {
                PlayerState.Instance.setCalories(maxCalories);
            }
            else
            {
                PlayerState.Instance.setCalories(caloriesBeforeConsumption + caloriesEffect);
            }
        }
    }
 
 
    private static void hydrationEffectCalculation(float hydrationEffect)
    {
        // --- Hydration --- //
 
        float hydrationBeforeConsumption = PlayerState.Instance.currentHydration;
        float maxHydration = PlayerState.Instance.maxHydration;
 
        if (hydrationEffect != 0)
        {
            if ((hydrationBeforeConsumption + hydrationEffect) > maxHydration)
            {
                PlayerState.Instance.setHydration(maxHydration);
            }
            else
            {
                PlayerState.Instance.setHydration(hydrationBeforeConsumption + hydrationEffect);
            }
        }
    }
}