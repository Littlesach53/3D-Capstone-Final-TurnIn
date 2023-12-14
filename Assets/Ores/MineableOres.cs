using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MineableOres : MonoBehaviour
{

    public bool playerInRange;
    public AudioSource aud;

    public float OreMaxHealth;
    public float HitCooldown = 1.0f;
     private float lastHitTime;
    public float OreHealth;
    public GameObject ore1, ore2, ore3, ore4;
    public bool PickaxeInHand;
    public GameObject tools;
    private void Start()
    {
        OreHealth = OreMaxHealth;
        playerInRange = false;
        if(tools.gameObject == null) { tools = GameObject.Find("ToolHolder"); } 
         lastHitTime = Time.time - HitCooldown;
         aud = GetComponent<AudioSource>();
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

private void Update()
{
    if (tools.transform.Find("PickAxeLv1_Model(Clone)"))
    {
        PickaxeInHand = true;
    }

    if (playerInRange && Input.GetMouseButtonDown(0) && PickaxeInHand)
    {
        if (Time.time - lastHitTime >= HitCooldown)
            {
                lastHitTime = Time.time; // Update the last Hit time
                GetHit();
            }
    }
}
    public void GetHit()
{

    aud.Play();
    OreHealth -= 2;

    if (OreHealth <= 0)
    {
        if (gameObject.CompareTag("BigStoneOre"))
        {
            InstantiateOres(ore1, ore2, ore3, ore4);
        }
        else if (gameObject.CompareTag("SmallStoneOre"))
        {
            InstantiateOres(ore1, ore2);
        }
        else if (gameObject.CompareTag("BigCoalOre"))
        {
            InstantiateOres(ore1, ore2, ore3, ore4);
        }
        else if (gameObject.CompareTag("SmallCoalOre"))
        {
            InstantiateOres(ore1, ore2);
        }
        else if (gameObject.CompareTag("BigIronOre"))
        {
            InstantiateOres(ore1, ore2, ore3, ore4);
        }
        else if (gameObject.CompareTag("SmallIronOre"))
        {
            InstantiateOres(ore1, ore2);
        }
        else if (gameObject.CompareTag("BigGoldOre"))
        {
            InstantiateOres(ore1, ore2);
        }
        else if (gameObject.CompareTag("SmallGoldOre"))
        {
            InstantiateOres(ore1);
        }
        else if (gameObject.CompareTag("BigEmeraldOre"))
        {
            InstantiateOres(ore1, ore2);
        }
        else if (gameObject.CompareTag("SmallEmeraldOre"))
        {
            InstantiateOres(ore1);
        }

        Destroy(gameObject);
    }
}
private void InstantiateOres(params GameObject[] ores)
{
    foreach (GameObject ore in ores)
    {
        // Define an offset for the spawned ores
        Vector3 offset = new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));

        Instantiate(ore, transform.position + offset, transform.rotation);
    }
}
}
