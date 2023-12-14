using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicZone : MonoBehaviour
{
    public bool playerInToxicZone;
    public GameObject playerState;
    public GameObject ToxicZoneUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInToxicZone = true;
            ToxicZoneUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInToxicZone = false;
            ToxicZoneUI.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInToxicZone)
        {
            DecreaseHealthOverTime();
        }
    }

    void DecreaseHealthOverTime()
    {
        PlayerState playerStateComponent = playerState.GetComponent<PlayerState>();

        if (playerStateComponent != null)
        {
            playerStateComponent.currentHealth -= 2 * Time.deltaTime;
        }
        else
        {
            Debug.LogError("PlayerState component not found on playerState GameObject.");
        }
    }
}