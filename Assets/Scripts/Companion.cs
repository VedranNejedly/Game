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
    
    public int companionMagicDamage = 1;
    private bool magicCircleIsActive = false;
    private float magicAttackTickCooldown = 3.0f;
    private float timer = 0f;
    private bool canTick = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        esakc = player.GetComponent<EnemySpawnAndKillCount>();
        target = player.transform;
        if(companionID==2){
            player.GetComponent<PlayerMovement>().updateMovementSpeed(5);
        }
        if(companionID==3){
            player.GetComponent<PlayerAttack>().enableCompanionDamageBoost();
        }

        nav = GetComponent<NavMeshAgent>();
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
        }

    }


    private void OnCollisionStay(Collision other){
        if(other.gameObject.tag=="Enemy"){
                magicField.SetActive(true);
                magicCircleIsActive=true;
                if(canTick){
                    canTick = false;
                    other.gameObject.GetComponent<Enemy>().TakeMagicDamage(companionMagicDamage);
                    timer = 0;
                }else{
                    timer+=Time.deltaTime;
                }
            }
        
    }

    void healingCompanion(){
        player.GetComponent<PlayerHealth>().updateHealth(1);
        StartCoroutine(StartHealingCooldown());

    }

    public IEnumerator StartHealingCooldown(){
        companionCanHeal = false;
        yield return new WaitForSeconds(healingCompanionCooldown);
        companionCanHeal = true;
    }

 
}
