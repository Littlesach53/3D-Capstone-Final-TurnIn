using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilageHealth : MonoBehaviour
{

    public GameObject heatUI;
    public GameObject coldUi;
  public void OnTriggerStay(Collider other)
  {
    if(other.gameObject.CompareTag("Player"))
    {
        PlayerState.Instance.currentCalories = 100;
        PlayerState.Instance.currentHealth = 100;
        PlayerState.Instance.currentHydration = 100;

        heatUI.SetActive(false);
        coldUi.SetActive(false);
    }
  }
}
