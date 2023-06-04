using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject  closedRoom;
    public List<GameObject> rooms;
    public float waitTime;
    private bool spawnedBoss = false;
    public GameObject boss;
    public GameObject nextLevelTrigger;
    public GameObject[] items;
    bool itemSpawned = false;
    private int rand;
    int randomRoom;
    EnemySpawner enemySpawner;

    void Update(){  

        if(waitTime<=0){
            if(spawnedBoss==false){
                for(int i=0;i<rooms.Count;i++){
                    if(i==rooms.Count-1){
                        enemySpawner = rooms[i].GetComponentInChildren<EnemySpawner>();
                        enemySpawner.setBoss();
                    }
                }
            }
            if(itemSpawned == false){
                int rC = rooms.Count - 2;
                rand=Random.Range(0,rC);
                enemySpawner = rooms[rand].GetComponentInChildren<EnemySpawner>();
                Vector3 newPos = new Vector3(rooms[rand].transform.position.x,2,rooms[rand].transform.position.z);
                Instantiate(items[Random.Range(0,items.Length)],newPos,Quaternion.identity);
                itemSpawned=true;
                enemySpawner.setItemRoom();
            }
        }
        else{
            waitTime -= Time.deltaTime;
        }

        //         for(int i=0;i<rooms.Count;i++){
        //             if(i==rooms.Count-1){

        //                 // Instantiate(boss,rooms[i].transform.position,Quaternion.identity);
        //                 // Instantiate(nextLevelTrigger,rooms[i].transform.position,Quaternion.identity);

        //             }
        //         }
        //     }
        //     if(itemSpawned==false){
        //         Instantiate(items[Random.Range(0,items.Length)],rooms[Random.Range(0,rooms.Count-2)].transform.position,Quaternion.identity);
        //         itemSpawned=true;
        //     }


    }
    
}

