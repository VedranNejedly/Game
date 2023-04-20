using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    // public GameObject[] items;
    // private bool itemSpawned;

    public GameObject  closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;


    void Update(){  

        // if(waitTime<=0){
        //     if(spawnedBoss==false){
        //         for(int i=0;i<rooms.Count;i++){
        //             if(i==rooms.Count-1){
        //                 Instantiate(boss,rooms[i].transform.position,Quaternion.identity);
        //                 spawnedBoss=true;
        //             }
        //         }
        //     }
            // if(itemSpawned==false){
            //     //Ako nije spawnan item, spawnaj item na random rangeu prostorija od 0 - broj prostorija - 2 (rooms.Count-1 = boss room), prebaci item u tu prostoriju.
            //     Instantiate(items[Random.Range(0,items.Length)],rooms[Random.Range(0,rooms.Count-2)].transform.position,Quaternion.identity);
            //     itemSpawned=true;
            // }
        // }else{
        //     waitTime -= Time.deltaTime;
        // }

    }
    
}
