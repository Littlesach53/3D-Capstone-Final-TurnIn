using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CaloriesBar : MonoBehaviour
{
     public Image caloriesBar;

    public GameObject playerState;

    private float currentcalories, maxcalories;
    // Start is called before the first frame update
    void Awake()
    {
        caloriesBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentcalories = playerState.GetComponent<PlayerState>().currentCalories;
        maxcalories = playerState.GetComponent<PlayerState>().maxCalories;

       caloriesBar.fillAmount = currentcalories / 100;
    }
}
