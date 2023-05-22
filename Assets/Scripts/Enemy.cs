using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    EnemySpawnAndKillCount esakc;
    TriggerNextLevel tnl;
    PlayerHealth PlayerHealth;
    PlayerBlock playerBlocking;

    // public Animator animator;
    public int health = 10;
    public bool isBoss = false;
    public bool bossIsDead = false;
    public int damage = 5;
    public bool attacking = false;
    public bool isDying = false;
    public bool isTakingDamage = false;

    public bool isChasing = true;

    public NavMeshAgent nav;
    public Transform player;


    public float attackCooldown = 3.0f;
    public bool enemyAlreadyAttacked = false;

    public float sightRange,attackRange;
    public bool playerInSight, playerInAttackRange;

    void Start(){
        esakc = GameObject.FindGameObjectWithTag("Player").GetComponent<EnemySpawnAndKillCount>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerBlocking = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBlock>();


        nav = GetComponent<NavMeshAgent>();
    }

    void Update(){
        // //If player is in sight and in attack range
        // playerInAttackRange=Physics.CheckSphere(transform.position,attackRange,whatIsPlayer);
        // playerInSight=Physics.CheckSphere(transform.position,sightRange,whatIsPlayer);
    
        // if(playerInSight && !playerInAttackRange){
            if(isChasing && !isDying){
                ChasePlayer();
            }
    // }
        // if(playerInAttackRange && playerInSight){
        //     AttackPlayer();
        // }
    
    }

    public void Damage(int damage){
        health = health - damage;
        isTakingDamage = true;
        CheckHealth();
    }
    
    private void CheckHealth(){
        if(health<=0){
            if(isBoss){
                bossIsDead = true;
                tnl = GameObject.FindGameObjectWithTag("NextLevelTrigger").GetComponent<TriggerNextLevel>();
                tnl.canTriggerNextLevel();

            }
            // Invoke("deathAnimation", 2.0f);
            esakc.killCount();
            nav.SetDestination(transform.position);
            isDying = true;
            GetComponent<Collider>().enabled = false;
            Invoke("destoryEnemy",2.0f);
            // Destroy(gameObject);
        }
        else{
            isTakingDamage = true;
        }
    }
    private void destoryEnemy(){
        Destroy(gameObject);
    }
    // private void deathAnimation(){
    //     animator.SetBool("isDying",true);
    // }



    private void ChasePlayer(){
        nav.SetDestination(player.position);
        // animator.SetBool("isChasing",true);

    }

    private void AttackPlayer(){
        nav.SetDestination(transform.position);
        transform.LookAt(player);
        isChasing = false;
        if(enemyAlreadyAttacked){
            return;
        }
        attacking = true;
        // animator.SetBool("isAttacking",true);
        // animator.SetBool("isChasing",false);

        if(!(playerBlocking.playerIsBlocking)){
            PlayerHealth.updateHealth(-damage);
        }
        enemyAlreadyAttacked = true;
        attacking = false;
        Invoke("ResetAttack",1.0f);
        // StartCoroutine(ResetAttack());
    }


    private void ResetAttack(){
        enemyAlreadyAttacked = false;
        attacking = true;
    }

 

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player"){
            AttackPlayer();
        }
    }

     private void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Player"){
            attacking = false;
            isChasing = true;
        }
    }

    private void OnTriggerStay(Collider other){
        if(other.gameObject.tag=="Player"){
            attacking = true;
            AttackPlayer();

        }
    }


}
