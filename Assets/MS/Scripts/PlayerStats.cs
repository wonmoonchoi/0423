using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // TextMeshPro - Text (UI) 컴포넌트에 접근할 변수
    public TextMeshProUGUI textField;

    void Start()
    {
        // TextMeshPro - Text (UI) 컴포넌트에 글자 입력
        textField.text =
            "최대 체력\n" +
            "현재 체력\n\n" +

            "물리 데미지\n" +
            "마법 데미지\n\n" +

            "크리티컬 확률\n" +
            "크리티컬 데미지\n\n" +

            "공격 속도\n" +
            "이동 속도\n\n" +

            "사거리\n" +
            "범위\n" +
            "넉백\n\n" +

            "체력 흡수\n" +
            "체력 자연 회복\n" +
            "부활\n" +
            "방어력\n\n" +

            "행운\n" +
            "경험치 획득률\n" +
            "무기 숙련도\n" +
            "신의가호 드랍률\n" +
            "골드 획득률\n\n" +

            "추가 발사체\n" +
            "튕김\n" +
            "관통\n" +
            "아이템 획득 반경\n";
    }
}
