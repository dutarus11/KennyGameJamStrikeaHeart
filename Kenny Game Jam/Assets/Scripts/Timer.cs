using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    float currentTime= 0f;
    float beginTime = 60f;

    [SerializeField] Text countDownTxt;

    private void Start()
    {
        currentTime = beginTime;      
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownTxt.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime  = 0;
        }
        
    }
}