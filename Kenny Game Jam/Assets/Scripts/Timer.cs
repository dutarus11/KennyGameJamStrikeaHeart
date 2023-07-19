using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : Loading
{
    float currentTime= 0f;
    float beginTime = 10f;
    float num = 0, num1 = 1, num2 = 0;
    
    [SerializeField] Text countDownTxt;

    private void Start() 
    {
        StartingTime();
    }

    private void Update()
    {
       UpdatingTime();
    }

    private void StartingTime()
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
}