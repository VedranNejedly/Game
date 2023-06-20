using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    private RunStats runStats;
    private DestroyList dl;


    // Start is called before the first frame update
    void Start()
    {   
        runStats = GameObject.FindGameObjectWithTag("RunStatsSaver").GetComponent<RunStats>();
        runStats.WinARun();

        dl = GameObject.FindGameObjectWithTag("ItemsToDestroy").GetComponent<DestroyList>();
        dl.DestroyerToMenu();
        StartCoroutine(LoadMainMenu());

    }

    IEnumerator LoadMainMenu(){
        yield return new WaitForSeconds(10.0f);
        Destroy(runStats);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
}
