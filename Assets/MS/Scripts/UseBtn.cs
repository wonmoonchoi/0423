using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UseBtn : MonoBehaviour
{
    public GameObject Item;
    public Tooltip tooltipScript;
    public Sell SellScript;
    public Combination combination;
    public void OnClickButton()
    {
        if (Item != null && Item.layer == LayerMask.NameToLayer("Potion"))
        {
            SlotToolTip slotToolTip = Item.GetComponent<SlotToolTip>();
            PickUpDown pickupdown = Item.GetComponent<PickUpDown>();
            if (slotToolTip != null)
            {
                if (slotToolTip.AddSlotint)
                {
                    AddButton addButton = GameObject.Find("AddButton").GetComponent<AddButton>();
                    addButton.addbtn();
                }



                Destroy(Item); // Item GameObject를 파괴합니다.
                transform.SetParent(tooltipScript.transform);
                SellScript.transform.SetParent(tooltipScript.transform);
                combination.transform.SetParent(tooltipScript.transform);
                combination.gameObject.SetActive(false);
                tooltipScript.gameObject.SetActive(false);
                SellScript.gameObject.SetActive(false);
                gameObject.SetActive(false);
                tooltipScript.UIstop = false;
            }
        }
    }
}
