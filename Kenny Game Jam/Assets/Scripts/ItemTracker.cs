using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
   This script tracks the number of items/hearts 
*/
public class ItemTracker : MonoBehaviour
{
        
    [SerializeField]
    private int itemTrackingNum = 0;

    private static ItemTracker itemNumInstance;

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
}
