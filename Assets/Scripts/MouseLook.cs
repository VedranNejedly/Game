using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    //Objekt koji mozemo rotirati
    public Transform playerBody;
    float xRotation= 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Kursor je zaključan u sredini ekrana i nije vidljiv.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        //Uzimamo input za x i y os te ih mnozimo sa mouseSensitivity i Time.deltaTime
        float mouseXAxis = Input.GetAxis("Mouse X")*mouseSensitivity * Time.deltaTime;
        float mouseYAxis = Input.GetAxis("Mouse Y")*mouseSensitivity * Time.deltaTime;

        xRotation -= mouseYAxis;
        // Rotacija može biti maksimalno -90 stupnjeva i 90 stupnjeva kako kamera se ne bi okrenula kroz igraca.
        // Igrac moze pogledati u nebo i pod ali ne i kroz sebe.
        xRotation = Mathf.Clamp(xRotation,-90f,30f);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        //Rotacija objekta na x osi
        playerBody.Rotate(Vector3.up * mouseXAxis);

    }
}


