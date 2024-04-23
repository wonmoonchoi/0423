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
        // Item�� �±װ� ���� GameObject�� �߰�
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


        // 3�� �̻��� ��Ұ� �ִ��� Ȯ��
        if (Items.Count >= 3)
        {
            // �ε��� 0���� 2���� ��� ����
            for (int i = 1; i < 3; i++)
            {
                PickUpDown pickUpDownScript = Items[i].GetComponent<PickUpDown>();
                // PickUpDown ��ũ��Ʈ�� �ִ��� Ȯ��
                if (pickUpDownScript != null)
                {
                    // ModifyPlayerStats �Լ� ȣ��
                    pickUpDownScript.ModifyPlayerStats(pickUpDownScript.playerStats, pickUpDownScript.SlotStats, '-');
                }
                
                Destroy(Items[i]);
            }

            // Items[0]�� ��ũ��Ʈ�� �����Ͽ� ����
            Items[0].GetComponent<PickUpDown>().Upgrade += 1;
/*            if (Items[0].GetComponent<PickUpDown>().Upgrade == 2)
            {
                Itemname = Items[0].name;
            }*/
       //     Items[0].tag = ItemTag+Items[0].GetComponent<PickUpDown>().Upgrade;
            pickUpDown = Items[0].GetComponent<PickUpDown>();
       //     Items[0].name = Itemname+pickUpDown.Upgrade;
            slotToolTip = Items[0].GetComponent<SlotToolTip>();

            //�ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѰ�ȭ�� ������ ���� ����
            itemData.itemdata(slotToolTip.gameObject);
            slotToolTip.Price *= 3;

            pickUpDown.playerStats.Start();

            // ����Ʈ ����
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
