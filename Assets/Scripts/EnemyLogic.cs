using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLogic : MonoBehaviour
{
    public Animator anim;
    public StorageBox storage;
    public float enemyHealth = 50f;
    public bool playerInRange;
    [SerializeField] AudioSource soundChannel;
    [SerializeField] AudioClip EnemyIdle;
    [SerializeField] AudioClip EnemyDie;
      public bool isDead;
    public float detectionRange = 10f;
    public float attackRange = 4f;
    public float attackDamage = 10f;
    public float shieldedattackDamage = 2;
    public float attackCooldown = 1f;
    public GameObject tools;
public Rigidbody rb;
    private Transform player;
    private NavMeshAgent navMeshAgent;
    private float nextAttackTime;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(tools.gameObject == null) { tools = GameObject.Find("ToolHolder"); } 
        navMeshAgent = GetComponent<NavMeshAgent>();
        soundChannel.PlayOneShot(EnemyIdle);
    }

    // Update is called once per frame
    void Update()
    {
                if (player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);


        if (distanceToPlayer <= detectionRange)
        {
            
            navMeshAgent.SetDestination(player.position);
            anim.SetTrigger("walk");

            
            if (distanceToPlayer <= attackRange)
            {
                
                if (Time.time >= nextAttackTime)
                {
                    AttackPlayer();
                    nextAttackTime = Time.time + attackCooldown;
                }
            }
        }
    }

       void AttackPlayer()
    {
       anim.SetTrigger("attack");
        Debug.Log("Enemy attacking player!");
        
        if( isDead == false){
            PlayerState.Instance.currentHealth -= attackDamage;
        }


    }

    public void TakeDamage(int damage)
    {
        if(isDead == false)
        {
        enemyHealth -= damage;

        if(enemyHealth <= 0)
        {
            anim.SetTrigger("Die");
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            Die();
        }

    }
    }

    void Die()
    {
        soundChannel.PlayOneShot(EnemyDie);
        navMeshAgent.enabled = false;
        soundChannel.enabled = false;
        rb.isKinematic = true;
        isDead = true;
       // Destroy(gameObject, 2);
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

    internal void AcessStorageEnemy()
    {
        storage.enabled = true;
    }
}
