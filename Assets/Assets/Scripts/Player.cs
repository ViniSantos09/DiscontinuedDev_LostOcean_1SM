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

    public float horizontalSpeed;
    private bool isMovingRight;
    private bool isMovingLeft;

    public float rayRadius;
    public LayerMask layer;
    public LayerMask coinLayer;

    public bool isDead;

    private GameController gc;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gc = FindObjectOfType<GameController>(); 
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

            if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 270.5f && !isMovingRight)
            {
                isMovingRight = true;
                StartCoroutine(RightMove());
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -270.5f && !isMovingLeft)
            {
                isMovingLeft = true;
                StartCoroutine(LeftMove());
            }
        }
        else
        {
            jumpVelocity -= gravity;
        }

        OnCollision();

        direction.y = jumpVelocity;

        controller.Move(direction * Time.deltaTime);

    }

    IEnumerator LeftMove()
    {
        while (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -270.5f)
        {
            controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
            yield return null;
        }

        isMovingLeft = false;
    }

    IEnumerator RightMove()
    {
        while (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 270.5f)
        {
            controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
            yield return null;
        }

        isMovingRight = false;
    }


    void OnCollision()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayRadius, Color.red);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayRadius, layer) && !isDead)
        {
            Debug.Log("bateu");
            //CHAMA GAME OVER
            speed = 0;
            jumpHeight = 0;
            horizontalSpeed = 0;
            Invoke("GameOver", 1f);


            isDead = true;
        }

        RaycastHit coinHit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0, 1f, 0)), out coinHit, rayRadius, coinLayer))
        {
            //AO BATER NA MOEDA
            gc.AddCoin();
            Destroy(coinHit.transform.gameObject);

        }
    }

    void GameOver()
    {
        gc.ShowGameOver();
    }
}
