using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reroll : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public Store Store;
    public Gold Gold;
    public int Price;
    public void Start()
    {
        Price = 10;
        textField.text = "���� ���� - " + Price.ToString() + "g";
    }
    public void OnClickButton()
    {
        if (Gold.Money >= Price)
        {
            Store.StoreReset();
            Gold.Money -= Price;
            Gold.Start();
            // Price �������� ���� ����
        }
    }
}
