using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestShopUI : MonoBehaviour
{
    //�׽�Ʈ�� ������ �и��ؼ� �����ϱ� ���� ����

    public Text moneyText;

    void Start()
    {
        moneyText = transform.GetChild(8).GetComponentInChildren<Text>();
        moneyText.text = Convert.ToString(GameManager.instance.money);
    }


    public void OnButtonClicked_Slot1() //�ٰŸ� ���� ����
    {
        if(GameManager.instance.money >= 4500)
        {

            GameManager.instance.money -= 4500;
        }

        moneyText.text = Convert.ToString(GameManager.instance.money);
    }

    public void OnButtonClicked_Slot2() //���Ÿ� ���� ����
    {

    }

    public void OnButtonClicked_Slot3() //���ݷ� ���׷��̵�
    {

    }

    public void OnButtonClicked_Slot4() //���ݼӵ� ���׷��̵�
    {

    }

    public void OnButtonClicked_Slot5() //ü�� ���׷��̵�
    {

    }

    public void OnButtonClicked_Slot6() //ü�� ȸ��
    {

    }

    public void OnButtonClikcked_Exit()
    {
        SceneManager.LoadScene("InGame");
    }
}
