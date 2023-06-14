using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    private RunStats runStats;

    // Start is called before the first frame update
    void Start()
    {
        runStats = GameObject.FindGameObjectWithTag("RunStatsSaver").GetComponent<RunStats>();
        runStats.WinARun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
