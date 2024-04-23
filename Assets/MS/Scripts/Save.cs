using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject Item;
    void Start()
    {

    }


    void Update()
    {
        if (transform.childCount == 1)
        {
            Item = transform.GetChild(0).gameObject;
        }
        if (Item != null && transform.childCount == 0)
        {
            SlotParent slotParentScript = Item.GetComponent<SlotParent>();
            if (slotParentScript != null)
            {
                if (gameObject != slotParentScript.Slot)
                {
                  //  Destroy(gameObject);
                }
            }
        }
    }
}
