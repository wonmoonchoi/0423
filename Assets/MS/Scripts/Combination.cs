using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Combination : MonoBehaviour
{
    public GameObject Item;
    public List<GameObject> Items = new List<GameObject>();
    public string Itemname;
    public Tooltip tooltipScript;
    public Sell SellScript;
    public SlotToolTip slotToolTip;
    public PickUpDown pickUpDown;
    public UseBtn useBtn;
    public ItemData itemData;
    public void OnClickButton()
    {
        // Item과 태그가 같은 GameObject만 추가
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.name == Item.name && obj.layer == LayerMask.NameToLayer("Weapon"))
            {
                if (obj.transform.parent.gameObject.layer == LayerMask.NameToLayer("Slot"))
                {
                    Items.Add(obj);
                }
            }
        }


        // 3개 이상의 요소가 있는지 확인
        if (Items.Count >= 3)
        {
            // 인덱스 0부터 2까지 요소 제거
            for (int i = 1; i < 3; i++)
            {
                PickUpDown pickUpDownScript = Items[i].GetComponent<PickUpDown>();
                // PickUpDown 스크립트가 있는지 확인
                if (pickUpDownScript != null)
                {
                    // ModifyPlayerStats 함수 호출
                    pickUpDownScript.ModifyPlayerStats(pickUpDownScript.playerStats, pickUpDownScript.SlotStats, '-');
                }
                
                Destroy(Items[i]);
            }

            // Items[0]의 스크립트에 접근하여 조정
            Items[0].GetComponent<PickUpDown>().Upgrade += 1;
/*            if (Items[0].GetComponent<PickUpDown>().Upgrade == 2)
            {
                Itemname = Items[0].name;
            }*/
       //     Items[0].tag = ItemTag+Items[0].GetComponent<PickUpDown>().Upgrade;
            pickUpDown = Items[0].GetComponent<PickUpDown>();
       //     Items[0].name = Itemname+pickUpDown.Upgrade;
            slotToolTip = Items[0].GetComponent<SlotToolTip>();

            //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ강화시 아이템 스탯 증가
            itemData.itemdata(slotToolTip.gameObject);
            slotToolTip.Price *= 3;

            pickUpDown.playerStats.Start();

            // 리스트 비우기
            Items.Clear();
        }
        else
        {
            Items.Clear();
        }
        transform.SetParent(tooltipScript.transform);
        SellScript.transform.SetParent(tooltipScript.transform);
        useBtn.transform.SetParent(tooltipScript.transform);
        tooltipScript.gameObject.SetActive(false);
        SellScript.gameObject.SetActive(false);
        useBtn.gameObject.SetActive(false);
        gameObject.SetActive(false);
        tooltipScript.UIstop = false;
    }
}
