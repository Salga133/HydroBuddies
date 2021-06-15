using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
   public void PlayLakeLevel()
   {
       SceneManager.LoadScene("Test 03");
   }

   public void PlayBridgeLevel()
   {
       SceneManager.LoadScene("Test 01");
   }

   public void PlayUknownLevel()
   {
       SceneManager.LoadScene("Test 02");
   }
}
