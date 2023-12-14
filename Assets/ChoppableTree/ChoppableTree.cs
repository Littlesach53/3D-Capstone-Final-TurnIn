using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class ChoppableTree : MonoBehaviour
{

    public bool playerInRange;
    public float HitCooldown = 1.0f;
     private float lastHitTime;
    public float treeMaxHealth;
    public float treeHealth;
    public GameObject log1, log2, log3, log4, stick1, stick2, stick3, stick4;
    public bool axeInHand;
    public GameObject tools;
    private void Start()
    {
        treeHealth = treeMaxHealth;
        playerInRange = false;
        if(tools.gameObject == null) { tools = GameObject.Find("ToolHolder"); } 
        lastHitTime = Time.time - HitCooldown;
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
    if (tools.transform.Find("AxeLv1_Model(Clone)"))
    {
        axeInHand = true;
    }

    if (playerInRange && Input.GetMouseButtonDown(0) && axeInHand)
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
         treeHealth -= 2;

          if( gameObject.CompareTag("CTree") && treeHealth <= 0)
        {
         
           GameObject.Instantiate(log1, transform.position, transform.rotation);
          GameObject.Instantiate(log2,  transform.position, transform.rotation);
          GameObject.Instantiate(stick1,  transform.position, transform.rotation);
          GameObject.Instantiate(stick2,  transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("CMT") && treeHealth <= 0)
        {
            GameObject.Instantiate(log1, transform.position, transform.rotation);
          GameObject.Instantiate(log2,  transform.position, transform.rotation);
          GameObject.Instantiate(log3,  transform.position, transform.rotation);
          GameObject.Instantiate(stick1,  transform.position, transform.rotation);
          GameObject.Instantiate(stick2,  transform.position, transform.rotation);
          GameObject.Instantiate(stick3,  transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("CLT") && treeHealth <= 0)
        {
               GameObject.Instantiate(log1, transform.position, transform.rotation);
          GameObject.Instantiate(log2,  transform.position, transform.rotation);
          GameObject.Instantiate(log3,  transform.position, transform.rotation);
            GameObject.Instantiate(log4,  transform.position, transform.rotation);
          GameObject.Instantiate(stick1,  transform.position, transform.rotation);
          GameObject.Instantiate(stick2,  transform.position, transform.rotation);
          GameObject.Instantiate(stick3,  transform.position, transform.rotation);
          GameObject.Instantiate(stick4,  transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("CB") && treeHealth <= 0)
        {
            GameObject.Instantiate(stick3,  transform.position, transform.rotation);
          GameObject.Instantiate(stick4,  transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("CDT") && treeHealth <= 0)
        {
              GameObject.Instantiate(stick3,  transform.position, transform.rotation);
          GameObject.Instantiate(stick4,  transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("CDTT") && treeHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
