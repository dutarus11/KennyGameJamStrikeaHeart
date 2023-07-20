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
    [SerializeField]
    private GameObject winningTxt;

    private float waitingTime = 8f;
    private float seconds = 1f; 
    public void WinningCondition()
    {
        Debug.Log("Winning Condition UI succeeded!");
        winningTxt.SetActive(true);
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {        
        yield return new WaitForSeconds(seconds);
        waitingTime -= seconds;
        ExitGame();
    }
}
