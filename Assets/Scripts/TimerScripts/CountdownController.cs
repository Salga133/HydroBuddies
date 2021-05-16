using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{

    public float countdownTime;
    public Text countdownDipslay;

    IEnumerator CountdownToStart() 
    {
        while(countdownTime > 0) 
        {
            countdownDipslay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDipslay.text = "GO!";

        yield return new WaitForSeconds(1f);

        countdownDipslay.gameObject.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(CountdownToStart());
    }
}
