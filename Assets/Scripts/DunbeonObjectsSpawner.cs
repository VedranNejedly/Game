using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DunbeonObjectsSpawner : MonoBehaviour
{

    private DungeonObjectsList dunObjList;
    private int rand;
    public GameObject[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        dunObjList=GameObject.FindGameObjectWithTag("DungeonObjects").GetComponent<DungeonObjectsList>();
        Spawn();
    }

    void Spawn(){
 
        for(int i = 0;i<spawnPoints.Length;i++){
            rand=Random.Range(0,dunObjList.dungeonObjects.Length);
            if(dunObjList.dungeonObjects[rand].name=="Trap Explosion"){
                Instantiate(dunObjList.dungeonObjects[rand],new Vector3(spawnPoints[i].transform.position.x,-2.2f,spawnPoints[i].transform.position.z), spawnPoints[i].transform.rotation);
            }
            else{
                Instantiate(dunObjList.dungeonObjects[rand],spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
            }


        }

        // rand=Random.Range(0,dunObjList.dungeonObjects.Length);
        // Instantiate(dunObjList.dungeonObjects[rand],transform.position, dunObjList.dungeonObjects[rand].transform.rotation);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
