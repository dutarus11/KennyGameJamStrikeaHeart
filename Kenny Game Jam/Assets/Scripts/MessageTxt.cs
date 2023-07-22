using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTxt : MonoBehaviour
{
    
    [SerializeField]
    private GameObject messageTxt;

    private float waitingTime = 4f;
    private float seconds = 1f;

    private void Update()
    {
        WaitTime();
    }
    public void IntroTxt()
    {
        Debug.Log("Winning Condition UI succeeded!");        
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(seconds);
        waitingTime -= seconds;
        messageTxt.SetActive(false);
    }
}
