using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerController : MonoBehaviour
{

    public float timerInMinutes;
    public Text timerDisplay;
    

    

    IEnumerator TimerToStart() 
    {
        

        yield return new WaitForSeconds(5);

        float timer = timerInMinutes * 60;
        while(timer > 0) 
        {
            int minutes = (int)(timer / 60);
            int seconds = (int)timer % 60;
            string minutesText = minutes.ToString("00");
            string secondsText = seconds.ToString("00");
            string display = string.Format("Time: {0}:{1}", minutesText, secondsText);

            timerDisplay.text = display;

            yield return new WaitForSeconds(1f);

            timer -= 1f;
        }

        timerDisplay.text = "STOP!";

        yield return new WaitForSeconds(1f);

        timerDisplay.gameObject.SetActive(false);
    }


    

    

    void Start()
    {
        StartCoroutine(TimerToStart());
    }
}
