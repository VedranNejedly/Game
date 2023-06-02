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
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void canTriggerNextLevel(){
        nextLevelTrigger = true;
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player"){
            if(nextLevelTrigger){
                loadNextScene();
            }
        }
    }
    
    void loadNextScene(){
        FindObjectOfType<AudioManager>().stopSound("TrapSlide");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

}
