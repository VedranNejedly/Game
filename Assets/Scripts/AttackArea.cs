using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttackArea : MonoBehaviour
{
  
    PlayerAttack playerAttack;
    PlayerHealth playerHealth;
    private bool enemyIsInRange = false;
    List <GameObject> currentCollisions = new List <GameObject> ();

    private float soundTimer =0f;



    [SerializeField] GameObject player;
    void Start(){
        playerAttack = player.GetComponent<PlayerAttack>(); 
        playerHealth = player.GetComponent<PlayerHealth>(); 
    }
    
    void Update(){
        if(soundTimer>0){
            soundTimer-=Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other){
        currentCollisions.Clear();
        enemyIsInRange = false;
        currentCollisions.Add (other.gameObject);
    
        if(other.tag=="Enemy" && currentCollisions.Contains(other.gameObject)){
            if(soundTimer<=0){
                FindObjectOfType<AudioManager>().playSound("SwordSlashAndHit");  
                soundTimer = 1.0f;
            }
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

        foreach (GameObject gObject in currentCollisions) {
            if(gObject.tag == "Enemy"){
                enemyIsInRange = true;
            }
         }
        if(!enemyIsInRange){
            if(soundTimer<=0){
                FindObjectOfType<AudioManager>().playSound("SwordSwingNoHit");
                soundTimer = 1.0f;
            }
        }
    }

}
