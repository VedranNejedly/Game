using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionSpawner : MonoBehaviour
{

    public int val;
    public GameObject[] companions;

    void Awake(){
        if(GameObject.FindGameObjectWithTag("ValueHolder") != null){
            val = GameObject.FindGameObjectWithTag("ValueHolder").GetComponent<ValueHolder>().value;
            Destroy(GameObject.FindGameObjectWithTag("ValueHolder"));
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(companions[val],new Vector3(transform.position.x,0,transform.position.z),companions[val].transform.rotation);
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
