using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{

    public Transform magicSpawnPoint;
    public GameObject magicPrefab;
    public float magicSpeed=10;
    public float castCooldownInSeconds = 10f;
    public bool canCast = true;


 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetMouseButtonDown(1)){
                castAttackMagic();
            }

    }

    public void reduceCooldown(float cdReduction){
        castCooldownInSeconds-=cdReduction;
    }
    void castAttackMagic(){
        if(!canCast){
            return;
        }
        var magic  = Instantiate(magicPrefab,magicSpawnPoint.position,magicSpawnPoint.rotation);
        magic.GetComponent<Rigidbody>().velocity = magicSpawnPoint.forward * magicSpeed;
        StartCoroutine(StartCooldown());
       
    }


    public IEnumerator StartCooldown(){
        canCast = false;
        yield return new WaitForSeconds(castCooldownInSeconds);
        canCast = true;
    }
}
