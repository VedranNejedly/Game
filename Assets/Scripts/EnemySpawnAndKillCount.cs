using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAndKillCount : MonoBehaviour
{
    public int enemySpawnCount;
    public int enemyKillCount;

    public void spawnCount(int numberOfSpawned){
        enemySpawnCount+=numberOfSpawned;
    }

    public void killCount(){
        enemyKillCount++;
    }

    public bool checkIfAllKilled(){
        if(enemySpawnCount>0 && enemyKillCount>0 && enemySpawnCount == enemyKillCount){
            return true;
        }
        else{
            return false;
        }
    }
}
