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
    public List<GameObject> items;
    public ItemList itemList;
    public float waitTime;
    private bool spawnedBoss = false;
    public GameObject boss;
    public GameObject nextLevelTrigger;
    bool itemSpawned = false;
    private int rand;
    int randomRoom;
    EnemySpawner enemySpawner;

    void Start(){
        itemList = GameObject.FindGameObjectWithTag("ItemList").GetComponent<ItemList>();
        items = itemList.items;
    }

    void Update(){  

        if(waitTime<=0){
            if(spawnedBoss==false){
                spawnedBoss = true;
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
                int randomItem = Random.Range(0,items.Count);
                Vector3 newPos = new Vector3(rooms[rand].transform.position.x,2,rooms[rand].transform.position.z);
                Instantiate(items[randomItem],newPos,items[randomItem].GetComponent<Transform>().rotation);
                items.RemoveAt(randomItem);
                itemSpawned=true;
                enemySpawner.setItemRoom();
            }
        }
        else{
            waitTime -= Time.deltaTime;
        }
    }
}


