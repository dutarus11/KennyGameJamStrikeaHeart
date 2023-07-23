using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/*
   This script tracks the number of items/hearts with the singleton approach 
*/
public class ItemTracker : Win
{
        
    [SerializeField]
    private int itemTrackingNum = 0;
    private float maxNum = 10f;
     
    private static ItemTracker itemNumInstance;

    private void Update()
    {
        WinningItemCounterNum();
    }
    public int ItemCounter
    {
        get { return itemTrackingNum; } set { itemTrackingNum = value; }
    }

    public static ItemTracker Instance
    {
        get { return itemNumInstance; }
    }

    public void Start()
    {
        if (itemNumInstance !=  null)
        {
            Destroy(this.gameObject);
            return;
        }
        itemNumInstance = this;
    }

    void WinningItemCounterNum()
    {
        if (itemTrackingNum == maxNum)
        {
            WinningCondition();
        }
    }
}
