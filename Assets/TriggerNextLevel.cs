using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TriggerNextLevel : MonoBehaviour
{

    public bool nextLevelTrigger = false;
    public GameObject player;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void canTriggerNextLevel(){
        nextLevelTrigger = true;
    }

    // private void OnTriggerEnter(Collider other){
    //     if(other.gameObject.tag=="Player"){
    //         if(nextLevelTrigger){
    //             // Invoke("loadNextScene",3.0f);
    //         }
    //     }
    // }
    
    void loadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

}
