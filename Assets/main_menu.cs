using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Quit!, can't really quit on editor, so here's a message instead lol");
        //Note: Does not work on editor, made it print 'Quit!' to indicate it quits lol.
        Application.Quit();
    }
}
