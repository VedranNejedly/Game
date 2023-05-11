using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackArea : MonoBehaviour
{
  
    PlayerAttack playerAttack;
    PlayerHealth playerHealth;

    [SerializeField] GameObject player;
    void Start(){
        playerAttack = player.GetComponent<PlayerAttack>(); 
        playerHealth = player.GetComponent<PlayerHealth>(); 
    }
    
    private void OnTriggerEnter(Collider other){
        if(other.tag=="Enemy"){
            Debug.Log("Enemy");
            Enemy enemyHealth = other.GetComponent<Enemy>();
            if(enemyHealth != null){
                // health.Damage(damage);
                enemyHealth.Damage(playerAttack.meeleDamage);
                Debug.Log(playerAttack.meeleDamage);
                if(playerAttack.lifestealOnHit){
                    playerHealth.updateHealth(1);
                }
            }

        }
    }
}
