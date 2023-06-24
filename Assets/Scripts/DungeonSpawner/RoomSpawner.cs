using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int OpeningDirection;
    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    void Start(){
        templates=GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn",0.5f);
    }
    void Spawn()
    {
       if(spawned==false){
        if(OpeningDirection==1){
            //OpeningDirection 1 znaci da trebamo sobu sa vratima prema dolje
            rand=Random.Range(0,templates.bottomRooms.Length);
            Instantiate(templates.bottomRooms[rand],transform.position, templates.bottomRooms[rand].transform.rotation);
            }else if(OpeningDirection==2){
            //OpeningDirection 2 znaci da trebamo sobu sa vratima prema lijevo
            rand=Random.Range(0,templates.leftRooms.Length);
            Instantiate(templates.leftRooms[rand],transform.position, templates.leftRooms[rand].transform.rotation);

            }else if(OpeningDirection==3){
            //OpeningDirection 3 znaci da trebamo sobu sa vratima prema gore
            rand=Random.Range(0,templates.topRooms.Length);

            Instantiate(templates.topRooms[rand],transform.position, templates.topRooms[rand].transform.rotation);

            }else if(OpeningDirection==4){
            //OpeningDirection 4 znaci da trebamo sobu sa vratima prema desno
            
            rand=Random.Range(0,templates.rightRooms.Length);
            Instantiate(templates.rightRooms[rand],transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned=true;
       }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("SpawnPoint")){
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
                Instantiate(templates.closedRoom, transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
            spawned=true;
        }
    }
}
