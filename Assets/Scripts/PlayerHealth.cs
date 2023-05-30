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

    public GameObject deathScreen;
    public PauseMenu pauseMenu;


    public void playerDie(){
        if(health<=0){
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.gameIsPaused = true;
            // Destroy(gameObject);
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
                FindObjectOfType<AudioManager>().stopSound("Cough");
            }else{
                timerForPoison -= Time.deltaTime;
            }
        }

        if(isBurning){
            if(timerForBurn <=0){
                isBurning = false;
            }else{
                timerForBurn -= Time.deltaTime;
            }
        }
    }

    public void tickPoison(){
        timerForPoison = poisonTimer;
        if(!isPoisoned){
            FindObjectOfType<AudioManager>().playSound("Cough");
            timerForPoison = poisonTimer;
            health -= 1;
            isPoisoned = true;
        }
    }

    public void setOnFire(){
        timerForBurn = burnTimer;
        if(!isBurning){
            isBurning =true;
            timerForBurn = burnTimer;

        }
    }
}
