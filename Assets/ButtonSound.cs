using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private Button button;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();

    }

    void TaskOnClick(){
		audioSource.Play();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
