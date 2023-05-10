using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health = 10;
    // Start is called before the first frame update
    // void Start()
    // {
    //     Debug.Log(maxHealth);
    // }

    // Update is called once per frame

    private void checkPlayerHealth(){
        if(health<=0){
            //Destroy player object
            Destroy(gameObject);
        }
    }

    void Update()
    {
        checkPlayerHealth();
    }
}
