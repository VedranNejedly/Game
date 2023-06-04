using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimatorController : MonoBehaviour
{
    public EnemySpawner es;
    public Animator doorAnimator;
    public bool doorIsClosing = false;
    private bool soundPlaying= false;
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doorIsClosing && !soundPlaying){
            soundPlaying =true;
            FindObjectOfType<AudioManager>().playSound("DoorSlide");

        }
        if(doorIsClosing){
            doorIsClosing=true;
            doorAnimator.SetBool("isClosing",true);
        }
    }
}
