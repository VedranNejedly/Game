using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueHolder : MonoBehaviour
{
    public int value;
    // Start is called before the first frame update
    public void storeValue(int val){
        value = val;
    }

}
