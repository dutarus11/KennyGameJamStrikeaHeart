using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
   This script manages collecting the items
*/
public class ItemCollection : MonoBehaviour
{
       
    [SerializeField] private GameObject item;    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Item"))
        {
            Debug.Log("Item collected!");            
            Destroy(this.gameObject);
            OnDestroy();                       
        }
    }

    public void OnDestroy()
    {
        ItemTracker.Instance.ItemCounter++;
    }

  }



