using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthSlider : MonoBehaviour
{

    public Enemy enemy;
    public Slider enemyHealth;
    private Camera camera;
    public Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth.maxValue = enemy.health;
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canvas.worldCamera = camera;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealth.value = (float)enemy.health;
    }
}


