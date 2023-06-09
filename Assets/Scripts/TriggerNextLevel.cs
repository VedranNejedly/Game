using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TriggerNextLevel : MonoBehaviour
{

    public bool nextLevelTrigger = false;
    public GameObject player;
    private CharacterController controller;
    private GameObject canvas;
    private Transform loadingScreen;
    private Transform slider;
    private Slider loadingSlider;
    private bool loading = false;
    private float transitionTime = 3.0f;
    private AudioManager audioManager;

        // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        loadingScreen = canvas.transform.Find("LoadingScreen");
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
        slider = loadingScreen.Find("Slider");
        loadingSlider = slider.gameObject.GetComponent<Slider>();
        loadingSlider.maxValue = transitionTime*0.9f;

    }

    // Update is called once per frame
    void Update()
    {
        if(loading){
            loadingSlider.value += Time.deltaTime;
        }
    }

    public void canTriggerNextLevel(){
        nextLevelTrigger = true;
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Player"){
            if(nextLevelTrigger){
                FindObjectOfType<AudioManager>().stopSound("TrapSlide");
                loadNextScene();
            }
        }
    }
    
    void loadNextScene(){
        loading = true;
        StartCoroutine(loadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator loadScene(int sceneIndex){
        loadingScreen.gameObject.SetActive(true);
        audioManager.pauseAllSound();
        yield return new WaitForSeconds(transitionTime);
        loadingScreen.gameObject.SetActive(false);
        audioManager.resumeAllSound();
        SceneManager.LoadScene(sceneIndex);
        loadingSlider.value = 0;
    }

}
