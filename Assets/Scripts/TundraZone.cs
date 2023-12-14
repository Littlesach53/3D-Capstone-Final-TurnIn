using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TundraZone : MonoBehaviour
{
    public bool playerInTundraZone;
    public GameObject playerState;
    public GameObject TundraZoneUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTundraZone = true;
            TundraZoneUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTundraZone = false;
            TundraZoneUI.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInTundraZone)
        {
            DecreaseHungerOverTime();
        }
    }

    void DecreaseHungerOverTime()
    {
        PlayerState playerStateComponent = playerState.GetComponent<PlayerState>();

        if (playerStateComponent != null)
        {
            playerStateComponent.currentCalories -= 2 * Time.deltaTime;
        }
        else
        {
            Debug.LogError("PlayerState component not found on playerState GameObject.");
        }
    }
}
