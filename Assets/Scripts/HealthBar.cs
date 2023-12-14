using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBar : MonoBehaviour
{
    public Image healthBar;

    public GameObject playerState;


    private float currentHealth, maxHealth;
    // Start is called before the first frame update
    void Awake()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerState.GetComponent<PlayerState>().currentHealth;
        maxHealth = playerState.GetComponent<PlayerState>().maxHealth;

        healthBar.fillAmount = currentHealth / 100;
        

    }
}
