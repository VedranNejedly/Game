using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyList : MonoBehaviour
{

    public GameObject[] itemsToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("addCompanionToTheArray",.5f);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addCompanionToTheArray(){
        itemsToDestroy[itemsToDestroy.Length-1] = GameObject.FindGameObjectWithTag("Companion");
    }
}
