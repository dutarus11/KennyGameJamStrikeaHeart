using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
   This script manages collecting the items
*/
public class ItemCollection : MonoBehaviour
{
    
   // public int tallyItem = 0;
    [SerializeField] private GameObject item;
    //public int hearts;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Item"))
        {
            Debug.Log("Item collected!");
            
            Destroy(this.gameObject);
            OnDestroy();
            //tallyItem++;
            
        }
    }

    public void OnDestroy()
    {
        ItemTracker.Instance.ItemCounter++;
    }

  }



