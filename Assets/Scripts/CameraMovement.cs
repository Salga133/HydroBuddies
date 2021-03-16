using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform playerTranform;

    void Start()
    {
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = playerTranform.position.x;

        temp.y = playerTranform.position.y;

        transform.position = temp;
    }
    
}