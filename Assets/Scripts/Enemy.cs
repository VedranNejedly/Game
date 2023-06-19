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
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;

    // public Animator animator;
    public int health = 10;
    public bool isBoss = false;
    public bool bossIsDead = false;
    public int damage = 5;
    public bool attacking = false;
    public bool isDying = false;
    public bool isTakingDamage = false;
    public string type = "Normal";
    private bool canBeEnraged = false;
    private bool enraged = false;
    private bool takeReducedDamage = false;
    private bool isATraitor = false;
    private float traitorTimer = 0f;

    public float speed = 5.0f;

    private bool onFire = false;
    private float fireTickTime = 2.0f;
    private float fireTickTimer = 2.0f;
    private bool killed = false;
    public bool idle = false;

    public GameObject fire;
    public GameObject explosion;

    public bool isChasing = true;

    public NavMeshAgent nav;
    public Transform player;
    public AudioSource audioSource;



    public float attackCooldown = 3.0f;
    public bool enemyAlreadyAttacked = false;

    void Awake(){
        if(isBoss || type=="Dragon" || type == "OrcBreserker"){
            canBeEnraged = true;
        }
    }

    void Start(){
        esakc = GameObject.FindGameObjectWithTag("Player").GetComponent<EnemySpawnAndKillCount>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerBlocking = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBlock>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();

        audioSource = this.GetComponent<AudioSource>();



        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
    }

    void Update(){
            if(isATraitor && traitorTimer >0){
                traitorTimer-=Time.deltaTime;
            }
            if(isChasing && !isDying){
                ChasePlayer();
            }
            if(onFire){
                if(fireTickTimer <0){
                Damage(1);
                fireTickTimer = fireTickTime;
                }else{
                    fireTickTimer -= Time.deltaTime;
                }
                
            }

    }

    public void Damage(int damage){
        if(takeReducedDamage){
            damage=damage/2;
        }
        health = health - damage;
        isTakingDamage = true;
        CheckHealth();
    }

    public void TakeMagicDamage(int damage){
        if(type=="Dragon" || type=="ThickSkinned"){
            return;
        }
        damage = damage/2;
        health = health - damage;
        isTakingDamage = true;
        CheckHealth();
    }
    
    private void CheckHealth(){
        if(canBeEnraged && health <50 && !enraged){
            enraged = true;
            damage = damage*2;
            takeReducedDamage = true;
        }
        if(health<=0){
            if(isBoss){
                bossIsDead = true;
                tnl = GameObject.FindGameObjectWithTag("NextLevelTrigger").GetComponent<TriggerNextLevel>();
                tnl.canTriggerNextLevel();
            }
            if(!killed && type!="Bomber"){
                esakc.killCount();
                killed = true;
            }
            // Invoke("deathAnimation", 2.0f);
            nav.SetDestination(transform.position);
            isDying = true;
            GetComponent<Collider>().enabled = false;
            // playerAttack.enemyIsInRange = false;
            Invoke("destroyEnemy",2.0f);
            // Destroy(gameObject);
        }
        else{
            isTakingDamage = true;
        }
    }
    private void destroyEnemy(){
        Destroy(gameObject);
    }
    // private void deathAnimation(){
    //     animator.SetBool("isDying",true);
    // }



    private void ChasePlayer(){
        attacking = false;
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
        FindObjectOfType<AudioManager>().playSound("EnemyRoar");

        if(!(playerBlocking.playerIsBlocking)){
            PlayerHealth.InflictDamage(damage);
            if(type == "Ice"){
                playerMovement.isHitByFreezeEnemy();
            }
            if(type == "Poison"){
                PlayerHealth.tickPoison();
            }
            if(type == "Fire"){
                PlayerHealth.setOnFire();
            }
            if(type == "Dark"){
                playerMovement.impareVision();
            }

        }
        enemyAlreadyAttacked = true;
        attacking = false;
        Invoke("ResetAttack",1.5f);
        // StartCoroutine(ResetAttack());
    }


    private void ResetAttack(){
        enemyAlreadyAttacked = false;
        // attacking = false;
    }

 
    public void SetOnFire(){
        onFire = true;
        fire.SetActive(true);
    }

    public void BecomeATraitor(){
        isATraitor = true;
    }
    
    public void Explode(){
        explosion.SetActive(true);
        esakc.killCount();
        health=0;
        isDying = true;
        Invoke("destroyEnemy",1.0f);
    }



    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player"){
            AttackPlayer();
        }

        if(other.gameObject.tag == "Enemy"){
            var magnitude = 50;
        // calculate force vector
            var force = transform.position - other.transform.position;
        // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
        }
    }

    //  private void OnCollisionEnter(Collision other){
    //     if(other.gameObject.tag=="Player" && type != "Bomber"){
    //         AttackPlayer();
    //     }
    //     if(other.gameObject.tag=="Player" && type == "Bomber"){
    //         nav.SetDestination(transform.position);
    //         attacking = false;
    //         isChasing = false;
    //         idle = true;
    //         Invoke("Explode",3.0f);
    //     }
    //     if(other.gameObject.tag == "Enemy"){
    //         if(isATraitor && traitorTimer <=0){
    //             other.gameObject.GetComponent<Enemy>().Damage(1);
    //             damage+=2;
    //             traitorTimer = 4.0f;

    //         }
    //         // var magnitude = 10;
    //     // calculate force vector
    //         // var force = transform.position - other.transform.position;
    //     // normalize force vector to get direction only and trim magnitude
    //         // force.Normalize();
    //         // gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
    //     }
    // }

     private void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Player"){
            attacking = false;
            isChasing = true;
        }
    }

    
    //  private void OnCollisionExit(Collision other){
    //     if(other.gameObject.tag=="Player" && type != "Bomber"){
    //         attacking = false;
    //         isChasing = true;
    //     }
    // }


    private void OnTriggerStay(Collider other){
        if(other.gameObject.tag=="Player"){
            attacking = true;
            AttackPlayer();
            }
            
        if(other.gameObject.tag == "Enemy"){
            if(isATraitor && traitorTimer <=0){
                other.gameObject.GetComponent<Enemy>().Damage(1);
                damage+=2;
                traitorTimer = 4.0f;
            }
    //     if(other.gameObject.tag == "Enemy"){
    //     var magnitude = 1;
    // // calculate force vector
    //     var force = transform.position - other.transform.position;
    // // normalize force vector to get direction only and trim magnitude
    //     force.Normalize();
    //     gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
    }
    }

    //     private void OnCollisionStay(Collision other){
    //     // if(other.gameObject.tag=="Player" && type !="Bomber"){
    //     //     attacking = true;
    //     //     AttackPlayer();
    //     //     }

        // if(other.gameObject.tag == "Enemy"){
        //     if(isATraitor && traitorTimer <=0){
        //         other.gameObject.GetComponent<Enemy>().Damage(1);
        //         damage+=2;
        //         traitorTimer = 4.0f;
        //     }
    //         var magnitude =1;
    //     // calculate force vector
    //         var force = transform.position - other.transform.position;
    //         Debug.Log(force);
    //     // normalize force vector to get direction only and trim magnitude
    //         force.Normalize();
    //         gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
    //     }
    // }


}
