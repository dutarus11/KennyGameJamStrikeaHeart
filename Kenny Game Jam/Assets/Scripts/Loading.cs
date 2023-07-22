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

    public void LoadingTitleScene()
    {
        //loading the game title scene
        Debug.Log("Loading game title scene succeeded!");
        SceneManager.LoadScene("TitleScene");
    }

    public void LoadingWinScene()
    {
        //loading the winning scene
        Debug.Log("Loading game title scene succeeded!");
        SceneManager.LoadScene("WinningScene");
    }
    public void ExitGame()
    {
        //exit the game via onclick button 
        Debug.Log("Game exit succeeded!");
        Application.Quit();
    }

}
