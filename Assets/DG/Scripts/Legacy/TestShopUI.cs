using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestShopUI : MonoBehaviour
{
    //테스트용 씬으로 분리해서 제거하기 쉽게 만듬

    public Text moneyText;

    void Start()
    {
        moneyText = transform.GetChild(8).GetComponentInChildren<Text>();
        moneyText.text = Convert.ToString(GameManager.instance.money);
    }


    public void OnButtonClicked_Slot1() //근거리 무기 구입
    {
        if(GameManager.instance.money >= 4500)
        {

            GameManager.instance.money -= 4500;
        }

        moneyText.text = Convert.ToString(GameManager.instance.money);
    }

    public void OnButtonClicked_Slot2() //원거리 무기 구입
    {

    }

    public void OnButtonClicked_Slot3() //공격력 업그레이드
    {

    }

    public void OnButtonClicked_Slot4() //공격속도 업그레이드
    {

    }

    public void OnButtonClicked_Slot5() //체력 업그레이드
    {

    }

    public void OnButtonClicked_Slot6() //체력 회복
    {

    }

    public void OnButtonClikcked_Exit()
    {
        SceneManager.LoadScene("InGame");
    }
}
