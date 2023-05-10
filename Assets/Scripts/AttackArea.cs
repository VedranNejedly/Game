using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackArea : MonoBehaviour
{
  
    PlayerAttack playerAttack;
    [SerializeField] GameObject player;
    void Start(){
        playerAttack = player.GetComponent<PlayerAttack>(); 
    }
    
    private void OnTriggerEnter(Collider other){
        if(other.tag=="Enemy"){
            Debug.Log("Enemy");
            Enemy health = other.GetComponent<Enemy>();
            if(health != null){
                // health.Damage(damage);
                health.Damage(playerAttack.meeleDamage);

                Debug.Log(playerAttack.meeleDamage);
            }

        }
    }
}
