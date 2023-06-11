using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed = 10f;
    public float gravity = -9.81f;
    public Animator animator;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float jumpHeight = 3f;
    Vector3 velocity;
    public bool isVisionImpared = false;
    public Camera cam;
    


    private float timer = 0f;
    private float timeToUnfreeze = 5.0f;

    private float soundTimer = 0f;
    private bool canPlay = true;

    float timerToFixVision;
    public float VisionTimer = 5.0f;
    public bool frozen = false;



    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);
        if(isGrounded && velocity.y<0){
            velocity.y=-2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        //Provjeri da li se igrač kreće po bilo kojoj osi, ukoliko da pokreni prikladnu animaciju
        if(move != Vector3.zero){
            animator.SetBool("isMoving",true);
            if(soundTimer <= FindObjectOfType<AudioManager>().getSoundLength("Walking")){
                if(canPlay){
                    FindObjectOfType<AudioManager>().playSound("Walking");  
                    FindObjectOfType<AudioManager>().playSound("RunningBreathing");  

                }
                soundTimer += Time.deltaTime;
                canPlay=false;
            }

        }   
        else{
      
            
            animator.SetBool("isMoving",false);
            FindObjectOfType<AudioManager>().stopSound("Walking");  
            FindObjectOfType<AudioManager>().stopSound("RunningBreathing");  

            soundTimer = 0f;
            canPlay=true;

        }
        controller.Move(move * movementSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if(frozen){
            if(timer <= 0){
                movementSpeed *= 2.0f;
                frozen = false;
            }else{
                timer -= Time.deltaTime;
            }
        }

         if(isVisionImpared){
            if(timerToFixVision <= 0){
                cam.fieldOfView = 60;
                isVisionImpared = false;
            }else{
                timerToFixVision -= Time.deltaTime;
            }
        }

    }


    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="NextLevelTrigger"){
            TriggerNextLevel tnl = other.GetComponent<TriggerNextLevel>();
            if(tnl.nextLevelTrigger){
                controller.enabled = false;
                controller.transform.position = new Vector3(1,1,1);
                controller.enabled = true;
            }
            else{
                return;
            }

        }
    }
    //ITEMS EFFECTS CODE

    public void updateMovementSpeed(int movementSpeedMod){
        movementSpeed +=movementSpeedMod;
    }



    //Enemy effects on player movement

    public void isHitByFreezeEnemy(){
        if(!frozen){
            timer = timeToUnfreeze;
            movementSpeed *= 0.5f;
            frozen = true;
        }
    }

    public void impareVision(){
        timerToFixVision = VisionTimer;
        if(!isVisionImpared){
            cam.fieldOfView = 30;
            isVisionImpared = true;
        }

    }

}
