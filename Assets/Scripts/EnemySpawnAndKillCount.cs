using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAndKillCount : MonoBehaviour
{
    public int enemySpawnCount;
    public int enemyKillCount;
    private bool voicelinePlayed=false;  
    int range;  
    private AudioManager audioManager;

    void Start(){
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void spawnCount(int numberOfSpawned){
        enemySpawnCount+=numberOfSpawned;
        voicelinePlayed = false;
        range = Random.Range(0,5);
        if(range ==0){
            audioManager.playSound("NiceFellas");
        }
        if(range == 1){
            audioManager.playSound("LetMeTellYouSomething");
        }
        if(range == 3){
            audioManager.playSound("MonstersOverSnakes");
        }
        if(range == 4){
            audioManager.playSound("ScreamScared");
        }
        if(range == 5){
            audioManager.playSound("PutYourHandsDown");
        }
        
        
    }

    public void killCount(){
        ++enemyKillCount;
        if(enemyKillCount == 10){
            audioManager.playSound("10Kills");
        }
        if(enemyKillCount == 67){
            audioManager.playSound("67Kills");
        }


    }

    public bool checkIfAllKilled(){
        if(enemySpawnCount>0 && enemyKillCount>0 && enemySpawnCount == enemyKillCount){
            if(!voicelinePlayed){
                voicelinePlayed = true;
                range = Random.Range(0,1);
                Debug.Log(range);
                if(range ==0){
                    audioManager.playSound("AllEnemiesAreDead");
                }
                if(range == 1){
                    audioManager.playSound("AllEnemiesAreDead1");
                }
            }

            return true;
        }
        else{
            return false;
        }
    }
}
