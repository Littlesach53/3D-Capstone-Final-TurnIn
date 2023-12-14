using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventorySystem : MonoBehaviour
{
     public GameObject ItemInfoUI;
     public static InventorySystem Instance { get; set; }

    public GameObject inventoryScreenUI;
    public List<GameObject> slotList = new List<GameObject>();
    public List<string> itemList = new List<string>();
       private GameObject itemToAdd;
   private GameObject whatSlotToEquip;
    public bool isOpen;

      //public bool isFull;

    public GameObject pickupAlert;
    public TextMeshProUGUI addedNumber;
    public Image pickupImage;

    public List<string> itemsPickedup;

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

 void Start()
    {
        isOpen = false;

        PopulateSlotList();
    }

        private void PopulateSlotList()
    {

foreach(Transform child in inventoryScreenUI.transform)
{
if(child.CompareTag("Slot"))
{
    slotList.Add(child.gameObject);
}
}
    }
 

     void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.I) && !isOpen)
        {
          OpenUI();
        }
                else if (Input.GetKeyDown(KeyCode.I) && isOpen)
        {
            CloseUI();
        }
    }

    public void OpenUI()
    {
            inventoryScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SelectionManager.Instance.DisableSelection();
            SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false;

            isOpen = true;
    }

    public void CloseUI()
    {
            inventoryScreenUI.SetActive(false);

            if(!CraftingSystem.Instance.isOpen && !SmeltingSystem.Instance.isUiOpen)
     {
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = false;

           SelectionManager.Instance.EnableSelection();
            SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
       }
                      isOpen = false;
    }


        public void AddToInventory(string itemName)
    {

whatSlotToEquip = FindNextEmptySlot();

itemToAdd = (GameObject)Instantiate(Resources.Load<GameObject>(itemName), whatSlotToEquip.transform.position, whatSlotToEquip.transform.rotation);
itemToAdd.transform.SetParent(whatSlotToEquip.transform);

itemList.Add(itemName);

TriggerPickUpPopUp(itemToAdd.GetComponent<Image>().sprite);

ReCalculateList();
CraftingSystem.Instance.RefreshNeededItems();

QuestManager.Instance.RefreshTrackerList();
    }

    void TriggerPickUpPopUp(Sprite itemSprite)
{

StartCoroutine(PickupPOP());

pickupImage.sprite = itemSprite;

}

IEnumerator PickupPOP()
{
    pickupAlert.SetActive(true);
    yield return new WaitForSeconds(1f);
    pickupAlert.SetActive(false);
}

   private GameObject FindNextEmptySlot()
    {
foreach(GameObject slot in slotList)
{

    if(slot.transform.childCount == 0)
    {
        return slot;
    }
}
return new GameObject();
    }

        public bool CheckIfFull()
    {
int counter = 0;

foreach(GameObject slot in slotList)
{
    if(slot.transform.childCount >0)
    {
        counter += 1;
    }
}

    if(counter == 28)
    {
return true;
    }
    else
    {
        return false;
    }
    }

    public void RemoveItem(string nameToRemove, int amountToRemove)
{

int counter = amountToRemove;
for(var i = slotList.Count - 1;i>=0;i--)
{


if(slotList[i].transform.childCount > 0)
{

if(slotList[i].transform.GetChild(0).name == nameToRemove +"(Clone)" && counter !=0)
{

Destroy(slotList[i].transform.GetChild(0).gameObject);

counter -= 1;

     }

    }
  }
   ReCalculateList();
CraftingSystem.Instance.RefreshNeededItems();

QuestManager.Instance.RefreshTrackerList();

 }

  public void ReCalculateList()
 {

itemList.Clear();

foreach (GameObject slot in slotList)
{

    if (slot.transform.childCount > 0)
    {
        string name = slot.transform.GetChild(0).name;
        // string str1 = name;
        string str2 = "(Clone)";
        string result = name.Replace(str2, "");

        itemList.Add(result);

    }
}

 }


 public int CheckItemAmount(string name)
 {
    int itemCounter = 0;

    foreach (string item in itemList)
    {
        if (item == name)
        {
            itemCounter++;
        }
    }
    return itemCounter;
 }
}
