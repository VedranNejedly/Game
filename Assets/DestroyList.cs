using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyList : MonoBehaviour
{

    public List<GameObject> itemsToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(addItemsToList());

        // Invoke("addCompanionToTheArray",.5f);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator addItemsToList(){
        yield return new WaitForSeconds(0.2f);
        itemsToDestroy.Add(GameObject.FindGameObjectWithTag("Companion"));
        itemsToDestroy.Add(GameObject.FindGameObjectWithTag("Player"));
        itemsToDestroy.Add(GameObject.Find("AudioManager"));
        itemsToDestroy.Add(GameObject.Find("Canvas"));
        itemsToDestroy.Add(GameObject.FindGameObjectWithTag("ValueHolder"));
    }
}
