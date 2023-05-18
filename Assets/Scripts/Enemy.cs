using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    EnemySpawnAndKillCount esakc;
    TriggerNextLevel tnl;
    PlayerHealth PlayerHealth;

    public Animator animator;
    public int health = 10;
    public bool isBoss = false;
    public bool bossIsDead = false;
    public int damage = 5;

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

        nav = GetComponent<NavMeshAgent>();
    }

    void Update(){
        // //If player is in sight and in attack range
        // playerInAttackRange=Physics.CheckSphere(transform.position,attackRange,whatIsPlayer);
        // playerInSight=Physics.CheckSphere(transform.position,sightRange,whatIsPlayer);
    
        // if(playerInSight && !playerInAttackRange){
            ChasePlayer();
        // }
        // if(playerInAttackRange && playerInSight){
        //     AttackPlayer();
        // }
    
    }

    public void Damage(int damage){
        health = health - damage;
        CheckHealth();
    }
    
    private void CheckHealth(){
        if(health<=0){
            if(isBoss){
                bossIsDead = true;
                tnl = GameObject.FindGameObjectWithTag("NextLevelTrigger").GetComponent<TriggerNextLevel>();
                tnl.canTriggerNextLevel();

            }
            Invoke("deathAnimation", 2.0f);
            esakc.killCount();
            Destroy(gameObject);
        }
    }

    private void deathAnimation(){
        animator.SetBool("isDying",true);
    }



    private void ChasePlayer(){
        nav.SetDestination(player.position);
        Debug.Log("I am chasing");
    }

    private void AttackPlayer(){
        nav.SetDestination(transform.position);
        transform.LookAt(player);
        if(enemyAlreadyAttacked){
            return;
        }
        animator.SetBool("isAttacking",true);
        PlayerHealth.updateHealth(-damage);
        enemyAlreadyAttacked = true;
        Invoke("ResetAttack",3.0f);
        // StartCoroutine(ResetAttack());
    }


    private void ResetAttack(){
        enemyAlreadyAttacked = false;
        animator.SetBool("isAttacking",false);

    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player"){
            AttackPlayer();
        }
    }

     private void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Player"){
            animator.SetBool("isAttacking",false);
            ChasePlayer();
        }
    }

    private void OnTriggerStay(Collider other){
        if(other.gameObject.tag=="Player"){
            AttackPlayer();
        }
    }


}
