using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health = 10;
    public bool isPoisoned = false;
    private float poisonTimer = 10.0f;
    private float timerForPoison;


    public void playerDie(){
        if(health<=0){
            Destroy(gameObject);
        }
    }

    public void upadateMaxHealth(int modificator){
        maxHealth +=modificator;
        health +=modificator;
    }

    public void updateHealth(int modificator){
        health+=modificator;
        if(health>maxHealth){
            health=maxHealth;
        }
        if(health<=0){
            playerDie();
        }
    }

    public void swordCurse(){
        health=1;
    }
    
    void Update(){
        playerDie();
        if(isPoisoned){
            if(timerForPoison <= 0){
                isPoisoned = false;
            }else{
                timerForPoison -= Time.deltaTime;
            }
        }
    }

    public void tickPoison(){
        timerForPoison = poisonTimer;
        if(!isPoisoned){
            timerForPoison = poisonTimer;
            health -= 1;
            isPoisoned = true;
        }
    }
}
