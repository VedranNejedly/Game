using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health = 10;

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
    }
}
