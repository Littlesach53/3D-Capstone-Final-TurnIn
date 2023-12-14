using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertZone : MonoBehaviour
{
    public bool playerInDesertZone;
    public GameObject playerState;
    public GameObject DesertZoneUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInDesertZone = true;
            DesertZoneUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInDesertZone = false;
            DesertZoneUI.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInDesertZone)
        {
            DecreaseHungerOverTime();
        }
    }

    void DecreaseHungerOverTime()
    {
        PlayerState playerStateComponent = playerState.GetComponent<PlayerState>();

        if (playerStateComponent != null)
        {
            playerStateComponent.currentHydration -= 0.5f * Time.deltaTime;
        }
        else
        {
            Debug.LogError("PlayerState component not found on playerState GameObject.");
        }
    }
}

