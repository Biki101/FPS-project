using System.Diagnostics;
using System.Xml;
using System;
using System.Threading;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

        public float speed = 10f;
        public float sensitivity = 5f;
        public Camera cam;

        private Rigidbody rb;

        private void Start() 
        {
            rb = GetComponent<Rigidbody>(); 

            cam = Camera.main;

            if (cam == null) 
            {
                UnityEngine.Debug.LogError("No Camera Found in the scene!");
            }
        }
    

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerRotation();
    }

    void PlayerMovement()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movZ = Input.GetAxisRaw("Vertical");
        
        UnityEngine.Vector3 movePlayer = new UnityEngine.Vector3(movX, 0, movZ);
        transform.Translate(movePlayer * Time.fixedDeltaTime * speed, Space.Self);  // local coordinates 
    }

    void PlayerRotation() 
    {
        float rotateY = Input.GetAxisRaw("Mouse X"); 
        
        UnityEngine.Vector3 rotation = new UnityEngine.Vector3(0,rotateY,0) * sensitivity;

        transform.Rotate(rotation); 

        float rotateX = Input.GetAxisRaw("Mouse Y");
        UnityEngine.Vector3 camRotation = new UnityEngine.Vector3(rotateX,0,0) * sensitivity; 
        cam.transform.Rotate(-camRotation);
    }
}
