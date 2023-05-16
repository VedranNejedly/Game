using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Companion : MonoBehaviour
{
    public int companionID;
    private float healingCompanionCooldown = 10f;
    private bool companionCanHeal = true;
    [SerializeField] GameObject player; 
    private Vector3 followPlayer ;
    public float speed = 5f;
    public Transform target;
    NavMeshAgent nav; 


    // Start is called before the first frame update
    void Start()
    {
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
        nav.SetDestination(target.position);
        if(companionID==1){
            healingComapanion();
        }
    }


    void healingComapanion(){
        if(!companionCanHeal){
            return;
        }
        player.GetComponent<PlayerHealth>().updateHealth(1);
        StartCoroutine(StartHealingCooldown());

    }

    public IEnumerator StartHealingCooldown(){
        companionCanHeal = false;
        yield return new WaitForSeconds(healingCompanionCooldown);
        companionCanHeal = true;
    }
}
