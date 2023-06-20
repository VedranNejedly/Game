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
    private bool mercyOfAGod;
    private bool canForgeByBlood = false;
    private bool tickedLoss = false;

    public bool hasAntiTrapBracer = false;

    public bool isBurning = false;
    private float burnTimer = 10.0f;
    private float timerForBurn;

    public GameObject deathScreen;
    public PauseMenu pauseMenu;
    private AudioManager audioManager;

    private bool lowHpVoicelinePlayed = false;


    void Start(){
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.X)){
            if(canForgeByBlood){
                ForgeArmorByBlood();
                }
            }


        playerDie();

        if(health<3 && !lowHpVoicelinePlayed){
            audioManager.playSound("LowHealth");
        }
        if(isPoisoned){
            if(timerForPoison <= 0){
                isPoisoned = false;
                audioManager.stopSound("Cough");
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
            audioManager.playSound("Cough");
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
            health -=3;

        }
    }

        public void playerDie(){
        if(health<=0){
            if(!tickedLoss){
                GameObject.FindGameObjectWithTag("RunStatsSaver").GetComponent<RunStats>().LoseARun();
                tickedLoss= true;
            }
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.gameIsPaused = true;
            pauseMenu.gameCanBePaused = false;
            // Destroy(gameObject);
        }
    }

    public void upadateMaxHealth(int modificator){
        maxHealth +=modificator;
        health +=modificator;
        if(health>10 && lowHpVoicelinePlayed){
            lowHpVoicelinePlayed = false;
        }
    }

    public void updateHealth(int modificator){
        health+=modificator;
        if(health>10 && lowHpVoicelinePlayed){
            lowHpVoicelinePlayed = false;
        }
        if(health>maxHealth){
            health=maxHealth;
        }
        if(health<=0 && mercyOfAGod){
            mercyOfAGod = false;
            health = maxHealth;
            playerArmor = maxPlayerArmor/2;
        }
        if(health<=0 && !mercyOfAGod){
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
        playerArmor = playerArmor/2;
        maxPlayerArmor = maxPlayerArmor/2;
        maxHealth = maxHealth/2;
    }

    public void antiTrapBracer(){
        hasAntiTrapBracer =true;
    }

    public void MercyOfAGod(){
        mercyOfAGod = true;
    }

    public void ForgeByBlood(){
        canForgeByBlood = true;
    }

    private void ForgeArmorByBlood(){
        if(playerArmor < maxPlayerArmor && health>1){
            playerArmor+=1;
            health-=1;
        }
    }
}
