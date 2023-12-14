using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance {get; set;}

    public GameObject interaction_Info_UI;

    [SerializeField] Lootable loot;
    
    TextMeshProUGUI interaction_text;
     public bool onTarget;

    public GameObject selectedObject;

    public Image redicle;
       public bool handisVisible;

       public GameObject selectedStorageBox;

       public GameObject tools;
       public bool knifeInHand;

    void Awake()
 {
    if(Instance != null && Instance != this)
    {
        Destroy(gameObject);
    }
    else
    {
        Instance = this;
    }
 }

      private void Start()
    {
       if(tools.gameObject == null) { tools = GameObject.Find("ToolHolder"); } 
        onTarget = false;
       interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
       loot = GetComponent<Lootable>();
    }
       void Update()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20f))
        {
            var selectionTransform = hit.transform;

//Interactable Object Section
            InteractableObject interactable = selectionTransform.GetComponent<InteractableObject>();

            if (interactable && interactable.playerInRange)
            {
                onTarget = true;

                selectedObject = interactable.gameObject;
                interaction_text.text = interactable.GetItemName();
                interaction_Info_UI.SetActive(true);
                handisVisible = true;
            }


            //NPC
            NPC npc = selectionTransform.GetComponent<NPC>();

            if (npc && npc.playerInRange)
            {
              interaction_text.text = "Talk";
              interaction_Info_UI.SetActive(true);

              if(Input.GetKeyDown(KeyCode.Mouse0) && npc.isTalkingWithPlayer == false)
              {
                npc.StartConversation();
              }

              if(DialogSystem.Instance.dialogUIActive)
              {
                interaction_Info_UI.SetActive(false);
                redicle.gameObject.SetActive(false);
                
              }
            }


            //Storage Boxes Section 
            StorageBox storageBox = selectionTransform.GetComponent<StorageBox>();

            if (storageBox && storageBox.playerInRange && PlacementSystem.Instance.inPlacementMode == false)
            {
                interaction_text.text = "Open";
                interaction_Info_UI.SetActive(true);

                selectedStorageBox = storageBox.gameObject;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    StorageManager.Instance.OpenBox(storageBox);
                }
            }
            else
            {
              if (selectedStorageBox != null)
              {
                selectedStorageBox = null;
              }
            }


            //Loot Chest Section 
         LootChest lootChest = selectionTransform.GetComponent<LootChest>();

         if (lootChest && lootChest.playerInRange)
         {
          if (lootChest.isAChest)
          {
                        interaction_text.text = "Loot";
              interaction_Info_UI.SetActive(true);

              redicle.gameObject.SetActive(false);

              handisVisible = true;

              if(Input.GetKeyDown(KeyCode.Mouse0))
              {
               StorageManager.Instance.LootChestUI.SetActive(true);
               interaction_Info_UI.SetActive(false);
              }
              else
              {
                interaction_Info_UI.SetActive(true);

             handisVisible = false;
             redicle.gameObject.SetActive(true);
              }
          }
         }



//Animal Section
        Animal animal = selectionTransform.GetComponent<Animal>();

        
          if (tools.transform.Find("KnifeLv1_Model(Clone)"))
    {
        knifeInHand = true;
    }

        if (animal && animal.playerInRange)
        {
          if(animal.isDead && !knifeInHand)
          {
              interaction_text.text = "Skin With Knife";
              interaction_Info_UI.SetActive(true);

              redicle.gameObject.SetActive(false);

              handisVisible = true;
          }
           else if(animal.isDead && knifeInHand)
            {
                interaction_text.text = "Skin";
              interaction_Info_UI.SetActive(true);

              redicle.gameObject.SetActive(false);

              handisVisible = true;

              if(Input.GetKeyDown(KeyCode.Mouse0) && knifeInHand)
              {
                Lootable lootable = animal.GetComponent<Lootable>();
                Loot(lootable);
              }
            }
            else
            {
              
             Debug.Log("Animal Name: " + animal.animalName);
            interaction_text.text = animal.animalName;

            Debug.Log("Setting interaction_Info_UI to true");
            interaction_Info_UI.SetActive(true);

             handisVisible = false;
             redicle.gameObject.SetActive(true);
            

            if (Input.GetKeyDown(KeyCode.Mouse0) && EquipSystem.Instance.IsHoldingWeapon() && EquipSystem.Instance.IsThereASwingLock() == false)
            {
                StartCoroutine(DealDamageTo(animal, 0.3f, EquipSystem.Instance.GetWeaponDamage()));
      }
    }
  }

  //Enemy Section 
EnemyLogic enemyL = selectionTransform.GetComponent<EnemyLogic>();


if (enemyL && enemyL.playerInRange)
{
  if (enemyL.isDead)
{
    Debug.Log("Enemy is dead - can loot");
    interaction_text.text = "Loot";
    interaction_Info_UI.SetActive(true);
    redicle.gameObject.SetActive(false);
    handisVisible = true;
enemyL.AcessStorageEnemy();
}
              if (Input.GetKeyDown(KeyCode.Mouse0) && EquipSystem.Instance.IsHoldingWeapon() && EquipSystem.Instance.IsThereASwingLock() == false)
            {
                StartCoroutine(DealDamageTo(enemyL, 0.3f, EquipSystem.Instance.GetWeaponDamage()));
      }
}


//Orginization of the Interactions 
  if (!interactable && !animal)
  {
    onTarget = false;
    handisVisible = false;

    redicle.gameObject.SetActive(true);
    
  }
  if (!interactable && !animal && !storageBox && !lootChest && !npc && !enemyL)
  {
    interaction_text.text = "";
    interaction_Info_UI.SetActive(false);
  }
 }
}

private void Loot(Lootable lootable)
{
    if (lootable.wasLootCalculated == false)
    {
        List<LootRecieved> recievedLoot = new List<LootRecieved>();

        foreach (LootPossibility loot in lootable.possibleLoot)
        {
            var lootAmount = UnityEngine.Random.Range(loot.amountMin, loot.amountMax+1);

            if (lootAmount > 0)
            {
                LootRecieved lt = new LootRecieved();
                lt.item = loot.item;
                lt.amount = lootAmount;

                recievedLoot.Add(lt);
            }
        }

        lootable.finalLoot = recievedLoot;
        lootable.wasLootCalculated = true;
    }

    //Spawning loot on ground is loot comes from enemy or animal.

    
   if (lootable.isAnimal)
   {
    Vector3 lootSpawnPosition = lootable.gameObject.transform.position;

    foreach (LootRecieved lootRecieved in lootable.finalLoot)
    {
        for (int i =0; i< lootRecieved.amount; i++)
        {
            GameObject lootSpawn = Instantiate(Resources.Load<GameObject>(lootRecieved.item.name+"_Model"),
            new Vector3(lootSpawnPosition.x, lootSpawnPosition.y+0.2f, lootSpawnPosition.z),
            Quaternion.Euler(0,0,0));
        }
    }

    // if I want blood puddle to remain on ground 
    //if (lootable.GetComponent<Animal>())
   // {
     //   lootable.GetComponent<Animal>().bloodPuddle.transform.SetParent(lootable.transform.parent);
   // }

    // Destroy Looted Body
    Destroy(lootable.gameObject);
   }

   if(lootable.isenemy)
   {
       Vector3 lootSpawnPosition = lootable.gameObject.transform.position;

    foreach (LootRecieved lootRecieved in lootable.finalLoot)
    {
        for (int i =0; i< lootRecieved.amount; i++)
        {
            GameObject lootSpawn = Instantiate(Resources.Load<GameObject>(lootRecieved.item.name+"_Model"),
            new Vector3(lootSpawnPosition.x, lootSpawnPosition.y+0.2f, lootSpawnPosition.z),
            Quaternion.Euler(0,0,0));
        }
    }
    Destroy(lootable.gameObject);
   }
}

IEnumerator DealDamageTo(Animal animal, float delay, int damage)
{
 yield return new WaitForSeconds(delay);

 animal.TakeDamage(damage);
}

IEnumerator DealDamageTo(EnemyLogic enemyL, float delay, int damage)
{
 yield return new WaitForSeconds(delay);

 enemyL.TakeDamage(damage);
}



    public void DisableSelection()
    {
redicle.enabled = false;
interaction_Info_UI.SetActive(false);

selectedObject = null;
    }

    public void EnableSelection()
    {
redicle.enabled = true;
interaction_Info_UI.SetActive(true);
    }

}
