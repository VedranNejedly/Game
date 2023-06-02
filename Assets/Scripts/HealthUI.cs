using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthUI : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public Slider healthSlider;
    public Slider armorSlider;
    // Start is called before the first frame update
    void Start()
    {
       playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.maxValue = (float)playerHealth.maxHealth;
        armorSlider.maxValue = (float)playerHealth.maxPlayerArmor;  
        healthSlider.value = (float)playerHealth.health;
        armorSlider.value = (float)playerHealth.playerArmor;

    }
}




