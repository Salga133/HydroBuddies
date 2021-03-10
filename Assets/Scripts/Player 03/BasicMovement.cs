using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    private float moveSpeed;
    private float dirX;

    void Update()
    {
        // Normal Walk
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        transform.position = transform.position + movement * Time.deltaTime * moveSpeed;

        // Animation
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        //Run(Hold Shift)
        if (Input.GetKey (KeyCode.LeftShift))
            moveSpeed = 8f;
        else
            moveSpeed = 4f;

        dirX = Input.GetAxis ("Horizontal") * moveSpeed;
        dirX = Input.GetAxis ("Vertical") * moveSpeed;
    }
}


