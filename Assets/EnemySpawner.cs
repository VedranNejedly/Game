using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public bool wasInRoom = false;
    EnemyList enemy;
    private int rand;
    private int randomRoll;
    public GameObject[] door;
    EnemySpawnAndKillCount esakc;
    // [SerializeField] EnemyCheck enemyCheck;



    // private Player player;


    // Start is called before the first frame update
    void Start()
    {
        esakc = GameObject.FindGameObjectWithTag("Player").GetComponent<EnemySpawnAndKillCount>();
        enemy=GameObject.FindGameObjectWithTag("EnemyList").GetComponent<EnemyList>();
        randomRoll=  Random.Range(2,6);

    }

    // Update is called once per frame
    void Update()
    {

        if(esakc.checkIfAllKilled()){
            for(int i =0;i<door.Length;i++){
                door[i].SetActive(false);
            }
        }
        
    }


    void OnTriggerEnter(Collider other){

        if(other.CompareTag("Player")){

            if(wasInRoom){
                return;
            }
            wasInRoom=true;
            // for(int i =0;i<door.Length;i++){
            //     door[i].SetActive(true);
            // }
            for(int i =0;i<door.Length;i++){
                door[i].SetActive(true);
            }
            esakc.spawnCount(randomRoll);
            for(int i=0;i<randomRoll;i++){
                rand=Random.Range(0,enemy.enemyList.Length);
                Instantiate(enemy.enemyList[rand], transform.position,Quaternion.identity);

            }
        }
    }
}
