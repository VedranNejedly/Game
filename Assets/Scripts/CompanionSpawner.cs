using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionSpawner : MonoBehaviour
{

    public int val;
    public GameObject[] companions;

    void Awake(){
        val = GameObject.FindGameObjectWithTag("ValueHolder").GetComponent<ValueHolder>().value;
        Destroy(GameObject.FindGameObjectWithTag("ValueHolder"));
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(companions[val],transform.position,companions[val].transform.rotation);
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
