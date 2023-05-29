using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{

    public bool playerIsBlocking = false;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)){
            playerIsBlocking = true;
            animator.SetBool("isBlocking",true);

        }
        else{
            playerIsBlocking = false;
            animator.SetBool("isBlocking",false);

        }
    }
}
