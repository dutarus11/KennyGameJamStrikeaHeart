using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
   This script controls the loading & exiting scene functions  
*/
public class Loading : MonoBehaviour
{
    
    public void LoadingScene() 
    {
        //loading the game via onclick button 
        Debug.Log("Loading scene succeeded!");
        SceneManager.LoadScene("Level 1");
    }

    public void ExitGame()
    {
        //exit the game via onclick button 
        Debug.Log("Game exit succeeded!");
        Application.Quit();
    }
}
