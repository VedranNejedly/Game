using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{

    public bool playerIsBlocking = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)){
            playerIsBlocking = true;
        }
        else{
            playerIsBlocking = false;
        }
    }
}
