using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    public string animalName;
    public bool playerInRange;

    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth;

    [Header("Sounds")]
    [SerializeField] AudioSource soundChannel;
    [SerializeField] AudioClip rabbitHitAndScream;
    [SerializeField] AudioClip rabbitHitAndDie;

    private Animator animator;
    public bool isDead;

   // [SerializeField] ParticleSystem bloodsplashP;
    public GameObject bloodPuddle;

    enum AnimalType
    {
        Rabbit,
        Dear,
    }

    [SerializeField] AnimalType thisAnimalType;

    

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if(isDead == false)
        {
        currentHealth -= damage;

      //  bloodsplashP.Play();

        if(currentHealth <= 0)
        {
            PlayDyingSound();

           animator.SetTrigger("Die");
           GetComponent<AI_Movement>().enabled = false;
           bloodPuddle.SetActive(true);
           isDead = true;
        }
        else
        {
            PlayHitSound();
            
        }
    }
}

    private void PlayDyingSound()
    {
        switch(thisAnimalType)
        {
            case AnimalType.Rabbit:
            soundChannel.PlayOneShot(rabbitHitAndDie);
            break;
            case AnimalType.Dear:
          //  soundChannel.PlayOneShot(); //Dear Die Clip
            break;

            default:
            break;
        }
    }

    private void PlayHitSound()
    {
             switch(thisAnimalType)
        {
            case AnimalType.Rabbit:
            soundChannel.PlayOneShot(rabbitHitAndScream);
            break;
            case AnimalType.Dear:
          //  soundChannel.PlayOneShot(); //Dear scream Clip
            break;

            default:
            break;
        }
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

    void Update()
    {
        
    }
}
