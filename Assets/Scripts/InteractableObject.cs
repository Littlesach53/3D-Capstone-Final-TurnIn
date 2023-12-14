using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
 public bool playerInRange;
    public string ItemName;

      public string GetItemName()
    {
        return ItemName;
    }

    private void OnTriggerEnter(Collider other)
    {
if(other.CompareTag("Player"))
{
playerInRange = true;


}
    }

    private void OnTriggerExit(Collider other)
    {
if(other.CompareTag("Player"))
{
playerInRange = false;

    
}
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && playerInRange && SelectionManager.Instance.onTarget && SelectionManager.Instance.selectedObject == gameObject)
        {
                //if the inventory is Not full
        if(!InventorySystem.Instance.CheckIfFull())
        {
        InventorySystem.Instance.AddToInventory(ItemName);

        if (gameObject.CompareTag("Collectable"))
        {
            InventorySystem.Instance.itemsPickedup.Add(gameObject.name);
        }

        Destroy(gameObject);
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
 
        }
    }
}
