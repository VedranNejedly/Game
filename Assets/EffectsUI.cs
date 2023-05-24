using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EffectsUI : MonoBehaviour
{
    public GameObject player;

    // public List<GameObject> ImagesUI = new List<GameObject>();
    public GameObject[] ImagesUI;
    public Image[] ImagesUItemp;
    public Sprite[] EffectsSprites; 
    public int[][] indexes = new int[2][];


    int frozenIndex,poisonIndex;
    bool isSetFrozenUI,playerIsPoisoned = false;
    // Start is called before the first frame update
    void Start()
    {
        indexes[0] = new int[4];
        indexes[1] = new int[4];

        for(int i=0;i<2;i++){
            for(int j=0;j<4;j++){
                indexes[i][j]=99;
            }
        }

        indexes[0][0]=99;
        for(int i = 0;i<ImagesUI.Length;i++){
            ImagesUItemp[i] = ImagesUI[i].GetComponent<Image>();
            // ImagesUItemp[i].sprite = EffectsSprites[i];
        }
    }

    // Update is called once per frame
    void Update()
    {


        if(player.GetComponent<PlayerMovement>().frozen){
            for(int i = 0;i<ImagesUI.Length;i++){
                if(ImagesUItemp[i].sprite == null && isSetFrozenUI == false){
                    ImagesUItemp[i].sprite = EffectsSprites[0];
                    indexes[0][i] = i;
                    indexes[1][i] = 1; 

                    ImagesUI[i].GetComponent<Image>().enabled = true; 
                    frozenIndex = i;
                    isSetFrozenUI = true;
                }
            }
        }
        if(player.GetComponent<PlayerMovement>().frozen==false && isSetFrozenUI){
            isSetFrozenUI = false;
            ImagesUI[frozenIndex].GetComponent<Image>().enabled = false; 
            indexes[0][frozenIndex] = 99;
            ImagesUItemp[frozenIndex].sprite = null;
            indexes[1][frozenIndex] = 99; 
        }

        if(player.GetComponent<PlayerHealth>().isPoisoned){
            for(int i = 0;i<ImagesUI.Length;i++){
                if(ImagesUItemp[i].sprite == null && playerIsPoisoned == false){
                    ImagesUItemp[i].sprite = EffectsSprites[1];
                    indexes[0][i] = i;
                    indexes[1][i] = 2; 

                    ImagesUI[i].GetComponent<Image>().enabled = true; 
                    poisonIndex = i;
                    playerIsPoisoned = true;
                }
            }
        }

        if(player.GetComponent<PlayerHealth>().isPoisoned==false && playerIsPoisoned){
            playerIsPoisoned = false;
            ImagesUI[poisonIndex].GetComponent<Image>().enabled = false; 
            ImagesUItemp[poisonIndex].sprite = null;    
            indexes[0][poisonIndex] = 99;
            indexes[1][poisonIndex] = 99; 
        }

        UpdateUI();
    }


    private void UpdateUI(){
        int indexValue;
        int typeValue;
        
        for(int i=0;i<3;i++){
            if(indexes[0][i]!=99){
                Debug.Log("Index [0]["+i+"]is equal to"+indexes[0][i]);

            }

            for(int j=0;j<3;j++){
                if(indexes[0][j]==99 && indexes[0][j+1]!=99){
                    indexValue = indexes[0][j+1];
                    typeValue= indexes[1][j+1];
                    indexes[0][j+1] = 99;
                    indexes[1][j+1] = 99;
                    indexes[0][j] = indexValue;
                    indexes[1][j] = typeValue;
                    ImagesUItemp[j].sprite = EffectsSprites[0];
                    ImagesUI[j].GetComponent<Image>().enabled = true; 
                    ImagesUI[j+1].GetComponent<Image>().enabled = false; 



                    if(typeValue==1){
                        ImagesUItemp[j].sprite = EffectsSprites[0];
                        frozenIndex=j;

                    }
                    if(typeValue==2){
                        ImagesUItemp[j].sprite = EffectsSprites[1];
                        poisonIndex = j;
                    }

                }
            }
           
        }

    }

}
