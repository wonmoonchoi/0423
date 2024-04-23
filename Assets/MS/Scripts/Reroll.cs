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
        textField.text = "상점 리셋 - " + Price.ToString() + "g";
    }
    public void OnClickButton()
    {
        if (Gold.Money >= Price)
        {
            Store.StoreReset();
            Gold.Money -= Price;
            Gold.Start();
            // Price 누를수록 가격 설정
        }
    }
}
