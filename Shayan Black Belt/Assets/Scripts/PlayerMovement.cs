using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 4f;
    public float jumpForce = 5f;
    public float maxDistance = 1.2f;
    public LayerMask groundLayer;
    public bool isGrounded;

    private CapsuleCollider capCol;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        capCol = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, maxDistance, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Debug.Log("JUMP!");
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
        Sprinting();
        Crouch();
    }

    private void Sprinting()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded == true)
        {
            speed = 8f;
        }
        else
        {
            speed = 4f;
        }
    }

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.C) && isGrounded == true)
        {
            capCol.height = 1f;
            speed = 2f;
        }
        else
        {
            capCol.height = 2f;
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
