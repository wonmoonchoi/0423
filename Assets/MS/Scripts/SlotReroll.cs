using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotReroll : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public AddButton addButton;
    public Gold Gold;
    public int Price;
    public void Start()
    {
        Price = 10;
        textField.text = "슬롯 추가 리셋 - " + Price.ToString() + "g";
    }
    public void OnClickButton()
    {
        addButton.AddButtonReroll();
        Gold.Money -= Price;
        Gold.Start();
    }
}
