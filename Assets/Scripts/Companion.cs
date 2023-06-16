using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Companion : MonoBehaviour
{
    public int companionID;
    EnemySpawnAndKillCount esakc;
    private float healingCompanionCooldown = 10f;
    private bool companionCanHeal = true;
    private GameObject player; 
    private Vector3 followPlayer ;
    public float speed = 5f;
    private Transform target;
    NavMeshAgent nav; 
    GameObject enemy;
    public GameObject magicField;
    private Transform healingCircle;
    public int companionMagicDamage = 1;
    private bool magicCircleIsActive = false;
    private float magicAttackTickCooldown = 3.0f;
    private float timer = 0f;
    private bool canTick = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healingCircle = player.transform.Find("HealingCircle");
        esakc = player.GetComponent<EnemySpawnAndKillCount>();
        target = player.transform;
        if(companionID==2){
            player.GetComponent<PlayerMovement>().updateMovementSpeed(5);
        }
        if(companionID==3){
            player.GetComponent<PlayerAttack>().enableCompanionDamageBoost();
        }

        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        if(companionID==1 && companionCanHeal){
                healingCompanion();
            }
        if(esakc.enemySpawnCount==esakc.enemyKillCount){
            nav.SetDestination(new Vector3(target.position.x+5,0,target.position.z+5));
            if(magicCircleIsActive){
                magicField.SetActive(false);
                magicCircleIsActive=false;

            }

        }
        else{
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            nav.SetDestination(enemy.GetComponent<Transform>().position);

        }

        if(timer>magicAttackTickCooldown){
            canTick=true;
        }else{
            timer+=Time.deltaTime;
        }

    }


    private void OnTriggerStay(Collider other){
        if(other.gameObject.tag=="Enemy"){
                Debug.Log("Am coliding with the enemy");
                magicField.SetActive(true);
                magicCircleIsActive=true;
                if(canTick){
                    Debug.Log("Am dealing damage");

                    canTick = false;
                    other.gameObject.GetComponent<Enemy>().TakeMagicDamage(companionMagicDamage);
                    timer = 0;
            }
        }
    }

    void healingCompanion(){
        if(!(player.GetComponent<PlayerHealth>().health == player.GetComponent<PlayerHealth>().maxHealth)){
            player.GetComponent<PlayerHealth>().updateHealth(1);
            healingCircle.gameObject.SetActive(true);
            Invoke("TurnOffHealingCircle",1.5f);
            StartCoroutine(StartHealingCooldown());
        }

    }

    void TurnOffHealingCircle(){
        healingCircle.gameObject.SetActive(false);
    }

    public IEnumerator StartHealingCooldown(){
        companionCanHeal = false;
        yield return new WaitForSeconds(healingCompanionCooldown);
        companionCanHeal = true;

    }

 
}
