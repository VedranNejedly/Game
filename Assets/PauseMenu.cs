using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class PauseMenu : MonoBehaviour
{

    public bool gameIsPaused=false;
    public GameObject pauseMenuUI;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {      
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            }else{
                Pause();
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
        Application.Quit();
    }

    public void LoadMainMenu(){
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
