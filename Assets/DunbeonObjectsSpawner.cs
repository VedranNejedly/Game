using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DunbeonObjectsSpawner : MonoBehaviour
{

    private DungeonObjectsList dunObjList;
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        dunObjList=GameObject.FindGameObjectWithTag("DungeonObjects").GetComponent<DungeonObjectsList>();
        Spawn();
    }

    void Spawn(){
        rand=Random.Range(0,dunObjList.dungeonObjects.Length);
        Instantiate(dunObjList.dungeonObjects[rand],transform.position, dunObjList.dungeonObjects[rand].transform.rotation);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
