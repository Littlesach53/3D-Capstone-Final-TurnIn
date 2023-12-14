using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{

    public static PlayerState Instance { get; set;}


    //PlayerHealth
public float currentHealth;
public float maxHealth;

//PlayerCalories
public float currentCalories;
public float maxCalories;

float distanceTraveled = 0;
Vector3 lastPosition;

public GameObject playerBody;

//PlayerHydration
public float currentHydration;
public float maxHydration;
private bool isHydrationActive;

   private void Awake()
    {
          if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentCalories = maxCalories;
        currentHydration = maxHydration;

        StartCoroutine(decreaseHydration());

    }


    IEnumerator decreaseHydration()
    {
        while (true)
        {
            currentHydration -= 1;
            yield return new WaitForSeconds(5);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(currentCalories <= 0)
        {
            currentCalories = 0;
        }
        if(currentHydration <= 0)
        {
            currentHydration = 0;
        }
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
distanceTraveled += Vector3.Distance(playerBody.transform.position, lastPosition);
lastPosition = playerBody.transform.position;

if (distanceTraveled >=50)
{
    distanceTraveled = 0;
    currentCalories -=1;
}



        if(currentCalories == 0 || currentHydration == 0)
        {
            currentHealth -= .5f * Time.deltaTime;
        }

          if (currentHealth <= 0) 
        {
          Die();
        }
    }

    public void setHealth(float newHealth)
    {
        currentHealth = newHealth;
    }

    public void setCalories(float newCalories)
    {
        currentCalories = newCalories;
    }

    public void setHydration(float newHydration)
    {
        currentHydration = newHydration;
    }

    


public void Die()
    {

          int mostRecentSlot = MainMenuSaveManager.Instance.GetMostRecentSaveSlot();
            MainMenuSaveManager.Instance.StartLoadedGame(mostRecentSlot);

            // Reload the current scene
            ReloadCurrentScene();
    }

    private void ReloadCurrentScene()
    {
        // Get the current scene name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneName);
    }
  
}
