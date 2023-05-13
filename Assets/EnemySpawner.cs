using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public bool isPlayerFirstTimeInTheRoom = true;
    EnemyList enemy;
    private int rand;
    private int randomRoll;
    // private Player player;


    // Start is called before the first frame update
    void Start()
    {
        enemy=GameObject.FindGameObjectWithTag("EnemyList").GetComponent<EnemyList>();
        randomRoll=  Random.Range(2,6);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


     void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){

            if(!isPlayerFirstTimeInTheRoom){
                return;
            }
            if(isPlayerFirstTimeInTheRoom){
                for(int i=0;i<randomRoll;i++){
                    rand=Random.Range(0,enemy.enemyList.Length);
                    Instantiate(enemy.enemyList[rand], transform.position,Quaternion.identity);
                    isPlayerFirstTimeInTheRoom=false;
                }

            }
        }

    }
}
