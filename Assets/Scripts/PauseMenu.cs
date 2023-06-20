using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class PauseMenu : MonoBehaviour
{

    public bool gameIsPaused=false;
    public bool gameCanBePaused = true;
    public GameObject pauseMenuUI;
    public GameObject player;
    private DestroyList dl;
    private RunStats runStats;
    private PlayerHealth PlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = player.GetComponent<PlayerHealth>();
        dl = GameObject.FindGameObjectWithTag("ItemsToDestroy").GetComponent<DestroyList>();
        runStats = GameObject.FindGameObjectWithTag("RunStatsSaver").GetComponent<RunStats>();

    }

    // Update is called once per frame
    void Update()
    {      
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            }else{
                if(gameCanBePaused){
                    Pause();
                }
            }
        }
    }

    private void Pause(){
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    public void Quit(){
        if(PlayerHealth.health>0){
            runStats.QuitARun();
        }
        Application.Quit();

    }

    public void LoadMainMenu(){
        if(PlayerHealth.health>0){
            runStats.QuitARun();
        }

        dl.DestroyerToMenu();
        // Destroy(dl.RunStatsSaver);
    

        // for(int i=0;i<dl.itemsToDestroy.Count;i++){
        //     Destroy(dl.itemsToDestroy[i]);
        // }
        // Destroy(GameObject.Find("DirectionalLight"));

        // Destroy(dl.gameObject);

        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
        DestroyGameObject();

    }


     void DestroyGameObject()
    {
        Destroy(player);
    }

}
