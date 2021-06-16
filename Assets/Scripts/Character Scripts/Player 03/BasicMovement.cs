using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D myRigidbody;

    private float speed;
    public float walkSpeed;
    public float runSpeed;
    private float dirX;
    private Inventory inventory;
    public int health = 0;

    Vector3 movement;

    [SerializeField] private UI_Inventory uiInventory;

    private void Awake() 
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        // ItemWorld.SpawnItemWorld(new Vector3(-10, -7), new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
    }

    void Update()
    {
        ProcessInputs();
        Animate();
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null) {
            Debug.Log(itemWorld.item.itemType);
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    private void Move()
    {

        //Run(Hold Shift)
        // if (Input.GetKey (KeyCode.LeftShift)) 
        //     speed = runSpeed;
        // else
        //     speed = walkSpeed;

        speed = Input.GetKey (KeyCode.LeftShift) ? runSpeed : walkSpeed;
        
        //transform.position = transform.position + movement * Time.deltaTime * speed;
        myRigidbody.velocity = new Vector2(movement.x, movement.y) * speed;

        dirX = Input.GetAxis ("Horizontal") * speed;
        dirX = Input.GetAxis ("Vertical") * speed;
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

    public void AddHealth(int amount) {
        health += amount;
    }
}




