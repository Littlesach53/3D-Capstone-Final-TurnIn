using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Furnace : MonoBehaviour
{
    public static Furnace Instance { get; set; }

    public bool inFurnaceRange;

    public bool isSmelting;
    public float smeltingTimer;

    public SmeltableOre oreBeingSmelted;
    public string readyOre;

    public Image SmeltBar;
    public GameObject CookingTimer;



          private void Awake()
   {
        
       if (Instance != null && Instance != this)
        {
           // Destroy(gameObject);
       }
       else
       {
           Instance = this;
        }
    }

public void Start()
{
    // SmeltBar = GetComponent<Image>();
     SmeltBar = CookingTimer.GetComponent<Image>();
}
    public void Update()
    {
        if (isSmelting)
        {
            
            smeltingTimer -= Time.deltaTime;

             if (SmeltBar != null)
            {
                // Update the fill amount of the SmeltBar based on the timer progress
                SmeltBar.fillAmount = smeltingTimer / TimeToSmeltOre(oreBeingSmelted);
            }
            
        }

        if(smeltingTimer <= 0 && isSmelting)
        {
            isSmelting = false;
            readyOre = GetSmeltedOre(oreBeingSmelted);

              if (SmeltBar != null)
                {
                    SmeltBar.fillAmount = 0f;
                }
        }

         if (readyOre != "")
        {
            SmeltingSystem.Instance.selectedFurnace = this;
            Debug.Log("Ready Ore: " + readyOre);
            GameObject readyore = Instantiate(Resources.Load<GameObject>(readyOre), 
            SmeltingSystem.Instance.oreSlot.transform.position,
            SmeltingSystem.Instance.oreSlot.transform.rotation);

            readyore.transform.SetParent(SmeltingSystem.Instance.oreSlot.transform);
            readyOre = "";
        }
    }

    private string GetSmeltedOre(SmeltableOre ore)
    {
        return ore.smeltedOreName;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inFurnaceRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inFurnaceRange = false;
        }
    }

    public void OpenSmeltUI()
    {
        Debug.Log("TryingOre");
        SmeltingSystem.Instance.OpenUI();
        SmeltingSystem.Instance.selectedFurnace = this;

        //if (readyOre != "")
       // {
        //    Debug.Log("Ready Ore: " + readyOre);
        //    GameObject readyore = Instantiate(Resources.Load<GameObject>(readyOre), 
        //    SmeltingSystem.Instance.oreSlot.transform.position,
       //     SmeltingSystem.Instance.oreSlot.transform.rotation);

         //   readyore.transform.SetParent(SmeltingSystem.Instance.oreSlot.transform);
         //   readyOre = "";
      //  }
    }

    public void StartSmelting(InventoryItem ore)
    {
        Debug.Log("StartedSmeliting");
        oreBeingSmelted = ConvertIntoSmeltable(ore);

        isSmelting = true;

        smeltingTimer = TimeToSmeltOre(oreBeingSmelted);
    }

    private SmeltableOre ConvertIntoSmeltable(InventoryItem ore)
    {
        Debug.Log("Converted");
      foreach (SmeltableOre smeltable in SmeltingSystem.Instance.smeltingData.validOres) 
      {
        if (smeltable.name == ore.thisName)
        {
            return smeltable;
        }
      }
      return new SmeltableOre();
      
    }

    private float TimeToSmeltOre(SmeltableOre ore)
    {
        return ore.timeToSmelt;
    }

}
