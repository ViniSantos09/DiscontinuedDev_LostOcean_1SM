using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;

    public float speed;
    public float jumpHeight;
    private float jumpVelocity;  
    public float gravity;
    
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 direction = Vector3.forward * speed; 
        // Vector3.forward -> adiciona +1 no eixo Z

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpVelocity = jumpHeight;
            }
        }
        else
        {
            jumpVelocity -= gravity;
        }

        direction.y = jumpVelocity;

        controller.Move(direction * Time.deltaTime);
    }
}
