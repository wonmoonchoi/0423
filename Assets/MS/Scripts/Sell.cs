using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sell : MonoBehaviour
{
    public GameObject Item;
    public Gold Gold;
    public int PlayerGold;

    public Tooltip tooltipScript;
    public Combination CombinationScript;
    public SlotToolTip slotToolTip;
    public UseBtn UseBtn;

    public PlayerStats2 playerStats;
    public void OnClickButton()
    {
        if (Item != null)
        {
            PickUpDown pickUpDownScript = Item.GetComponent<PickUpDown>();
            // PickUpDown 스크립트가 있는지 확인
            if (pickUpDownScript != null)
            {
                // ModifyPlayerStats 함수 호출
                pickUpDownScript.ModifyPlayerStats(pickUpDownScript.playerStats, pickUpDownScript.SlotStats, '-');
            }
            slotToolTip = Item.GetComponent<SlotToolTip>();
            Gold.Money += (int)(slotToolTip.Price * 0.7f);
            Gold.Start();
                
            Destroy(Item); // Item GameObject를 파괴합니다.
            transform.SetParent(tooltipScript.transform);
            CombinationScript.transform.SetParent(tooltipScript.transform);
            UseBtn.transform.SetParent(tooltipScript.transform);
            tooltipScript.gameObject.SetActive(false);
            CombinationScript.gameObject.SetActive(false);
            UseBtn.gameObject.SetActive(false);
            gameObject.SetActive(false);
            tooltipScript.UIstop = false;
        }
    }
}
