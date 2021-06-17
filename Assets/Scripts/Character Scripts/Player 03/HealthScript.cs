using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public Text healthCountText;
    static int healthCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int playerHealth = GameObject.Find("Player 03").GetComponent<BasicMovement>().health;
        healthCountText.text = "Health: " + playerHealth.ToString();
    }
}
