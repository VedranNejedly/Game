using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyList : MonoBehaviour
{

    public List<GameObject> itemsToDestroy;
    public GameObject RunStatsSaver;

    // Start is called before the first frame update
    void Start()
    {
        RunStatsSaver = GameObject.FindGameObjectWithTag("RunStatsSaver");
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
        itemsToDestroy.Add(GameObject.Find("ItemList"));
        itemsToDestroy.Add(GameObject.Find("Canvas"));
        itemsToDestroy.Add(GameObject.FindGameObjectWithTag("ValueHolder"));

    }

    public void DestroyerToMenu(){
        Destroy(RunStatsSaver);

        for(int i=0;i<itemsToDestroy.Count;i++){
            Destroy(itemsToDestroy[i]);
        }
        Destroy(GameObject.Find("DirectionalLight"));

        Destroy(gameObject);
    }

    public void DestroyAndReset(){
        for(int i=0;i<itemsToDestroy.Count;i++){
            if((itemsToDestroy[i].name!= "ValueHolder")){
                Destroy(itemsToDestroy[i]);
            }
        }
        Destroy(gameObject);

    }
}
