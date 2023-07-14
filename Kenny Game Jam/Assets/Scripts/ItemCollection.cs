using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public GameObject[] heartObjs;
    //public int hearts;
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Item collected!");
            if (col.gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
            }
            //hearts++;
            // other.gameObject.SetActive(false);
            //Destroy(gameObject);
        }
}
    //    ItemInventory itemInventory = other.GetComponent<ItemInventory>();
    //    if (itemInventory != null) 
    //    {
    //        itemInventory.ItemsCollected();
    //        gameObject.SetActive(false);
    //        Debug.Log("Collision works!");
    //    }
   

}
   


