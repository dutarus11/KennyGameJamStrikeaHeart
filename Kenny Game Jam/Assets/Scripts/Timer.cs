using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
   This script manages timer 
*/
public class Timer : Loading
{
    public float currentTime= 0f;
    public float beginTime = 10f;
      
    public float num = 0, num1 = 1, num2 = 0;
    
    [SerializeField] Text countDownTxt;
    
    public void Start() 
    {
        StartingTime();       
    }

    public void Update()
    {
       UpdatingTime();
    }

    public void StartingTime()
    {
        currentTime = beginTime;
    }

    private void UpdatingTime()
    {
        currentTime -= num1 * Time.deltaTime;
        countDownTxt.text = currentTime.ToString("0");

        if (currentTime <= num)
        {
            currentTime = num;
        }
        if (currentTime <= num2)
        {
            Debug.Log("Reset succeeds!");
            LoadingScene();           
        }
        
    }

    public void UpdatingWinSceneTime()
    {
        beginTime = 5; 
        currentTime -= num1 * Time.deltaTime;        
        

        if (currentTime <= num)
        {
            currentTime = num;
        }
        if (currentTime <= num2)
        {            
            ExitGame();
        }

    }
}