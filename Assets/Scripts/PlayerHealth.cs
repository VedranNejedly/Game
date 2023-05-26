using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health = 10;
    public int playerArmor = 40;
    public int maxPlayerArmor = 40;
    public bool isPoisoned = false;
    private float poisonTimer = 10.0f;
    private float timerForPoison;

    public bool isBurning = false;
    private float burnTimer = 10.0f;
    private float timerForBurn;



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

    public void InflictDamage(int damage){
        if(damage>=playerArmor && playerArmor>=0){
            damage = damage - playerArmor;
            playerArmor = 0;
            health = health - damage;
        }else{
            playerArmor=playerArmor - damage;
        }
    }


    public void UpdateMaxArmor(int value){
        maxPlayerArmor+=value;
        playerArmor+=value;
    }

    public void UpdateArmor(int value){
        playerArmor+=value;
        if(playerArmor>maxPlayerArmor){
            playerArmor = maxPlayerArmor;
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

    public void setOnFire(){
        Debug.Log("I am burning");
        isBurning =true;
    }
}
