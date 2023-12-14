using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HydrationBar : MonoBehaviour
{
     public Image hydrationBar;

    public GameObject playerState;

    private float currentHydration, maxHydration;
    // Start is called before the first frame update
    void Awake()
    {
        hydrationBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHydration = playerState.GetComponent<PlayerState>().currentHydration;
        maxHydration = playerState.GetComponent<PlayerState>().maxHydration;

       hydrationBar.fillAmount = currentHydration / 100; 
    }
}
