using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed;
    private bool isMoving;


    private Rigidbody2D myRigidbody;
    private Vector3 input;


    private Animator animator;

   

    private void Awake()
    {
       animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isMoving)
        {

            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
            
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");


            if(input != Vector3.zero)
            {
            var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

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


}
