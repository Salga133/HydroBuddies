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
        float timer = timerInMinutes * 60;
        while(timer > 0) 
        {
            int minutes = (int)(timer / 60);
            int seconds = (int)timer % 60;
            int miliseconds = (int)((timer - (int)(timer))*100); 
            string minutesText = minutes.ToString("00");
            string secondsText = seconds.ToString("00");
            string milisecondsText = miliseconds.ToString("00");
            string display = string.Format("Time: {0}:{1}.{2}", minutesText, secondsText, milisecondsText);

            timerDisplay.text = display;

            yield return new WaitForSeconds(0.01f);

            timer -= 0.01f;
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
