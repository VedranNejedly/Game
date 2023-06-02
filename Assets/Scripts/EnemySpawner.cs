using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool wasInRoom = false;
    EnemyList enemyList;
    private int rand;
    private int randomRoll;
    public GameObject[] door;
    EnemySpawnAndKillCount esakc;
    public bool bossRoom = false;
    public bool isItemRoom = false;
    private RoomTemplates templates;



    // Start is called before the first frame update
    void Start()
    {
        esakc = GameObject.FindGameObjectWithTag("Player").GetComponent<EnemySpawnAndKillCount>();
        enemyList=GameObject.FindGameObjectWithTag("EnemyList").GetComponent<EnemyList>();
        randomRoll=  Random.Range(2,6);
        templates=GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

    }

    // Update is called once per frame
    void Update()
    {
        if(esakc.checkIfAllKilled() && wasInRoom){
        for(int i =0;i<door.Length;i++){
                door[i].GetComponent<DoorAnimatorController>().doorIsClosing = true;
            }
            Invoke("OpenDoors",0.4f);
        }
    }


    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            if(!isItemRoom){
                if(wasInRoom){
                    return;
                }
                wasInRoom=true;
                for(int i =0;i<door.Length;i++){
                    door[i].SetActive(true);
                    FindObjectOfType<AudioManager>().playSound("DoorSlide");

                }
                if(!bossRoom){
                    esakc.spawnCount(randomRoll);
                    for(int i=0;i<randomRoll;i++){
                        rand=Random.Range(0,enemyList.enemyList.Length);
                        Instantiate(enemyList.enemyList[rand], transform.position,Quaternion.identity);

                    }
                }else{
                    //Create boss and next level trigger.
                    esakc.spawnCount(1);
                    Instantiate(templates.boss,transform.position,Quaternion.identity);
                    Instantiate(templates.nextLevelTrigger,new Vector3(transform.position.x,2,transform.position.z),Quaternion.identity);

                }
            }
            

        }
    }

    public void setBoss(){
        bossRoom=true;
    }
    public void setItemRoom(){
        isItemRoom = true;
    }
    private void OpenDoors(){
        for(int i =0;i<door.Length;i++){
                door[i].SetActive(false); 
            }
    }

}
