using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D myRigidbody;

    private float moveSpeed;
    private float dirX;



    Vector3 movement;

    void Update()
    {
        ProcessInputs();
        Animate();
        Move();

    }

    private void Move()
    {
        //Normal Walk
        //transform.position = transform.position + movement * Time.deltaTime * moveSpeed;

        myRigidbody.velocity = new Vector2(movement.x, movement.y) * moveSpeed;

        //Run(Hold Shift)
        if (Input.GetKey (KeyCode.LeftShift))
            moveSpeed = 6f;
        else
            moveSpeed = 4f;

        dirX = Input.GetAxis ("Horizontal") * moveSpeed;
        dirX = Input.GetAxis ("Vertical") * moveSpeed;
    }

    private void ProcessInputs()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
    }
        

    private void Animate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
    }
}




