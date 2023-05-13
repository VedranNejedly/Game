using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    EnemySpawnAndKillCount esakc;

    public Animator animator;
    public int health = 10;

    void Start(){
        esakc = GameObject.FindGameObjectWithTag("Player").GetComponent<EnemySpawnAndKillCount>();
    }

    public void Damage(int damage){
        health = health - damage;
        CheckHealth();
    }
    
    private void CheckHealth(){
        if(health<=0){
            Invoke("deathAnimation", 2.0f);
            esakc.killCount();
            Destroy(gameObject);
        }
    }

    private void deathAnimation(){
        animator.SetBool("isDying",true);
    }





    // private void OnTriggerEnter(Collider other){
    //     if(other.gameObject.tag=="Player"){
    //         animator.SetBool("isAttacking",true);
    //     }
    // }
    //  private void OnTriggerExit(Collider other){
    //     if(other.gameObject.tag=="Player"){
    //         animator.SetBool("isAttacking",false);
    //     }
    // }


}
