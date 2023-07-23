using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
   This script runs the winning condition 
*/
public class Win : Loading
{
    
    private float waitingTime = 10f;
    private float seconds = 1f; 
    public void WinningCondition()
    {
        Debug.Log("Winning Condition UI succeeded!");
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {        
        yield return new WaitForSeconds(seconds);
        waitingTime -= seconds;
        LoadingWinScene();
    }
}
