using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OptionsMenu : MonoBehaviour
{   
    public TMP_Dropdown resolutionsDropdown;
    Resolution[] resolutionsArray;
    int pcResolutionIndex = 0;
    public Slider mouseSens;


    void Start(){
        mouseSens.value = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>().getSensitivity();
        resolutionsArray = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();
        

        for(int i=0;i<resolutionsArray.Length;i++){
            string option = resolutionsArray[i].width+ " x " +resolutionsArray[i].height; 
            options.Add(option);

            if (resolutionsArray[i].width == Screen.currentResolution.width && resolutionsArray[i].height == Screen.currentResolution.height){
                pcResolutionIndex=i;
            }
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = pcResolutionIndex;
        resolutionsDropdown.RefreshShownValue();

    }

    public void updateResolution(int resolutionIndex){
        Resolution resolution = resolutionsArray[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }

    public void setGraphicQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void fullscreenToggle(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void SetMouseSensitivity(){
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>().setSensitivity(mouseSens.value);
    }
}
 