using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float moveSpeed;
//    public LayerMask solidObjectsLayer;
//    public LayerMask treesLayer;
    

   private Rigidbody2D myRigidbody; 
   private bool isMoving;
   private Vector3 input;
   private Animator animator;

   

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }



    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }


   private void Update()
    {
        
        if (!isMoving) 
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //remove diagonal movement
            // if (input.x !=0) input.y = 0; 

            if (input != Vector3.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                // if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }
        
        animator.SetBool("isMoving", isMoving);
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + input * moveSpeed * Time.deltaTime
        );
    }


    IEnumerator Move(Vector3 targetPos) 
    {
        isMoving = true;
        
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    // private bool IsWalkable(Vector3 targetPos)
    // {
    //     if (Physics2D.OverlapCircle(targetPos, 0f, treesLayer) != null)
    //     {
    //         return false;
    //     }

    //     return true;
    // }
}